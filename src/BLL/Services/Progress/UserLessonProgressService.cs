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
                ?? new UsersToLessons
                {
                    UserId = userId,
                    LessonId = lessonId
                };

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
                int points = (int)lesson.Level;

                prog.AwardedPoints = points;
                prog.PointsAwarded = true;
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
    }
}