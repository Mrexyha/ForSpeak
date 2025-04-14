using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Lessons;
using DAL.Entities.Lessons;

namespace BLL.Services.Lessons
{
    public interface ILessonsService
    {
        Task<IEnumerable<LessonModel>> GetLessonsByLanguageIdAsync(int languageId);
        Task<LessonModel> GetLessonByLanguageAndIdAsync(int languageId, int lessonId);

        Task<LessonEntity> AddLessonAsync(LessonEntity lesson);
        Task<LessonEntity?> UpdateLessonAsync(int languageId, int lessonId, LessonModel lessonModel);
        Task<bool> DeleteLessonAsync(int languageId, int lessonId);
        Task<int> GetUserPoints(int userId);
    }
}
