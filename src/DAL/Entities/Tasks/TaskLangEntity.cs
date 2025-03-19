using DAL.Entities.Enums;
using DAL.Entities.Lessons;
using DAL.Entities.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Tasks
{
    public class TaskLangEntity : BaseEntity
    {
        public int ModuleId { get; set; }
        public ModuleEntity Module { get; set; }

        public string ContentJson { get; set; }

        public TaskLangType Type { get; set; }
    }
}
