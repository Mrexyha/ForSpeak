using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Tasks;

namespace DAL.Repositories.Tasks
{
    public interface ILangTaskRepository : IBaseRepository<TaskLangEntity>
    {
        public Task<IEnumerable<TaskLangEntity>> GetVocabularyTasks();
        public Task<IEnumerable<TaskLangEntity>> GetReadingTasks();
        public Task<IEnumerable<TaskLangEntity>> GetQuizTasks();
        public Task<IEnumerable<TaskLangEntity>> GetSpeakingTasks();
        public Task<IEnumerable<TaskLangEntity>> GetTheory();
    }
}
