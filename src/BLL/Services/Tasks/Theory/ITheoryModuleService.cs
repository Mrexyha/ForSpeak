using BLL.Models.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Tasks.Theory
{
    public interface ITheoryModuleService
    {
        Task<TheoryModuleModel?> GetByLessonIdAsync(int lessonId);
        Task AddAsync(int lessonId, TheoryModuleModel model);
        Task UpdateAsync(int lessonId, TheoryModuleModel model);
        Task DeleteAsync(int lessonId);
    }
}
