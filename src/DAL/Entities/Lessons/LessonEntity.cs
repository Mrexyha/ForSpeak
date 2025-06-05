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
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public LessonLevel Level { get; set; }

        public int LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
        public string LanguageName { get; set; }

        public TheoryModuleEntity Theory { get; set; }
        public VocabularyModuleEntity Vocabulary { get; set; }
        public QuizModuleEntity Quiz { get; set; }
        public ReadingModuleEntity Reading { get; set; }
        public SpeakingModuleEntity Speaking { get; set; }

        public ICollection<ModuleEntity> Modules { get; set; } = new List<ModuleEntity>();
        public List<UsersToLessons> UsersToLessons { get; set; } = new();
    }
}
