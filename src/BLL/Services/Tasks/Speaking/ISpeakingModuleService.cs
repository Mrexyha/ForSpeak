using BLL.Models.Modules;
using BLL.Models.Tasks;
using DAL.Entities.Modules;
using DAL.Entities.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Tasks.Speaking
{
    public interface ISpeakingModuleService
    {
        Task<SpeakingModuleModel> GetByLessonIdAsync(int lessonId);
        Task<SpeakingPhraseModel> AddPhraseAsync(int lessonId, SpeakingPhraseModel newPhrase);
        Task UpdateAverageAsync(int lessonId, double newAverage);
        Task DeletePhraseAsync(int phraseId);

        Task<double> RecalculateAverageAccuracyAsync(int lessonId);
    }
}
