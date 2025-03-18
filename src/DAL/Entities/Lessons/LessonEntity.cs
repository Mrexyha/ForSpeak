using DAL.Entities.Languages;
using DAL.Entities.Relations;
using DAL.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Enums;

namespace DAL.Entities.Lessons
{
    public class LessonEntity : BaseEntity
    {
        public int LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
        public string LanguageName { get; set; }

        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public LessonLevel Level { get; set; }

        public List<ModuleEntity> Modules { get; set; } = new();
        public List<UsersToLessons> UsersToLessons { get; set; } = new();
    }
}
