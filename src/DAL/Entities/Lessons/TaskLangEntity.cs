using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Lessons
{
    public class TaskLangEntity : BaseEntity
    {
        //public int LessonId { get; set; }
        //public LessonEntity Lesson { get; set; }

        //public string Type { get; set; }
        //public string Content { get; set; } 

        [ForeignKey(nameof(Lesson))]
        public int LessonId { get; set; }
        public string ContentJson { get; set; }
        public TaskLevel TaskLevel { get; set; }
        public TaskType Type { get; set; }

        public LessonEntity Lesson { get; set; }
    }
}
