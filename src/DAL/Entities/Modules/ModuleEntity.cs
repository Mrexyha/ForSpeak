using DAL.Entities.Enums;
using DAL.Entities.Lessons;
using DAL.Entities.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Modules
{
    public class ModuleEntity : BaseEntity
    {
        public int LessonId { get; set; }
        public LessonEntity Lesson { get; set; }

        public string Title { get; set; }
        public TaskLangType Type { get; set; }

        public List<TaskLangEntity> Tasks { get; set; } = new();
    }
}
