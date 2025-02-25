using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Lessons;

namespace DAL.Repositories.Lessons
{
    public class LangTaskRepository : BaseRepository<LessonEntity>, ILessonRepository
    {
        public LangTaskRepository(IDbContextFactory<AppDbContext> contextFactory)
            : base(contextFactory) { }

        public override async Task<IEnumerable<LessonEntity>> GetAllAsync()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<LessonEntity>().Include(l => l.Tasks).ToListAsync();
            }
        }

        public override async Task<LessonEntity?> GetByIdAsync(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<LessonEntity>().Include(l => l.Tasks).FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<int> GetUserPointsAsync(int userId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<LessonEntity>()
                    .Where(l => l.UsersToLessons.UserId == userId)
                    .SelectMany(l => l.Tasks)
                    .SumAsync(t => (int)t.TaskLevel);
            }
        }
    }
}
