using DAL.Entities.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Tasks.Reading
{

    public class ReadingModuleRepository : IReadingModuleRepository
    {
        private readonly AppDbContext _context;
        public ReadingModuleRepository(AppDbContext context) => _context = context;

        public async Task<ReadingModuleEntity> GetByLessonIdAsync(int lessonId)
        {
            return await _context.Set<ReadingModuleEntity>()
                .Include(rm => rm.Tasks)
                .FirstOrDefaultAsync(rm => rm.LessonId == lessonId);
        }

        public async Task AddAsync(ReadingModuleEntity entity)
        {
            await _context.Set<ReadingModuleEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ReadingModuleEntity entity)
        {
            _context.Set<ReadingModuleEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int lessonId)
        {
            var mod = await GetByLessonIdAsync(lessonId);
            if (mod != null)
            {
                _context.Set<ReadingModuleEntity>().Remove(mod);
                await _context.SaveChangesAsync();
            }
        }
    }
}
