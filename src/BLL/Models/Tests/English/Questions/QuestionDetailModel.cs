using BLL.Models.Tests.English.Answers;
using BLL.Models.Tests.English.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Tests.English.Questions
{
    public class QuestionDetailModel
    {
        public string Text { get; set; }
        public TestDetailModel? Test { get; set; }
        public IList<AnswerVariantModel> Answers { get; set; }

        public QuestionDetailModel() { }
    }
}
