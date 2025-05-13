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
            var cutoff = DateTime.UtcNow.AddMonths(-monthsBack);
            // Припускаємо, що у UsersToLessons є поле DateCompleted
            var data = await _context.UsersToLessons
                .Where(u => u.UserId == userId
                         && u.Lesson.LanguageId == languageId
                         && u.DateCompleted >= cutoff
                         && u.PointsAwarded)
                .GroupBy(u => new { u.DateCompleted.Year, u.DateCompleted.Month })
                .Select(g => new {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Points = g.Sum(x => x.AwardedPoints)
                })
                .ToListAsync();

            // Формуємо список за останні monthsBack місяців
            var result = new List<int>();
            for (int i = monthsBack - 1; i >= 0; i--)
            {
                var dt = DateTime.UtcNow.AddMonths(-i);
                var bucket = data.FirstOrDefault(d => d.Year == dt.Year && d.Month == dt.Month);
                result.Add(bucket?.Points ?? 0);
            }
            return result;
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
    }
}