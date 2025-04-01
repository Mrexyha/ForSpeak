using BLL.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Tasks
{
    public interface ILangTaskService
    {
        Task<TaskLangModel> CreateTaskAsync(TaskLangModel model);
        Task<TaskLangModel> GetTaskByIdAsync(int id);
        Task<dynamic> GetTaskContentAsync(int id);
    }
}
