using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Tests.English.Questions;

namespace BLL.Models.Tests.English.Tests
{
    public class TestBaseModel:BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsFree { get; set; }
        public int? Result { get; set; }
        public ICollection<int> QuestionIds { get; set; } = new List<int>();

        public TestBaseModel() { }
    }
}
