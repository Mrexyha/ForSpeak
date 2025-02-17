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

        public LanguageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageEntity>> GetAllLanguagesAsync()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task<LanguageEntity> GetByIdAsync(int id)
        {
            return await _context.Languages.FindAsync(id);
        }

        public async Task AddLanguageAsync(LanguageEntity language)
        {
            _context.Languages.Add(language);
            await _context.SaveChangesAsync();
        }
    }
}
