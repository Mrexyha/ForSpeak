using DAL.Entities.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Modules
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly AppDbContext _context;

        public ModuleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TheoryModuleEntity> GetTheoryByLessonIdAsync(int lessonId)
            => await _context.TheoryModules
                .FirstOrDefaultAsync(t => t.LessonId == lessonId);

        public async Task SaveTheoryAsync(TheoryModuleEntity entity)
        {
            if (entity.Id == 0) _context.TheoryModules.Add(entity);
            else _context.TheoryModules.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<VocabularyModuleEntity> GetVocabularyByLessonIdAsync(int lessonId)
            => await _context.VocabularyModules
                .Include(v => v.Words)
                .FirstOrDefaultAsync(v => v.LessonId == lessonId);

        public async Task SaveVocabularyAsync(VocabularyModuleEntity entity)
        {
            if (entity.Id == 0) _context.VocabularyModules.Add(entity);
            else _context.VocabularyModules.Update(entity);

            var oldWords = _context.Words.Where(w => w.VocabularyModuleId == entity.Id);
            _context.Words.RemoveRange(oldWords);
            _context.Words.AddRange(entity.Words);

            await _context.SaveChangesAsync();
        }

        public async Task<QuizModuleEntity> GetQuizByLessonIdAsync(int lessonId)
            => await _context.QuizModules
                .Include(q => q.Questions)
                .FirstOrDefaultAsync(q => q.LessonId == lessonId);

        public async Task SaveQuizAsync(QuizModuleEntity entity)
        {
            if (entity.Id == 0) _context.QuizModules.Add(entity);
            else _context.QuizModules.Update(entity);

            var oldQ = _context.QuizQuestions.Where(q => q.Id == entity.Id);
            _context.QuizQuestions.RemoveRange(oldQ);
            _context.QuizQuestions.AddRange(entity.Questions);

            await _context.SaveChangesAsync();
        }


        public async Task<ReadingModuleEntity> GetReadingByLessonIdAsync(int lessonId)
            => await _context.ReadingModules
                .Include(r => r.Tasks)
                .FirstOrDefaultAsync(r => r.LessonId == lessonId);

        public async Task SaveReadingAsync(ReadingModuleEntity entity)
        {
            if (entity.Id == 0) _context.ReadingModules.Add(entity);
            else _context.ReadingModules.Update(entity);

            var oldTasks = _context.FillInTheBlankTasks.Where(t => t.ReadingModuleId == entity.Id);
            _context.FillInTheBlankTasks.RemoveRange(oldTasks);
            _context.FillInTheBlankTasks.AddRange(entity.Tasks);

            await _context.SaveChangesAsync();
        }

        public async Task<SpeakingModuleEntity> GetSpeakingByLessonIdAsync(int lessonId)
            => await _context.SpeakingModules
                .Include(s => s.Phrases)
                .FirstOrDefaultAsync(s => s.LessonId == lessonId);

        public async Task SaveSpeakingAsync(SpeakingModuleEntity entity)
        {
            if (entity.Id == 0) _context.SpeakingModules.Add(entity);
            else _context.SpeakingModules.Update(entity);

            var oldPhrases = _context.SpeakingPhrases.Where(p => p.SpeakingModuleId == entity.Id);
            _context.SpeakingPhrases.RemoveRange(oldPhrases);
            _context.SpeakingPhrases.AddRange(entity.Phrases);

            await _context.SaveChangesAsync();
        }


        public async Task<bool> DeleteModuleAsync(int lessonId, int moduleId)
        {
            var mod = await _context.Modules
                .FirstOrDefaultAsync(m => m.LessonId == lessonId && m.Id == moduleId);
            if (mod == null) return false;

            _context.Modules.Remove(mod);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
