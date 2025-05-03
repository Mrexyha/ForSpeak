using DAL.Entities.Modules;
using DAL.Entities.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Tasks.Speaking
{
    public class SpeakingModuleRepository : ISpeakingModuleRepository
    {
        private readonly AppDbContext _context;
        public SpeakingModuleRepository(AppDbContext context) => _context = context;

        public async Task<SpeakingModuleEntity?> GetByLessonIdAsync(int lessonId)
            => await _context.Set<SpeakingModuleEntity>()
                .Include(s => s.Phrases)
                .FirstOrDefaultAsync(s => s.LessonId == lessonId);

        public async Task UpdateAsync(SpeakingModuleEntity entity)
        {
            _context.Set<SpeakingModuleEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddPhraseAsync(int lessonId, SpeakingPhraseEntity phrase)
        {
            var module = await GetByLessonIdAsync(lessonId)
                         ?? throw new KeyNotFoundException($"Module for lesson {lessonId} not found");
            module.Phrases.Add(phrase);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePhraseAsync(int phraseId)
        {
            var phrase = await _context.Set<SpeakingPhraseEntity>().FindAsync(phraseId);
            if (phrase != null)
            {
                _context.Set<SpeakingPhraseEntity>().Remove(phrase);
                await _context.SaveChangesAsync();
            }
        }
    }
}
