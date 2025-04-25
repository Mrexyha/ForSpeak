using BLL.Models.Modules;
using BLL.Models.Tasks;
using DAL.Entities.Modules;
using DAL.Entities.Tasks;
using DAL.Repositories.Tasks.Reading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Tasks.Reading
{
    public class ReadingModuleService : IReadingModuleService
    {
        private readonly IReadingModuleRepository _repo;

        public ReadingModuleService(IReadingModuleRepository repo)
        {
            _repo = repo;
        }

        public async Task<ReadingModuleModel> GetByLessonIdAsync(int lessonId)
        {
            var entity = await _repo.GetByLessonIdAsync(lessonId);
            if (entity == null) return null;
            return new ReadingModuleModel
            {
                Text = entity.Text,
                Tasks = entity.Tasks
                    .Select(t => new FillInTheBlankTaskModel
                    {
                        Sentence = t.Sentence,
                        CorrectWord = t.CorrectWord
                    })
                    .ToList()
            };
        }

        public async Task AddAsync(int lessonId, ReadingModuleModel model)
        {
            var entity = new ReadingModuleEntity
            {
                LessonId = lessonId,
                Text = model.Text,
                Tasks = model.Tasks
                    .Select(t => new FillInTheBlankTaskEntity
                    {
                        Sentence = t.Sentence,
                        CorrectWord = t.CorrectWord
                    }).ToList()
            };
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(int lessonId, ReadingModuleModel model)
        {
            var entity = await _repo.GetByLessonIdAsync(lessonId);
            if (entity == null) throw new KeyNotFoundException();

            entity.Text = model.Text;
            entity.Tasks.Clear();
            entity.Tasks = model.Tasks
                .Select(t => new FillInTheBlankTaskEntity
                {
                    Sentence = t.Sentence,
                    CorrectWord = t.CorrectWord
                }).ToList();

            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int lessonId)
            => await _repo.DeleteAsync(lessonId);
    }
}
