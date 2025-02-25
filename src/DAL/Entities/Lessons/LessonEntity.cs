using DAL.Entities.Languages;
using DAL.Entities.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Lessons
{
    public class LessonEntity : BaseEntity
    {
        public int LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
        public string Theory { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public List<TaskLangEntity> Tasks { get; set; } = new();
        public UsersToLessons UsersToLessons { get; set; }   
    }
}
