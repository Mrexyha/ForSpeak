using DAL.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Modules
{
    public interface IModuleRepository
    {

        Task<TheoryModuleEntity> GetTheoryByLessonIdAsync(int lessonId);
        Task SaveTheoryAsync(TheoryModuleEntity entity);

        Task<VocabularyModuleEntity> GetVocabularyByLessonIdAsync(int lessonId);
        Task SaveVocabularyAsync(VocabularyModuleEntity entity);

        Task<QuizModuleEntity> GetQuizByLessonIdAsync(int lessonId);
        Task SaveQuizAsync(QuizModuleEntity entity);

        Task<ReadingModuleEntity> GetReadingByLessonIdAsync(int lessonId);
        Task SaveReadingAsync(ReadingModuleEntity entity);

        Task<SpeakingModuleEntity> GetSpeakingByLessonIdAsync(int lessonId);
        Task SaveSpeakingAsync(SpeakingModuleEntity entity);

        Task<bool> DeleteModuleAsync(int lessonId, int moduleId);
    }
}
