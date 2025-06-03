using BLL.Models.Languages;
using BLL.Models.Lessons;
using BLL.Models.Modules;
using BLL.Models.Tasks;
using DAL.Entities.Lessons;
using DAL.Entities.Languages;
using DAL.Entities.Modules;
using DAL.Entities.Tasks;
using DAL.Repositories.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
            => _languageRepository = languageRepository;

        public async Task<List<LanguageModel>> GetAvailableLanguagesAsync()
        {
            var entities = await _languageRepository.GetAllLanguagesAsync();

            return entities
                .Select(l => MapToModel(l))
                .ToList();
        }

        public async Task<LanguageModel?> GetLanguageByIdAsync(int id)
        {
            var entity = await _languageRepository.GetByIdAsync(id);
            if (entity == null) return null;
            return MapToModel(entity);
        }

        public async Task UpdateLanguageAsync(LanguageModel languageModel)
        {
            var entity = await _languageRepository.GetByIdAsync(languageModel.Id);
            if (entity == null) throw new KeyNotFoundException();

            entity.Name = languageModel.Name;
            entity.Description = languageModel.Description;
            entity.FlagImage = languageModel.FlagImage;
            entity.CountryImage = languageModel.CountryImage;

            await _languageRepository.UpdateLanguageAsync(entity);
        }

        private static LanguageModel MapToModel(LanguageEntity l)
        {
            return new LanguageModel
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                FlagImage = l.FlagImage,
                CountryImage = l.CountryImage,
                LessonsCount = l.Lessons?.Count ?? 0,
                Lessons = (l.Lessons ?? Enumerable.Empty<LessonEntity>())
                    .Select(le => new LessonModel
                    {
                        Id = le.Id,
                        LanguageId = le.LanguageId,
                        LanguageName = le.LanguageName,
                        Title = le.Title,
                        ImageUrl = le.ImageUrl,
                        Level = le.Level,
                        Modules = (le.Modules ?? Enumerable.Empty<ModuleEntity>())
                            .Select(m => new ModuleModel
                            {
                                Id = m.Id,
                                LessonId = m.LessonId,
                                Title = m.Title,
                                Type = m.Type
                            })
                            .ToList(),
                        Theory = new TheoryModuleModel
                        {
                            Text = le.Theory?.Text ?? string.Empty
                        },
                        Vocabulary = new VocabularyModuleModel
                            {
                            Words = (le.Vocabulary?.Words ?? Enumerable.Empty<WordEntity>())
                                    .Select(w => new WordModel
                                    {
                                        Id = w.Id,
                                        Word = w.Word,
                                        Transcription = w.Transcription,
                                        Translation = w.Translation
                                    })
                                    .ToList()
                            },
                        Quiz = new QuizModuleModel
                            {
                            Questions = (le.Quiz?.Questions ?? Enumerable.Empty<QuizQuestionEntity>())
                                    .Select(q => new QuizQuestionModel
                                    {
                                        Question = q.Question,
                                        Options = new[] { q.Option1, q.Option2, q.Option3 }.ToList(),
                                        CorrectOptionIndex = q.CorrectOptionIndex
                                    })
                                    .ToList()
                            },
                        Reading = new ReadingModuleModel
                            {
                            Text = le.Reading?.Text ?? string.Empty,
                            Tasks = (le.Reading?.Tasks ?? Enumerable.Empty<FillInTheBlankTaskEntity>())
                                    .Select(t => new FillInTheBlankTaskModel
                                    {
                                        Sentence = t.Sentence,
                                        CorrectWord = t.CorrectWord
                                    })
                                    .ToList()
                            },
                        Speaking = new SpeakingModuleModel
                            {
                            Phrases = (le.Speaking?.Phrases ?? Enumerable.Empty<SpeakingPhraseEntity>())
                                    .Select(p => new SpeakingPhraseModel
                                    {
                                        Text = p.Text                                    })
                                    .ToList()
                            }
                    })
                    .ToList()
            };
        }
    }
}
