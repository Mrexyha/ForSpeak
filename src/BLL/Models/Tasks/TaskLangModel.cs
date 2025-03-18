using BLL.Models.Modules;
using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Tasks
{
    public class TaskLangModel
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public ModuleModel Module { get; set; }
        public string ContentJson { get; set; }
        public LessonLevel TaskLevel { get; set; }
        public LessonType TaskType { get; set; }
    }
}
