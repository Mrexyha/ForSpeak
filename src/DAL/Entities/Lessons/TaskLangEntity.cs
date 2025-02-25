using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Lessons
{
    public class TaskLangEntity
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public LessonEntity Lesson { get; set; }

        public string Type { get; set; }
        public string Content { get; set; } 
    }
}
