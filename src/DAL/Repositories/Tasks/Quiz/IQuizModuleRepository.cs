using DAL.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Tasks.Quiz
{
    public interface IQuizModuleRepository
    {
        Task<QuizModuleEntity> GetByLessonIdAsync(int lessonId);
        Task AddAsync(QuizModuleEntity entity);
        Task UpdateAsync(QuizModuleEntity entity);
        Task DeleteAsync(int lessonId);
    }
}
