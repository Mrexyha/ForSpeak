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

        public async Task<List<string>> GetAllLanguagesAsync()
        {
            return await _context.Languages.Select(l => l.Name).ToListAsync();
        }
    }
}
