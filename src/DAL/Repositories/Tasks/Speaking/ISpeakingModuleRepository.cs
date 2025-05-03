using DAL.Entities.Modules;
using DAL.Entities.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Tasks.Speaking
{
    public interface ISpeakingModuleRepository
    {
        Task<SpeakingModuleEntity?> GetByLessonIdAsync(int lessonId);
        Task UpdateAsync(SpeakingModuleEntity entity);
        Task AddPhraseAsync(int lessonId, SpeakingPhraseEntity phrase);
        Task DeletePhraseAsync(int phraseId);
    }
}
