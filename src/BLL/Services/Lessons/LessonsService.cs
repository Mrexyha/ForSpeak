using AutoMapper;
using BLL.Models.Lessons;
using BLL.Models.Modules;
using DAL.Entities.Lessons;
using DAL.Entities.Modules;
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
        private readonly IMapper _mapper;

        public LessonsService(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LessonModel>> GetLessonsByLanguageIdAsync(int languageId)
        {
            var lessons = await _lessonRepository.GetLessonsByLanguageIdAsync(languageId);
            return lessons.Select(l => new LessonModel
            {
                Id = l.Id,
                LanguageId = l.LanguageId,
                Title = l.Title,
                ImageUrl = l.ImageUrl,
                Level = l.Level,
                Modules = l.Modules.Select(m => new ModuleModel
                {
                    Id = m.Id,
                    LessonId = m.LessonId,
                    Title = m.Title,
                    Type = m.Type,
                }).ToList()
            });
        }

        public async Task<LessonModel> GetLessonByLanguageAndIdAsync(int languageId, int lessonId)
        {
            var lessonEntity = await _lessonRepository.GetLessonByLanguageAndIdAsync(languageId, lessonId);
            if (lessonEntity == null) return null;

            return new LessonModel
            {
                Id = lessonEntity.Id,
                LanguageId = lessonEntity.LanguageId,
                LanguageName = lessonEntity.LanguageName,
                Title = lessonEntity.Title,
                ImageUrl = lessonEntity.ImageUrl,
                Level = lessonEntity.Level,

                Modules = lessonEntity.Modules
                    .Select(m => new ModuleModel
                    {
                        Id = m.Id,
                        Title = m.Title,
                        Type = m.Type
                    })
                    .ToList(),

                Theory = lessonEntity.Theory == null
                    ? null
                    : new TheoryModuleModel { Text = lessonEntity.Theory.Text },
            };

        }

        public async Task<LessonEntity> AddLessonAsync(LessonEntity lesson)
        {
            await _lessonRepository.AddAsync(lesson);

            return lesson;
        }


        public async Task<LessonEntity?> UpdateLessonAsync(int languageId, int lessonId, LessonModel lessonModel)
        {
            var lessonEntity = await _lessonRepository.GetLessonByLanguageAndIdAsync(languageId, lessonId);

            if (lessonEntity == null)
                return null;

            _mapper.Map(lessonModel, lessonEntity);

            lessonEntity.Modules.Clear();
            lessonEntity.Modules = lessonModel.Modules.Select(m => new ModuleEntity
            {
                Id = m.Id,
                Title = m.Title,
                Type = m.Type,
                LessonId = lessonEntity.Id
            }).ToList();

            await _lessonRepository.UpdateAsync(lessonEntity);

            return lessonEntity;
        }

        public async Task<bool> DeleteLessonAsync(int languageId, int lessonId)
        {
            return await _lessonRepository.DeleteLessonByLanguageAndIdAsync(languageId, lessonId);
        }

        public async Task<int> GetUserPoints(int userId)
        {
            var points = await _lessonRepository.GetUserPointsAsync(userId);

            return points;
        }
    }
}
