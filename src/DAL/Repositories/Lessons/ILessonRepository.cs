using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Lessons;

namespace DAL.Repositories.Lessons
{
    public interface ILessonRepository : IBaseRepository<LessonEntity>
    {
        Task<IEnumerable<LessonEntity>> GetLessonsByLanguageIdAsync(int languageId);
        Task<LessonEntity?> GetLessonByLanguageAndIdAsync(int languageId, int lessonId);
        Task<bool> DeleteLessonByLanguageAndIdAsync(int languageId, int lessonId);
        Task<int> GetUserPointsAsync(int userId);
    }
}
