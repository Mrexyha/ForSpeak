using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BaseRepository<LangTask> : IBaseRepository<LangTask> where LangTask : BaseEntity
    {
        protected readonly IDbContextFactory<AppDbContext> _contextFactory;

        public BaseRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public virtual async Task<IEnumerable<LangTask>> GetAllAsync()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<LangTask>().ToListAsync();
            }
        }

        public virtual async Task<LangTask?> GetByIdAsync(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<LangTask>().FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public virtual async Task<LangTask> AddAsync(LangTask entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                await context.Set<LangTask>().AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public virtual async Task<LangTask> UpdateAsync(LangTask entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Set<LangTask>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public virtual async Task<bool> UpdateRangeAsync(IEnumerable<LangTask> list)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Set<LangTask>().UpdateRange(list);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task SaveChangesAsync()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
