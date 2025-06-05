using DAL.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Tasks.Theory
{
    public interface ITheoryModuleRepository
    {
        Task<TheoryModuleEntity?> GetByLessonIdAsync(int lessonId);
        Task AddAsync(TheoryModuleEntity module);
        Task UpdateAsync(TheoryModuleEntity module);
        Task DeleteAsync(int lessonId);
    }
}
