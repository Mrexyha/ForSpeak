using DAL.Entities.Lessons;
using DLL.Repositories;

namespace DAL.Repositories.Lessons;
public interface ILangTaskRepository : IBaseRepository<LangTask>
{
    public Task<IEnumerable<LangTask>> GetVocabularyTasks();
    public Task<IEnumerable<LangTask>> GetReadingTasks();
    public Task<IEnumerable<LangTask>> GetQuizTasks();
    public Task<IEnumerable<LangTask>> GetListeningTasks();
    public Task<IEnumerable<LangTask>> GetTheory();
}
