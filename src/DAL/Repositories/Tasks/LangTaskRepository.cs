using DAL.Entities.Enums;
using DAL.Entities.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.Tasks
{
    public class LangTaskRepository : BaseRepository<TaskLangEntity>, ILangTaskRepository
    {
        public LangTaskRepository(IDbContextFactory<AppDbContext> contextFactory)
            : base(contextFactory)
        {
        }

        public async Task<IEnumerable<TaskLangEntity>> GetQuizTasks()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<TaskLangEntity>().Where(t => t.Type == LessonType.Quiz).ToListAsync();
            }
        }

        public async Task<IEnumerable<TaskLangEntity>> GetListeningTasks()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<TaskLangEntity>().Where(t => t.Type == LessonType.Listening).ToListAsync();
            }
        }

        public async Task<IEnumerable<TaskLangEntity>> GetReadingTasks()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<TaskLangEntity>() .Where(t => t.Type == LessonType.Reading).ToListAsync();
            }
        }

        public async Task<IEnumerable<TaskLangEntity>> GetTheory()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<TaskLangEntity>().Where(t => t.Type == LessonType.Theory).ToListAsync();
            }
        }

        public async Task<IEnumerable<TaskLangEntity>> GetVocabularyTasks()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<TaskLangEntity>().Where(t => t.Type == LessonType.Vocabulary).ToListAsync();
            }
        }
    }
}
