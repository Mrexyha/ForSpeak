using DAL.Entities.Lessons;
using DAL.Entities.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Modules
{
    public class SpeakingModuleEntity : BaseEntity
    {
        public int LessonId { get; set; }
        public LessonEntity Lesson { get; set; }

        public ICollection<SpeakingPhraseEntity> Phrases { get; set; }
    }
}
