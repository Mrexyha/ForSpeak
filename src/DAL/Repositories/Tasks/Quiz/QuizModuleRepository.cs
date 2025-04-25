using DAL.Entities.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Tasks.Quiz
{
    public class QuizModuleRepository : IQuizModuleRepository
    {
        private readonly AppDbContext _context;
        public QuizModuleRepository(AppDbContext context) => _context = context;

        public async Task<QuizModuleEntity> GetByLessonIdAsync(int lessonId)
        {
            return await _context.Set<QuizModuleEntity>()
                .Include(qm => qm.Questions)
                .FirstOrDefaultAsync(qm => qm.LessonId == lessonId);
        }

        public async Task AddAsync(QuizModuleEntity entity)
        {
            await _context.Set<QuizModuleEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(QuizModuleEntity entity)
        {
            _context.Set<QuizModuleEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int lessonId)
        {
            var module = await GetByLessonIdAsync(lessonId);
            if (module != null)
            {
                _context.Set<QuizModuleEntity>().Remove(module);
                await _context.SaveChangesAsync();
            }
        }
    }
}
