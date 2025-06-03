using BLL.Models.Modules;
using BLL.Models.Tasks;
using DAL;
using DAL.Entities.Tasks;
using DAL.Repositories.Tasks.Speaking;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services.Tasks.Speaking
{
    public class SpeakingModuleService : ISpeakingModuleService
    {
        private readonly AppDbContext _context;
        private readonly ISpeakingModuleRepository _repo;
        public SpeakingModuleService(ISpeakingModuleRepository repo) => _repo = repo;

        public async Task<SpeakingModuleModel> GetByLessonIdAsync(int lessonId)
        {
            var entity = await _repo.GetByLessonIdAsync(lessonId)
               ?? throw new KeyNotFoundException(
                    $"Speaking module not found for lessonId = {lessonId}");

            return new SpeakingModuleModel
            {
                Phrases = entity.Phrases
                                .Select(p => new SpeakingPhraseModel { Id = p.Id, Text = p.Text })
                                .ToList(),
                AverageAccuracy = entity.AverageAccuracy
            };
        }

        public async Task<SpeakingPhraseModel> AddPhraseAsync(int lessonId, SpeakingPhraseModel newPhrase)
        {
            var entity = new SpeakingPhraseEntity { Text = newPhrase.Text };
            await _repo.AddPhraseAsync(lessonId, entity);
            return new SpeakingPhraseModel { Id = entity.Id, Text = entity.Text };
        }

        public async Task UpdateAverageAsync(int lessonId, double newAverage)
        {
            var module = await _repo.GetByLessonIdAsync(lessonId)
              ?? throw new KeyNotFoundException($"Cannot update average: speaking module for lessonId = {lessonId} not found");
            module.AverageAccuracy = newAverage;
            await _repo.UpdateAsync(module);
        }

        public async Task DeletePhraseAsync(int phraseId)
        {
            await _repo.DeletePhraseAsync(phraseId);
        }

        public async Task<double> RecalculateAverageAccuracyAsync(int lessonId)
        {
            var avg = await _context.SpeakingPhraseAttempts
                .Where(a => a.Phrase.SpeakingModule.LessonId == lessonId)
                .AverageAsync(a => a.Accuracy);

            var module = await _repo.GetByLessonIdAsync(lessonId)
                         ?? throw new KeyNotFoundException($"Module {lessonId} not found");

            module.AverageAccuracy = avg;
            await _repo.UpdateAsync(module);

            return avg;
        }

    }
}
