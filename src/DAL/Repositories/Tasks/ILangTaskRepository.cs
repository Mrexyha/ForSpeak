using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Lessons;

namespace DAL.Repositories.Tasks
{
    public interface ILangTaskRepository : IBaseRepository<TaskLangEntity>
    {
        public Task<IEnumerable<TaskLangEntity>> GetVocabularyTasks();
        public Task<IEnumerable<TaskLangEntity>> GetReadingTasks();
        public Task<IEnumerable<TaskLangEntity>> GetQuizTasks();
        public Task<IEnumerable<TaskLangEntity>> GetListeningTasks();
        public Task<IEnumerable<TaskLangEntity>> GetTheory();
    }
}
