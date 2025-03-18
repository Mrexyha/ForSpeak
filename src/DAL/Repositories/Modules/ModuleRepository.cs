using DAL.Entities.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Modules
{
    public class ModuleRepository : BaseRepository<ModuleEntity>, IModuleRepository
    {
        private readonly AppDbContext _context;

        public ModuleRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ModuleEntity>> GetModulesByLessonIdAsync(int lessonId)
        {
            return await _context.Set<ModuleEntity>()
                .Where(m => m.LessonId == lessonId)
                .Include(m => m.Tasks)
                .ToListAsync();
        }
    }
}
