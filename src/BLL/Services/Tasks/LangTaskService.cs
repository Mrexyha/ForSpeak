using BLL.Models.Tasks;
using DAL.Entities.Tasks;
using DAL.Repositories.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BLL.Services.Tasks
{
    public class LangTaskService : ILangTaskService
    {
        private readonly ILangTaskRepository _langTaskRepository;

        public LangTaskService(ILangTaskRepository langTaskRepository)
        {
            _langTaskRepository = langTaskRepository;
        }

        public async Task<TaskLangModel> CreateTaskAsync(TaskLangModel model)
        {
            var entity = new TaskLangEntity
            {
                ModuleId = model.ModuleId,
                ContentJson = model.ContentJson,
                Type = model.TaskType
            };

            await _langTaskRepository.AddAsync(entity);

            model.Id = entity.Id;
            return model;
        }

        public async Task<TaskLangModel> GetTaskByIdAsync(int id)
        {
            var entity = await _langTaskRepository.GetByIdAsync(id);
            if (entity == null) return null;

            return new TaskLangModel
            {
                Id = entity.Id,
                ModuleId = entity.ModuleId,
                ContentJson = entity.ContentJson,
                TaskType = entity.Type
            };
        }

        public async Task<dynamic> GetTaskContentAsync(int id)
        {
            var entity = await _langTaskRepository.GetByIdAsync(id);
            if (entity == null)
                return null;

            switch (entity.Type)
            {
                case DAL.Entities.Enums.TaskLangType.Theory:
                    return JsonConvert.DeserializeObject<dynamic>(entity.ContentJson);
                case DAL.Entities.Enums.TaskLangType.Quiz:
                    return JsonConvert.DeserializeObject<dynamic>(entity.ContentJson);
                case DAL.Entities.Enums.TaskLangType.Vocabulary:
                    return JsonConvert.DeserializeObject<dynamic>(entity.ContentJson);
                case DAL.Entities.Enums.TaskLangType.Reading:
                    return JsonConvert.DeserializeObject<dynamic>(entity.ContentJson);
                case DAL.Entities.Enums.TaskLangType.Speaking:
                    return JsonConvert.DeserializeObject<dynamic>(entity.ContentJson);
                default:
                    return null;
            }
        }
    }
}
