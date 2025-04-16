using BLL.Models.Languages;
using BLL.Models.Modules;
using DAL.Entities.Enums;
using DAL.Entities.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Lessons
{
    public class LessonModel : BaseModel
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }

        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public LessonLevel Level { get; set; }

        public List<ModuleModel> Modules { get; set; } = new List<ModuleModel>();

        public TheoryModuleModel Theory { get; set; }
        public VocabularyModuleModel Vocabulary { get; set; }
        public QuizModuleModel Quiz { get; set; }
        public ReadingModuleModel Reading { get; set; }
        public SpeakingModuleModel Speaking { get; set; }
    }
}
