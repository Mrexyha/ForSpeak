using BLL.Models.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Tasks.Vocabulary
{
    public interface IVocabularyModuleService
    {
        Task<VocabularyModuleModel> GetByLessonIdAsync(int lessonId);
        Task AddAsync(int lessonId, VocabularyModuleModel model);
        Task UpdateAsync(int lessonId, VocabularyModuleModel model);
        Task DeleteAsync(int lessonId);
    }
}
