using BLL.Models.Lessons;
using BLL.Models.Modules;
using DAL.Entities.Lessons;
using DAL.Repositories.Lessons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Lessons
{
    public class LessonsService : ILessonsService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonsService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<LessonEntity> AddLessonAsync(LessonEntity lesson)
        {
            await _lessonRepository.AddAsync(lesson);

            return lesson;
        }

        public async Task<IEnumerable<LessonEntity>> GetAllLessonsAsync()
        {
            var lessons = await _lessonRepository.GetAllAsync();

            return lessons;
        }

        public async Task<IEnumerable<LessonModel>> GetLessonsByLanguageIdAsync(int languageId)
        {
            var lessons = await _lessonRepository.GetLessonsByLanguageIdAsync(languageId);
            return lessons.Select(l => new LessonModel
            {
                Id = l.Id,
                LanguageId = l.LanguageId,
                Title = l.Title,
                Theory = l.Theory,
                ImageUrl = l.ImageUrl,
                Modules = l.Modules.Select(m => new ModuleModel
                {
                    Id = m.Id,
                    LessonId = m.LessonId,
                    Title = m.Title,
                    Type = m.Type,
                }).ToList()
            });
        }

        public async Task<LessonEntity> GetLessonAsync(int lessonId)
        {
            var lesson = await _lessonRepository.GetByIdAsync(lessonId);

            return lesson;
        }

        public async Task<int> GetUserPoints(int userId)
        {
            var points = await _lessonRepository.GetUserPointsAsync(userId);

            return points;
        }

        public async Task<LessonEntity> UpdateLessonAsync(LessonEntity lesson)
        {
            await _lessonRepository.UpdateAsync(lesson);

            return lesson; throw new NotImplementedException();
        }
    }
}
