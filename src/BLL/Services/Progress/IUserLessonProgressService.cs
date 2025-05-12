using System.Threading.Tasks;
using DAL.Entities.Enums;

namespace BLL.Services.Progress
{
    public interface IUserLessonProgressService
    {
        Task RegisterModuleCompletion(int userId, int lessonId, TaskLangType moduleType);
        Task<int> GetPointsForLanguage(int userId, int languageId);
        Task<int> GetTotalPoints(int userId);
    }
}
