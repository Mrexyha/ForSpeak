using BLL.Models.Modules;
using DAL.Entities.Modules;
using DAL.Entities.Tasks;
using DAL.Repositories.Modules;

namespace BLL.Services.Modules
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepo;

        public ModuleService(IModuleRepository moduleRepo)
            => _moduleRepo = moduleRepo;

        public async Task<TheoryModuleModel> CreateOrUpdateTheoryAsync(int lessonId, TheoryModuleModel model)
        {
            var entity = await _moduleRepo.GetTheoryByLessonIdAsync(lessonId)
                          ?? new TheoryModuleEntity { LessonId = lessonId };
            entity.Text = model.Text;
            await _moduleRepo.SaveTheoryAsync(entity);

            model.Id = entity.Id;
            return model;
        }

        public async Task<VocabularyModuleModel> CreateOrUpdateVocabularyAsync(int lessonId, VocabularyModuleModel model)
        {
            var entity = await _moduleRepo.GetVocabularyByLessonIdAsync(lessonId)
                          ?? new VocabularyModuleEntity { LessonId = lessonId };
            entity.Words = model.Words.Select(w => new WordEntity
            {
                Id = w.Id,
                Word = w.Word,
                Transcription = w.Transcription,
                Translation = w.Translation,
            }).ToList();
            await _moduleRepo.SaveVocabularyAsync(entity);

            model.Id = entity.Id;
            return model;
        }

        public async Task<QuizModuleModel> CreateOrUpdateQuizAsync(int lessonId, QuizModuleModel model)
        {
            var entity = await _moduleRepo.GetQuizByLessonIdAsync(lessonId)
                          ?? new QuizModuleEntity { LessonId = lessonId };
            entity.Questions = model.Questions.Select(q => new QuizQuestionEntity
            {
                Id = q.Id,
                Question = q.Question,
                Option1 = q.Options.ElementAtOrDefault(0),
                Option2 = q.Options.ElementAtOrDefault(1),
                Option3 = q.Options.ElementAtOrDefault(2),
                CorrectOptionIndex = q.CorrectOptionIndex,
            }).ToList();
            await _moduleRepo.SaveQuizAsync(entity);

            model.Id = entity.Id;
            return model;
        }

        public async Task<ReadingModuleModel> CreateOrUpdateReadingAsync(int lessonId, ReadingModuleModel model)
        {
            var entity = await _moduleRepo.GetReadingByLessonIdAsync(lessonId)
                          ?? new ReadingModuleEntity { LessonId = lessonId };
            entity.Text = model.Text;
            entity.Tasks = model.Tasks.Select(t => new FillInTheBlankTaskEntity
            {
                Id = t.Id,
                Sentence = t.Sentence,
                CorrectWord = t.CorrectWord,
            }).ToList();
            await _moduleRepo.SaveReadingAsync(entity);

            model.Id = entity.Id;
            return model;
        }

        public async Task<SpeakingModuleModel> CreateOrUpdateSpeakingAsync(int lessonId, SpeakingModuleModel model)
        {
            var entity = await _moduleRepo.GetSpeakingByLessonIdAsync(lessonId)
                          ?? new SpeakingModuleEntity { LessonId = lessonId };
            entity.Phrases = model.Phrases.Select(p => new SpeakingPhraseEntity
            {
                Id = p.Id,
                Text = p.Text,
            }).ToList();
            await _moduleRepo.SaveSpeakingAsync(entity);

            model.Id = entity.Id;
            return model;
        }

        public async Task<bool> DeleteModuleAsync(int lessonId, int moduleId)
        {
            return await _moduleRepo.DeleteModuleAsync(lessonId, moduleId);
        }
    }
}
