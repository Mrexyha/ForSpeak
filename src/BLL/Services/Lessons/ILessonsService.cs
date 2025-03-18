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

        public Task<LessonEntity> AddLessonAsync(LessonEntity lesson);
        public Task<LessonEntity> UpdateLessonAsync(LessonEntity lesson);
        public Task<int> GetUserPoints(int userId);
    }
}
