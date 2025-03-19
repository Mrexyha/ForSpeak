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
        public LangTaskRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TaskLangEntity>> GetQuizTasks()
        {
            return await _context.Set<TaskLangEntity>()
                .Where(t => t.Type == TaskLangType.Quiz)
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskLangEntity>> GetListeningTasks()
        {
            return await _context.Set<TaskLangEntity>()
                .Where(t => t.Type == TaskLangType.Listening)
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskLangEntity>> GetReadingTasks()
        {
            return await _context.Set<TaskLangEntity>()
                .Where(t => t.Type == TaskLangType.Reading)
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskLangEntity>> GetTheory()
        {
            return await _context.Set<TaskLangEntity>()
                .Where(t => t.Type == TaskLangType.Theory)
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskLangEntity>> GetVocabularyTasks()
        {
            return await _context.Set<TaskLangEntity>()
                .Where(t => t.Type == TaskLangType.Vocabulary)
                .ToListAsync();
        }
    }
}
