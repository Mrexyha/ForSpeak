using AutoMapper;
using BLL.Models.Modules;
using BLL.Models.Tasks;
using DAL.Entities.Modules;
using DAL.Entities.Tasks;
using DAL.Repositories.Tasks.Vocabulary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Tasks.Vocabulary
{
    public class VocabularyModuleService : IVocabularyModuleService
    {
        private readonly IVocabularyModuleRepository _repo;
        private readonly IMapper _mapper;

        public VocabularyModuleService(IVocabularyModuleRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<VocabularyModuleModel> GetByLessonIdAsync(int lessonId)
        {
            var entity = await _repo.GetByLessonIdAsync(lessonId);
            if (entity == null) return null;
            return new VocabularyModuleModel
            {
                Words = entity.Words
                    .Select(w => new WordModel
                    {
                        Id = w.Id,
                        Word = w.Word,
                        Transcription = w.Transcription,
                        Translation = w.Translation,
                    }).ToList()
            };
        }

        public async Task AddAsync(int lessonId, VocabularyModuleModel model)
        {
            var entity = new VocabularyModuleEntity
            {
                LessonId = lessonId,
                Words = model.Words.Select(w => new WordEntity
                {
                    Word = w.Word,
                    Transcription = w.Transcription,
                    Translation = w.Translation,
                }).ToList()
            };
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(int lessonId, VocabularyModuleModel model)
        {
            var entity = await _repo.GetByLessonIdAsync(lessonId);
            if (entity == null) throw new KeyNotFoundException();

            entity.Words.Clear();

            entity.Words = model.Words.Select(w => new WordEntity
            {
                Word = w.Word,
                Transcription = w.Transcription,
                Translation = w.Translation,
            }).ToList();

            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int lessonId)
        {
            await _repo.DeleteAsync(lessonId);
        }
    }
}
