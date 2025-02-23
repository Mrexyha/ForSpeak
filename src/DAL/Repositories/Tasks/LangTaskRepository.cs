using DAL.Entities.Enums;
using DAL.Entities.Lessons;
using DAL.Repositories.Lessons;
using DLL;
using DLL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Tasks;
public class LangTaskRepository : BaseRepository<LangTask>, ILangTaskRepository
{
    public LangTaskRepository(IDbContextFactory<ApplicationContext> contextFactory)
        : base(contextFactory) { }

    public async Task<IEnumerable<LangTask>> GetQuizTasks()
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Set<LangTask>().Where(t => t.Type == TaskType.Quiz).ToListAsync();
        }
    }

    public async Task<IEnumerable<LangTask>> GetListeningTasks()
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Set<LangTask>().Where(t => t.Type == TaskType.Listening).ToListAsync();
        }
    }

    public async Task<IEnumerable<LangTask>> GetReadingTasks()
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Set<LangTask>().Where(t => t.Type == TaskType.Reading).ToListAsync();
        }
    }

    public async Task<IEnumerable<LangTask>> GetTheory()
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Set<LangTask>().Where(t => t.Type == TaskType.Theory).ToListAsync();
        }
    }

    public async Task<IEnumerable<LangTask>> GetVocabularyTasks()
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Set<LangTask>().Where(t => t.Type == TaskType.Vocabulary).ToListAsync();
        }
    }
}
