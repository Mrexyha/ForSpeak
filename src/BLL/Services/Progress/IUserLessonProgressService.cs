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

        Task<int> GetCompletedModulesCountAsync(int userId, int languageId);
        Task<int> GetPointsForLanguageAsync(int userId, int languageId);
        Task<int> GetTotalPointsAsync(int userId);
        Task<List<int>> GetMonthlyPointsForLanguageAsync(int userId, int languageId);
        Task<List<int>> GetMonthlyTotalPointsAsync(int userId);
        Task<decimal> GetLessonCompletionPercentAsync(int userId, int lessonId);
        Task<decimal> GetCompletedLessonsPercentAsync(int userId, int languageId);
        Task<decimal> GetOverallLessonsPercentAsync(int userId);
    }
}
