using DAL.Entities.Modules;
using DAL.Repositories.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Modules
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<IEnumerable<ModuleEntity>> GetModulesByLessonIdAsync(int lessonId)
        {
            return await _moduleRepository.GetModulesByLessonIdAsync(lessonId);
        }
    }
}
