using AutoMapper;
using BLL.Models.Modules;
using BLL.Models.Tasks;
using DAL.Entities.Modules;
using DAL.Entities.Tasks;
using DAL.Repositories.Tasks.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Tasks.Quiz
{
    public class QuizModuleService : IQuizModuleService
    {
        private readonly IQuizModuleRepository _repo;
        private readonly IMapper _mapper;
        public QuizModuleService(IQuizModuleRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<QuizModuleModel> GetByLessonIdAsync(int lessonId)
        {
            var entity = await _repo.GetByLessonIdAsync(lessonId);
            if (entity == null) return null;

            return new QuizModuleModel
            {
                Questions = entity.Questions
                    .Select(q => new QuizQuestionModel
                    {
                        Question = q.Question,
                        Options = new[] { q.Option1, q.Option2, q.Option3 }.ToList(),
                        CorrectOptionIndex = q.CorrectOptionIndex
                    }).ToList()
            };
        }

        public async Task AddAsync(int lessonId, QuizModuleModel model)
        {
            var entity = new QuizModuleEntity
            {
                LessonId = lessonId,
                Questions = model.Questions.Select(q => new QuizQuestionEntity
                {
                    Question = q.Question,
                    Option1 = q.Options[0],
                    Option2 = q.Options[1],
                    Option3 = q.Options[2],
                    CorrectOptionIndex = q.CorrectOptionIndex
                }).ToList()
            };
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(int lessonId, QuizModuleModel model)
        {
            var entity = await _repo.GetByLessonIdAsync(lessonId);
            if (entity == null) throw new KeyNotFoundException();

            entity.Questions.Clear();
            entity.Questions = model.Questions.Select(q => new QuizQuestionEntity
            {
                Question = q.Question,
                Option1 = q.Options[0],
                Option2 = q.Options[1],
                Option3 = q.Options[2],
                CorrectOptionIndex = q.CorrectOptionIndex
            }).ToList();

            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int lessonId)
            => await _repo.DeleteAsync(lessonId);
    }
}
