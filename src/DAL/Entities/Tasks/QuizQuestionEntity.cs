using DAL.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Tasks
{
    public class QuizQuestionEntity : BaseEntity
    {
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public int CorrectOptionIndex { get; set; }

        public int QuizModuleId { get; set; }
        public QuizModuleEntity QuizModule { get; set; }
    }
}
