using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Languages
{
    public class LanguageModel : BaseModel
    {
        public string Name { get; set; }
        public string FlagImage { get; set; }
        public string CountryImage { get; set; }
        public string Description { get; set; }

        public int LessonsCount { get; set; }
    }
}
