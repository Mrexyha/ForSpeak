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
    }
}
