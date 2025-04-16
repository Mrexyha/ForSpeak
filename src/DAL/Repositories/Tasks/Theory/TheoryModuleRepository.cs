using DAL.Entities.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Tasks.Theory
{
    public class TheoryModuleRepository : ITheoryModuleRepository
    {
        private readonly AppDbContext _context;

        public TheoryModuleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TheoryModuleEntity?> GetByLessonIdAsync(int lessonId)
        {
            return await _context.TheoryModules
                                 .FirstOrDefaultAsync(t => t.LessonId == lessonId);
        }

        public async Task AddAsync(TheoryModuleEntity module)
        {
            await _context.TheoryModules.AddAsync(module);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TheoryModuleEntity module)
        {
            _context.TheoryModules.Update(module);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int lessonId)
        {
            var module = await GetByLessonIdAsync(lessonId);
            if (module != null)
            {
                _context.TheoryModules.Remove(module);
                await _context.SaveChangesAsync();
            }
        }
    }
}
