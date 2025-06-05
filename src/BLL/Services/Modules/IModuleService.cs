using BLL.Models.Modules;
using DAL.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Modules
{
    public interface IModuleService
    {
        Task<TheoryModuleModel> CreateOrUpdateTheoryAsync(int lessonId, TheoryModuleModel model);
        Task<VocabularyModuleModel> CreateOrUpdateVocabularyAsync(int lessonId, VocabularyModuleModel model);
        Task<QuizModuleModel> CreateOrUpdateQuizAsync(int lessonId, QuizModuleModel model);
        Task<ReadingModuleModel> CreateOrUpdateReadingAsync(int lessonId, ReadingModuleModel model);
        Task<SpeakingModuleModel> CreateOrUpdateSpeakingAsync(int lessonId, SpeakingModuleModel model);
        Task<bool> DeleteModuleAsync(int lessonId, int moduleId);
    }
}
