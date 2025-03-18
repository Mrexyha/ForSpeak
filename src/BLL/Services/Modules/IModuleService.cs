using DAL.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Modules
{
    public interface IModuleService
    {
        Task<IEnumerable<ModuleEntity>> GetModulesByLessonAndLanguageIdsAsync(int lessonId);
    }
}
