using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IBaseRepository<LangTask>
    {
        Task<IEnumerable<LangTask>> GetAllAsync();
        Task<LangTask?> GetByIdAsync(int id);
        Task<LangTask> AddAsync(LangTask entity);
        Task<LangTask> UpdateAsync(LangTask entity);
        Task<bool> UpdateRangeAsync(IEnumerable<LangTask> list);
        Task SaveChangesAsync();
    }
}
