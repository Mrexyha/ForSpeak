using AutoMapper;
using BLL.Models.Modules;
using DAL.Entities.Modules;
using DAL.Repositories.Tasks.Theory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Tasks.Theory
{
    public class TheoryModuleService : ITheoryModuleService
    {
        private readonly ITheoryModuleRepository _repository;
        private readonly IMapper _mapper;

        public TheoryModuleService(ITheoryModuleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TheoryModuleModel?> GetByLessonIdAsync(int lessonId)
        {
            var entity = await _repository.GetByLessonIdAsync(lessonId);
            return entity == null
                ? null
                : _mapper.Map<TheoryModuleModel>(entity);
        }

        public async Task AddAsync(int lessonId, TheoryModuleModel model)
        {
            var entity = _mapper.Map<TheoryModuleEntity>(model);
            entity.LessonId = lessonId;
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(int lessonId, TheoryModuleModel model)
        {
            var existing = await _repository.GetByLessonIdAsync(lessonId);
            if (existing == null)
                throw new KeyNotFoundException($"Theory module for lesson {lessonId} not found.");

            existing.Text = model.Text;
            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int lessonId)
        {
            await _repository.DeleteAsync(lessonId);
        }
    }
}
