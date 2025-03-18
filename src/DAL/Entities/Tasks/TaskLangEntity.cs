using DAL.Entities.Enums;
using DAL.Entities.Lessons;
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
        [ForeignKey(nameof(Lesson))]
        public int LessonId { get; set; }
        public LessonEntity Lesson { get; set; }

        public string ContentJson { get; set; }
        public LessonLevel TaskLevel { get; set; }
        public LessonType Type { get; set; }

        
    }
}
