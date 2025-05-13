using System.Threading.Tasks;
using DAL.Entities.Enums;

namespace BLL.Services.Progress
{
    public interface IUserLessonProgressService
    {
        Task RegisterModuleCompletion(int userId, int lessonId, TaskLangType moduleType);
        Task<int> GetPointsForLanguage(int userId, int languageId);
        Task<int> GetTotalPoints(int userId);

        Task<List<int>> GetMonthlyPointsForLanguage(int userId, int languageId, int monthsBack = 6);
        Task<List<int>> GetMonthlyTotalPoints(int userId, int monthsBack = 6);
    }
}
