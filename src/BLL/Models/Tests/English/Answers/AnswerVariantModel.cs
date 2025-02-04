using BLL.Models.Tests.English.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Tests.English.Answers
{
    public class AnswerVariantModel : BaseModel
    {
        public string Text { get; set; }
        public bool IsRight { get; set; }
        public QuestionDetailModel Question { get; set; }

        public AnswerVariantModel() { }
    }
}
