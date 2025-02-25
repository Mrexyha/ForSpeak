using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Lessons;

namespace BLL.Services.Lessons
{
    public interface ILessonsService
    {
        public Task<IEnumerable<LessonEntity>> GetAllLessonsAsync();
        public Task<LessonEntity> GetLessonAsync(int lessonId);
        public Task<LessonEntity> AddLessonAsync(LessonEntity lesson);
        public Task<LessonEntity> UpdateLessonAsync(LessonEntity lesson);
        public Task<int> GetUserPoints(int userId);
    }
}
