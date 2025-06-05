using DAL.Entities.Languages;
using DAL.Repositories.Languages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly AppDbContext _context;
        public LanguageRepository(AppDbContext context) => _context = context;

        public async Task<List<LanguageEntity>> GetAllLanguagesAsync()
        {
            return await _context.Languages
                .Include(l => l.Lessons)
                    .ThenInclude(le => le.Modules)
                .Include(l => l.Lessons)
                    .ThenInclude(le => le.Theory)
                .Include(l => l.Lessons)
                    .ThenInclude(le => le.Vocabulary)
                        .ThenInclude(vm => vm.Words)
                .Include(l => l.Lessons)
                    .ThenInclude(le => le.Quiz)
                        .ThenInclude(qm => qm.Questions)
                .Include(l => l.Lessons)
                    .ThenInclude(le => le.Reading)
                        .ThenInclude(rm => rm.Tasks)
                .Include(l => l.Lessons)
                    .ThenInclude(le => le.Speaking)
                        .ThenInclude(sm => sm.Phrases)
                .ToListAsync();
        }

        public async Task<LanguageEntity?> GetByIdAsync(int id)
        {
            return await _context.Languages
                .Include(l => l.Lessons)
                    .ThenInclude(le => le.Modules)
                .Include(l => l.Lessons)
                    .ThenInclude(le => le.Theory)
                .Include(l => l.Lessons)
                    .ThenInclude(le => le.Vocabulary)
                        .ThenInclude(vm => vm.Words)
                .Include(l => l.Lessons)
                    .ThenInclude(le => le.Quiz)
                        .ThenInclude(q => q.Questions)
                .Include(l => l.Lessons)
                    .ThenInclude(le => le.Reading)
                        .ThenInclude(rm => rm.Tasks)
                .Include(l => l.Lessons)
                    .ThenInclude(le => le.Speaking)
                        .ThenInclude(sm => sm.Phrases)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task UpdateLanguageAsync(LanguageEntity language)
        {
            _context.Languages.Update(language);
            await _context.SaveChangesAsync();
        }
    }
}
