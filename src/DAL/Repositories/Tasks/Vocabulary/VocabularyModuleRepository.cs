using DAL.Entities.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Tasks.Vocabulary
{
    public class VocabularyModuleRepository : IVocabularyModuleRepository
    {
        private readonly AppDbContext _context;
        public VocabularyModuleRepository(AppDbContext context) => _context = context;

        public async Task<VocabularyModuleEntity> GetByLessonIdAsync(int lessonId)
        {
            return await _context.VocabularyModules
                .Include(vm => vm.Words)
                .FirstOrDefaultAsync(vm => vm.LessonId == lessonId);
        }

        public async Task AddAsync(VocabularyModuleEntity entity)
        {
            await _context.VocabularyModules.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VocabularyModuleEntity entity)
        {
            _context.VocabularyModules.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int lessonId)
        {
            var module = await GetByLessonIdAsync(lessonId);
            if (module != null)
            {
                _context.VocabularyModules.Remove(module);
                await _context.SaveChangesAsync();
            }
        }
    }
}
