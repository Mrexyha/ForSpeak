using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Lessons;

namespace DAL.Repositories.Lessons
{
    public class LessonRepository : BaseRepository<LessonEntity>, ILessonRepository
    {
        private readonly AppDbContext _context;

        public LessonRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LessonEntity>> GetLessonsByLanguageIdAsync(int languageId)
        {
            return await _context.Set<LessonEntity>()
         .Include(l => l.Modules).ThenInclude(m => m.Tasks)
         .Include(l => l.Theory)
         .Include(l => l.Vocabulary).ThenInclude(v => v.Words)
         .Include(l => l.Quiz).ThenInclude(q => q.Questions)
         .Include(l => l.Reading).ThenInclude(r => r.Tasks)
         .Include(l => l.Speaking).ThenInclude(s => s.Phrases)
         .Where(l => l.LanguageId == languageId)
         .ToListAsync();
        }

        public async Task<LessonEntity?> GetLessonByLanguageAndIdAsync(int languageId, int lessonId)
        {
            return await _context.Set<LessonEntity>()
                .Include(l => l.Modules).ThenInclude(m => m.Tasks)
                .Include(l => l.Theory)
                .Include(l => l.Vocabulary).ThenInclude(v => v.Words)
                .Include(l => l.Quiz).ThenInclude(q => q.Questions)
                .Include(l => l.Reading).ThenInclude(r => r.Tasks)
                .Include(l => l.Speaking).ThenInclude(s => s.Phrases)
                .FirstOrDefaultAsync(l => l.LanguageId == languageId && l.Id == lessonId);
        }

        public async Task<bool> DeleteLessonByLanguageAndIdAsync(int languageId, int lessonId)
        {
            var lesson = await _context.Set<LessonEntity>()
                .FirstOrDefaultAsync(l => l.LanguageId == languageId && l.Id == lessonId);
            if (lesson == null) return false;
            _context.Set<LessonEntity>().Remove(lesson);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetUserPointsAsync(int userId)
        {
            return await _context.Set<LessonEntity>()
                .Where(l => l.UsersToLessons.Any(utl => utl.UserId == userId))
                .SumAsync(t => (int)t.Level);
        }
    }
}
