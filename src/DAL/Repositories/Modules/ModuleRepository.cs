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
        public ModuleRepository(IDbContextFactory<AppDbContext> contextFactory)
            : base(contextFactory)
        {
        }

        public async Task<IEnumerable<ModuleEntity>> GetModulesByLessonIdAsync(int lessonId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<ModuleEntity>()
                    .Where(m => m.LessonId == lessonId)
                    .Include(m => m.Tasks) 
                    .ToListAsync();
            }
        }
    }
}
