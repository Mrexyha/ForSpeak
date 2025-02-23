using DAL.Entities.Lessons;
using DLL;
using DLL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Lessons;
public class LangTaskRepository : BaseRepository<Lesson>, ILessonRepository
{
    public LangTaskRepository(IDbContextFactory<ApplicationContext> contextFactory)
        : base(contextFactory) { }

    public override async Task<IEnumerable<Lesson>> GetAllAsync()
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Set<Lesson>().Include(l => l.Tasks).ToListAsync();
        }
    }

    public override async Task<Lesson?> GetByIdAsync(int id)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Set<Lesson>().Include(l => l.Tasks).FirstOrDefaultAsync(x => x.Id == id);
        }
    }

    public async Task<int> GetUserPointsAsync(int userId)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Set<Lesson>()
                .Where(l => l.UsersToLessons.UserId == userId)
                .SelectMany(l => l.Tasks)
                .SumAsync(t => (int)t.TaskLevel);
        }
    }
}
