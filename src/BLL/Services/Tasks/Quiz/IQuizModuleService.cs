using BLL.Models.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Tasks.Quiz
{
    public interface IQuizModuleService
    {
        Task<QuizModuleModel> GetByLessonIdAsync(int lessonId);
        Task AddAsync(int lessonId, QuizModuleModel model);
        Task UpdateAsync(int lessonId, QuizModuleModel model);
        Task DeleteAsync(int lessonId);

        Task<double> RecalculateScore(int lessonId);
        Task UpdateAverageAsync(int lessonId, double average);
        Task<double?> GetScoreAsync(int lessonId, int userId);
        Task UpdateUserResultAsync(int lessonId, int userId, double score);
        Task SaveUserResultAsync(int userId, int lessonId, double score);
    }
}
