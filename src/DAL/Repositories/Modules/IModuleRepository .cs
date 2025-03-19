using DAL.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Modules
{
    public interface IModuleRepository
    {
        Task<IEnumerable<ModuleEntity>> GetModulesByLessonAndLanguageIdsAsync(int lessonId);
    }
}
