using DAL.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Tasks.Vocabulary
{
    public interface IVocabularyModuleRepository
    {
        Task<VocabularyModuleEntity> GetByLessonIdAsync(int lessonId);
        Task AddAsync(VocabularyModuleEntity entity);
        Task UpdateAsync(VocabularyModuleEntity entity);
        Task DeleteAsync(int lessonId);
    }
}
