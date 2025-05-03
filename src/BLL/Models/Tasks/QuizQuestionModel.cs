using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Tasks
{
    public class QuizQuestionModel : BaseModel
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public int CorrectOptionIndex { get; set; }
    }
}
