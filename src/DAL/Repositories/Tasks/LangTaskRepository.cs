using DAL.Entities.Enums;
using DAL.Entities.Lessons;
using DAL.Repositories.Lessons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Tasks
{
    public class LangTaskRepository : BaseRepository<TaskLangEntity>, ILangTaskRepository
    {
        public LangTaskRepository(IDbContextFactory<AppDbContext> contextFactory)
            : base(contextFactory) { }

        public async Task<IEnumerable<TaskLangEntity>> GetQuizTasks()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<TaskLangEntity>().Where(t => t.Type == TaskType.Quiz).ToListAsync();
            }
        }

        public async Task<IEnumerable<TaskLangEntity>> GetListeningTasks()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<TaskLangEntity>().Where(t => t.Type == TaskType.Listening).ToListAsync();
            }
        }

        public async Task<IEnumerable<TaskLangEntity>> GetReadingTasks()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<TaskLangEntity>().Where(t => t.Type == TaskType.Reading).ToListAsync();
            }
        }

        public async Task<IEnumerable<TaskLangEntity>> GetTheory()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<TaskLangEntity>().Where(t => t.Type == TaskType.Theory).ToListAsync();
            }
        }

        public async Task<IEnumerable<TaskLangEntity>> GetVocabularyTasks()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<TaskLangEntity>().Where(t => t.Type == TaskType.Vocabulary).ToListAsync();
            }
        }
    }
}
