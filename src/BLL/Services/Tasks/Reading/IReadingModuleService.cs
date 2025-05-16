using BLL.Models.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Tasks.Reading
{
    public interface IReadingModuleService
    {
        Task<ReadingModuleModel> GetByLessonIdAsync(int lessonId);
        Task AddAsync(int lessonId, ReadingModuleModel model);
        Task UpdateAsync(int lessonId, ReadingModuleModel model);
        Task DeleteAsync(int lessonId);
    }
}
