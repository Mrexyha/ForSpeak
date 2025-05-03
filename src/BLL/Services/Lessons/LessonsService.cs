using AutoMapper;
using BLL.Models.Lessons;
using BLL.Models.Modules;
using BLL.Models.Tasks;
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
                LanguageName = l.LanguageName,
                Title = l.Title,
                ImageUrl = l.ImageUrl,
                Level = l.Level,

                Modules = l.Modules.Select(m => new ModuleModel
                {
                    Id = m.Id,
                    LessonId = m.LessonId,
                    Title = m.Title,
                    Type = m.Type
                }).ToList(),

                Theory = l.Theory == null
                    ? null
                    : new TheoryModuleModel { Text = l.Theory.Text },

                Vocabulary = l.Vocabulary == null
                    ? null
                    : new VocabularyModuleModel
                    {
                        Words = l.Vocabulary.Words
                            .Select(w => new WordModel
                            {
                                Id = w.Id,
                                Word = w.Word,
                                Transcription = w.Transcription,
                                Translation = w.Translation
                            })
                            .ToList()
                    },

                Quiz = l.Quiz == null
                    ? null
                    : new QuizModuleModel
                    {
                        Questions = l.Quiz.Questions
                            .Select(q => new QuizQuestionModel
                            {
                                Question = q.Question,
                                Options = new[] { q.Option1, q.Option2, q.Option3 }.ToList(),
                                CorrectOptionIndex = q.CorrectOptionIndex
                            })
                            .ToList()
                    },

                Reading = l.Reading == null
                    ? null
                    : new ReadingModuleModel
                    {
                        Text = l.Reading.Text,
                        Tasks = l.Reading.Tasks
                            .Select(t => new FillInTheBlankTaskModel
                            {
                                Sentence = t.Sentence,
                                CorrectWord = t.CorrectWord
                            })
                            .ToList()
                    },

                Speaking = l.Speaking == null
                    ? null
                    : new SpeakingModuleModel
                    {
                        Phrases = l.Speaking.Phrases
                            .Select(p => new SpeakingPhraseModel
                            {
                                Text = p.Text,
                            })
                            .ToList()
                    },
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

                Vocabulary = lessonEntity.Vocabulary == null
                    ? null
                    : new VocabularyModuleModel
                    {
                        Words = lessonEntity.Vocabulary.Words
                            .Select(w => new WordModel
                            {
                                Id = w.Id,
                                Word = w.Word,
                                Transcription = w.Transcription,
                                Translation = w.Translation
                            })
                            .ToList()
                    },

                    Quiz = lessonEntity.Quiz == null
                        ? null
                        : new QuizModuleModel
                        {
                            Questions = lessonEntity.Quiz.Questions.Select(q => new QuizQuestionModel
                            {
                                Question = q.Question,
                                Options = new[] { q.Option1, q.Option2, q.Option3 }.ToList(),
                                CorrectOptionIndex = q.CorrectOptionIndex
                            }).ToList()
                        },
                Reading = lessonEntity.Reading == null
        ? null
        : new ReadingModuleModel
        {
            Text = lessonEntity.Reading.Text,
            Tasks = lessonEntity.Reading.Tasks.Select(t => new FillInTheBlankTaskModel
            {
                Sentence = t.Sentence,
                CorrectWord = t.CorrectWord
            }).ToList()
        }
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
