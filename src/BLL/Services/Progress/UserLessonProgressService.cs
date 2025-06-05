using DAL;
using DAL.Entities.Enums;
using DAL.Entities.Relations;
using DAL.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace BLL.Services.Progress
{
    public class UserLessonProgressService : IUserLessonProgressService
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepo;

        public UserLessonProgressService(AppDbContext context, IUserRepository userRepo)
        {
            _context = context;
            _userRepo = userRepo;
        }

        public async Task RegisterModuleCompletion(int userId, int lessonId, TaskLangType moduleType)
        {
            var prog = await _context.UsersToLessons
                .FirstOrDefaultAsync(u => u.UserId == userId && u.LessonId == lessonId)
                ?? new UsersToLessons { UserId = userId, LessonId = lessonId };

            switch (moduleType)
            {
                case TaskLangType.Quiz: prog.QuizCompleted = true; break;
                case TaskLangType.Reading: prog.ReadingCompleted = true; break;
                case TaskLangType.Speaking: prog.SpeakingCompleted = true; break;
            }

            if (!prog.PointsAwarded
            && prog.QuizCompleted
            && prog.ReadingCompleted
            && prog.SpeakingCompleted)
            {
                var lesson = await _context.Lessons.FindAsync(lessonId);
                prog.AwardedPoints = (int)lesson.Level;
                prog.PointsAwarded = true;
                prog.DateCompleted = DateTime.UtcNow;   
            }

            if (prog.Id == 0)
                _context.UsersToLessons.Add(prog);

            await _context.SaveChangesAsync();
        }

        public Task<int> GetPointsForLanguage(int userId, int languageId)
        {
            return _userRepo.GetUserPointsForLanguageAsync(userId, languageId);
        }

        public Task<int> GetTotalPoints(int userId)
        {
            return _userRepo.GetUserTotalPointsAsync(userId);
        }


        public async Task<List<int>> GetMonthlyPointsForLanguage(int userId, int languageId, int monthsBack = 6)
        {
            var valuesList = string.Join(',', Enumerable.Range(0, monthsBack)
                                               .Select(i => $"({i})"));

            var sql = $@"
    WITH LastMonths AS (
        SELECT DATEADD(month, -n, GETUTCDATE()) AS M
        FROM (VALUES {valuesList}) AS V(n)
    )
, Summed AS (
    SELECT 
        YEAR(u.DateCompleted) AS Yr, 
        MONTH(u.DateCompleted) AS Mo, 
        SUM(u.AwardedPoints)     AS Points
    FROM UsersToLessons u
    INNER JOIN Lessons l 
        ON u.LessonId = l.Id
    WHERE u.UserId = @userId
      AND l.LanguageId = @languageId
      AND u.DateCompleted >= @cutoff
      AND u.PointsAwarded = 1
    GROUP BY 
        YEAR(u.DateCompleted), 
        MONTH(u.DateCompleted)
)
SELECT 
    YEAR(lm.M)   AS Yr, 
    MONTH(lm.M)  AS Mo, 
    ISNULL(s.Points, 0) AS Points
FROM LastMonths lm
LEFT JOIN Summed s 
    ON YEAR(lm.M) = s.Yr 
   AND MONTH(lm.M) = s.Mo
ORDER BY lm.M;
";

            var cutoff = DateTime.UtcNow.AddMonths(-monthsBack);
            var data = await _context
                .Set<MonthDto>()  
                .FromSqlRaw(sql,
                    new SqlParameter("@userId", userId),
                    new SqlParameter("@languageId", languageId),
                    new SqlParameter("@cutoff", cutoff))
                .ToListAsync();
            return data.Select(d => d.Points).ToList();
        }

        public class MonthDto
        {
            public int Yr { get; set; }
            public int Mo { get; set; }
            public int Points { get; set; }
        }

        public async Task<List<int>> GetMonthlyTotalPoints(int userId, int monthsBack = 6)
        {
            var cutoff = DateTime.UtcNow.AddMonths(-monthsBack);
            var data = await _context.UsersToLessons
                .Where(u => u.UserId == userId
                         && u.DateCompleted >= cutoff
                         && u.PointsAwarded)
                .GroupBy(u => new { u.DateCompleted.Year, u.DateCompleted.Month })
                .Select(g => new {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Points = g.Sum(x => x.AwardedPoints)
                })
                .ToListAsync();

            var result = new List<int>();
            for (int i = monthsBack - 1; i >= 0; i--)
            {
                var dt = DateTime.UtcNow.AddMonths(-i);
                var bucket = data.FirstOrDefault(d => d.Year == dt.Year && d.Month == dt.Month);
                result.Add(bucket?.Points ?? 0);
            }
            return result;
        }

        public async Task<int> GetCompletedModulesCountAsync(int userId, int languageId)
        {
            var lessons = await _context.Lessons
                .Where(l => l.LanguageId == languageId)
                .Select(l => new { l.Id, Level = l.Level })
                .ToListAsync();

            if (!lessons.Any())
                return 0;

            int totalCompletedModules = 0;

            foreach (var lesson in lessons)
            {
                int completedInThisLesson = 0;

                var quizEntry = await _context.QuizResults
                    .Where(r => r.UserId == userId && r.LessonId == lesson.Id)
                    .Select(r => r.Score)
                    .FirstOrDefaultAsync();
                if (quizEntry > 0) completedInThisLesson++;

                var readingEntry = await _context.ReadingResults
                    .Where(r => r.UserId == userId && r.LessonId == lesson.Id)
                    .Select(r => r.ComprehensionScore)
                    .FirstOrDefaultAsync();
                if (readingEntry > 0) completedInThisLesson++;

                var speakingEntry = await _context.SpeakingResults
                    .Where(r => r.UserId == userId && r.LessonId == lesson.Id)
                    .Select(r => r.AverageAccuracy)
                    .FirstOrDefaultAsync();
                if (speakingEntry > 0) completedInThisLesson++;

                totalCompletedModules += completedInThisLesson;
            }

            return totalCompletedModules;
        }

        public async Task<int> GetPointsForLanguageAsync(int userId, int languageId)
        {
            var sum = await _context.UsersToLessons
                .Where(utl => utl.UserId == userId
                           && utl.PointsAwarded
                           && _context.Lessons.Any(l => l.Id == utl.LessonId && l.LanguageId == languageId))
                .SumAsync(utl => utl.AwardedPoints);
            return sum;
        }

        public async Task<int> GetTotalPointsAsync(int userId)
        {
            var userLessons = await _context.Lessons
                .Select(l => new { l.Id, l.LanguageId, l.Level })
                .ToListAsync();

            var byLanguage = userLessons.GroupBy(l => l.LanguageId);

            int total = 0;

            foreach (var group in byLanguage)
            {
                int languageId = group.Key;
                foreach (var lesson in group)
                {
                    bool hasAny =
                        await _context.QuizResults.AnyAsync(r => r.UserId == userId && r.LessonId == lesson.Id && r.Score > 0)
                        || await _context.ReadingResults.AnyAsync(r => r.UserId == userId && r.LessonId == lesson.Id && r.ComprehensionScore > 0)
                        || await _context.SpeakingResults.AnyAsync(r => r.UserId == userId && r.LessonId == lesson.Id && r.AverageAccuracy > 0);

                    if (hasAny) total += (int)lesson.Level;
                }
            }

            return total;
        }

        public async Task<List<int>> GetMonthlyPointsForLanguageAsync(int userId, int languageId)
        {
            var lessons = await _context.Lessons
                .Where(l => l.LanguageId == languageId)
                .ToListAsync();

            var now = DateTime.UtcNow;
            var months = Enumerable.Range(0, 6)
                .Select(offset => new
                {
                    Year = now.AddMonths(-offset).Year,
                    Month = now.AddMonths(-offset).Month
                })
                .Reverse() 
                .ToList();

            var result = new List<int>(new int[6]);

            for (int i = 0; i < months.Count; i++)
            {
                int year = months[i].Year;
                int month = months[i].Month;

                int pointsInMonth = 0;

                foreach (var lesson in lessons)
                {
                    var quizEntry = await _context.QuizResults
                        .Where(r => r.UserId == userId && r.LessonId == lesson.Id
                            && r.CreatedAt.Year == year && r.CreatedAt.Month == month
                            && r.Score > 0)
                        .AnyAsync();
                    var readingEntry = await _context.ReadingResults
                        .Where(r => r.UserId == userId && r.LessonId == lesson.Id
                            && r.CreatedAt.Year == year && r.CreatedAt.Month == month
                            && r.ComprehensionScore > 0)
                        .AnyAsync();
                    var speakingEntry = await _context.SpeakingResults
                        .Where(r => r.UserId == userId && r.LessonId == lesson.Id
                            && r.CreatedAt.Year == year && r.CreatedAt.Month == month
                            && r.AverageAccuracy > 0)
                        .AnyAsync();

                    if (quizEntry || readingEntry || speakingEntry)
                    {
                        pointsInMonth += (int)lesson.Level;
                    }
                }

                result[i] = pointsInMonth;
            }

            return result;
        }

       
        public async Task<List<int>> GetMonthlyTotalPointsAsync(int userId)
        {
            var allLessons = await _context.Lessons.ToListAsync();

            var now = DateTime.UtcNow;
            var months = Enumerable.Range(0, 6)
                .Select(offset => new
                {
                    Year = now.AddMonths(-offset).Year,
                    Month = now.AddMonths(-offset).Month
                })
                .Reverse()
                .ToList();

            var result = new List<int>(new int[6]);

            for (int i = 0; i < months.Count; i++)
            {
                int year = months[i].Year;
                int month = months[i].Month;

                int pointsInMonth = 0;

                foreach (var lesson in allLessons)
                {
                    var quizEntry = await _context.QuizResults
                        .Where(r => r.UserId == userId && r.LessonId == lesson.Id
                            && r.CreatedAt.Year == year && r.CreatedAt.Month == month
                            && r.Score > 0)
                        .AnyAsync();
                    var readingEntry = await _context.ReadingResults
                        .Where(r => r.UserId == userId && r.LessonId == lesson.Id
                            && r.CreatedAt.Year == year && r.CreatedAt.Month == month
                            && r.ComprehensionScore > 0)
                        .AnyAsync();
                    var speakingEntry = await _context.SpeakingResults
                        .Where(r => r.UserId == userId && r.LessonId == lesson.Id
                            && r.CreatedAt.Year == year && r.CreatedAt.Month == month
                            && r.AverageAccuracy > 0)
                        .AnyAsync();

                    if (quizEntry || readingEntry || speakingEntry)
                    {
                        pointsInMonth += (int)lesson.Level;
                    }
                }

                result[i] = pointsInMonth;
            }

            return result;
        }

        public async Task<decimal> GetLessonCompletionPercentAsync(int userId, int lessonId)
        {
            int cnt = 0;

            if (await _context.QuizResults.AnyAsync(r => r.UserId == userId && r.LessonId == lessonId && r.Score > 0))
                cnt++;
            if (await _context.ReadingResults.AnyAsync(r => r.UserId == userId && r.LessonId == lessonId && r.ComprehensionScore > 0))
                cnt++;
            if (await _context.SpeakingResults.AnyAsync(r => r.UserId == userId && r.LessonId == lessonId && r.AverageAccuracy > 0))
                cnt++;

            return Math.Round((decimal)cnt / 3 * 100, 2);
        }

        public async Task<decimal> GetCompletedLessonsPercentAsync(int userId, int languageId)
        {
            var totalLessons = await _context.Lessons
                .CountAsync(l => l.LanguageId == languageId);

            if (totalLessons == 0)
                return 0m;

            var completedLessons = await _context.UsersToLessons
                .Where(utl => utl.UserId == userId
                           && utl.QuizCompleted
                           && utl.ReadingCompleted
                           && utl.SpeakingCompleted
                           && _context.Lessons.Any(l => l.Id == utl.LessonId && l.LanguageId == languageId))
                .Select(utl => utl.LessonId)
                .Distinct()
                .CountAsync();

            var percent = Math.Round((decimal)completedLessons / totalLessons * 100m, 2);
            return percent;
        }

        public async Task<decimal> GetOverallLessonsPercentAsync(int userId)
        {
            var totalLessons = await _context.Lessons.CountAsync();

            if (totalLessons == 0)
                return 0m;

            var completedLessons = await _context.UsersToLessons
                .Where(utl => utl.UserId == userId
                           && utl.QuizCompleted
                           && utl.ReadingCompleted
                           && utl.SpeakingCompleted
                           && _context.Lessons.Any(l => l.Id == utl.LessonId))
                .Select(utl => utl.LessonId)
                .Distinct()
                .CountAsync();

            var percent = Math.Round((decimal)completedLessons / totalLessons * 100m, 2);
            return percent;
        }
    }
}
