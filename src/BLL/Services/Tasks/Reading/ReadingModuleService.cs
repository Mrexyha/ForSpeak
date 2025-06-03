using BLL.Models.Modules;
using BLL.Models.Tasks;
using DAL;
using DAL.Entities.Modules;
using DAL.Entities.Results;
using DAL.Entities.Tasks;
using DAL.Repositories.Tasks.Reading;
using Microsoft.EntityFrameworkCore;
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
        private readonly AppDbContext _context;

        public ReadingModuleService(IReadingModuleRepository repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
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

        public async Task<double> RecalculateComprehensionScore(int lessonId)
        {
            var avg = await _context.SpeakingPhraseAttempts
                .Where(a => a.Phrase.SpeakingModule.LessonId == lessonId)
                .AverageAsync(a => a.Accuracy);

            var module = await _repo.GetByLessonIdAsync(lessonId)
                         ?? throw new KeyNotFoundException($"Module {lessonId} not found");

            module.ComprehensionScore = avg;
            await _repo.UpdateAsync(module);

            return avg;
        }

        public async Task<double?> GetComprehensionScoreAsync(int lessonId, int userId)
        {
            var entity = await _context.ReadingResults
                .FirstOrDefaultAsync(r => r.LessonId == lessonId && r.UserId == userId);

            return entity?.ComprehensionScore;
        }

        public async Task UpdateUserResultAsync(int lessonId, int userId, double comprehensionScore)
        {
            var entity = await _context.ReadingResults
                .FirstOrDefaultAsync(r => r.LessonId == lessonId && r.UserId == userId);

            if (entity == null)
            {
                entity = new ReadingResultEntity
                {
                    LessonId = lessonId,
                    UserId = userId,
                    ComprehensionScore = comprehensionScore,
                    CreatedAt = DateTime.UtcNow
                };
                _context.ReadingResults.Add(entity);
            }
            else
            {
                entity.ComprehensionScore = comprehensionScore;
                _context.ReadingResults.Update(entity);
            }

            await _context.SaveChangesAsync();
        }
    }
}
