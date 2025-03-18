using BLL.Models.Tasks;
using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Modules
{
    public class ModuleModel
    {
        public int Id { get; set; }
        public int LessonId { get; set; }

        public string Title { get; set; }
        public TaskLangType Type { get; set; }

        public List<TaskLangModel> Tasks { get; set; } = new();
    }
}
