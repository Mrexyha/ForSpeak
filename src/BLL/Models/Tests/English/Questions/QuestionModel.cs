using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Tests.English.Answers;
using BLL.Models.Tests.English.Tests;

namespace BLL.Models.Tests.English.Questions
{
    public class QuestionModel : BaseModel
    {
        public string Text { get; set; }
        public TestBaseModel Test { get; set; } = null!;

        public ICollection<int> AnswerIds { get; set; } = new List<int>();

        public QuestionModel() { }

    }
}
