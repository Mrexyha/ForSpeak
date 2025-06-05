using BLL.Models.Tasks;
using DAL.Entities.Tasks;
using DAL.Repositories.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Services.Tasks
{
    public class LangTaskService : ILangTaskService
    {
        private readonly ILangTaskRepository _langTaskRepository;
        private readonly IMapper _mapper;

        public LangTaskService(ILangTaskRepository langTaskRepository, IMapper mapper)
        {
            _langTaskRepository = langTaskRepository;
            _mapper = mapper;
        }

        public async Task<TaskLangModel> CreateTaskAsync(TaskLangModel model)
        {
            var entity = _mapper.Map<TaskLangEntity>(model);

            await _langTaskRepository.AddAsync(entity);

            model.Id = entity.Id;
            return model;
        }

        public async Task<TaskLangModel> GetTaskByIdAsync(int id)
        {
            var entity = await _langTaskRepository.GetByIdAsync(id);
            if (entity == null) return null;

            return _mapper.Map<TaskLangModel>(entity);
        }

        public async Task<TaskLangModel?> UpdateTaskAsync(int id, TaskLangModel model)
        {
            var existingEntity = await _langTaskRepository.GetByIdAsync(id);
            if (existingEntity == null)
                return null;

            _mapper.Map(model, existingEntity);

            await _langTaskRepository.UpdateAsync(existingEntity);

            return _mapper.Map<TaskLangModel>(existingEntity);
        }

        public async Task<dynamic> GetTaskContentAsync(int id)
        {
            var entity = await _langTaskRepository.GetByIdAsync(id);
            if (entity == null)
                return null;

            return JsonConvert.DeserializeObject<dynamic>(entity.ContentJson);
        }
    }
}
