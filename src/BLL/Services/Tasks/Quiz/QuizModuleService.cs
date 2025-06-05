using AutoMapper;
using BLL.Models.Modules;
using BLL.Models.Tasks;
using DAL;
using DAL.Entities.Modules;
using DAL.Entities.Results;
using DAL.Entities.Tasks;
using DAL.Repositories.Tasks.Quiz;
using Microsoft.EntityFrameworkCore;
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
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public QuizModuleService(IQuizModuleRepository repo, AppDbContext context, IMapper mapper)
        {
            _repo = repo;
            _context = context;
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

        public async Task<double> RecalculateScore(int lessonId)
        {
            var avg = await _context.SpeakingPhraseAttempts
                .Where(a => a.Phrase.SpeakingModule.LessonId == lessonId)
                .AverageAsync(a => a.Accuracy);

            var module = await _repo.GetByLessonIdAsync(lessonId)
                         ?? throw new KeyNotFoundException($"Module {lessonId} not found");

            module.Score = avg;
            await _repo.UpdateAsync(module);

            return avg;
        }

        public async Task UpdateAverageAsync(int lessonId, double average)
        {
            var module = await _repo.GetByLessonIdAsync(lessonId)
                ?? throw new KeyNotFoundException($"Module {lessonId} not found");

            module.Score = average;
            await _repo.UpdateAsync(module);
        }

        public async Task<double?> GetScoreAsync(int lessonId, int userId)
        {
            var entity = await _context.QuizResults
                .FirstOrDefaultAsync(r => r.LessonId == lessonId && r.UserId == userId);

            return entity?.Score; 
        }

        public async Task UpdateUserResultAsync(int lessonId, int userId, double score)
        {
            var entity = await _context.QuizResults
                .FirstOrDefaultAsync(r => r.LessonId == lessonId && r.UserId == userId);

            if (entity == null)
            {
                entity = new QuizResultEntity
                {
                    LessonId = lessonId,
                    UserId = userId,
                    Score = score,
                    CreatedAt = DateTime.UtcNow   
                };

                _context.QuizResults.Add(entity);
            }
            else
            {
                entity.Score = score;
                _context.QuizResults.Update(entity);
            }

            await _context.SaveChangesAsync();
        }


        public async Task SaveUserResultAsync(int userId, int lessonId, double score)
        {
            var existingResult = await _context.QuizResults
                .FirstOrDefaultAsync(r => r.UserId == userId && r.LessonId == lessonId);

            if (existingResult != null)
            {
                existingResult.Score = score;
            }
            else
            {
                _context.QuizResults.Add(new QuizResultEntity
                {
                    UserId = userId,
                    LessonId = lessonId,
                    Score = score,
                    CreatedAt = DateTime.UtcNow
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
