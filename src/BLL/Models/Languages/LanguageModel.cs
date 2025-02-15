using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Languages
{
    public class LanguageModel
    {
        public string LanguageTitle { get; set; }
        public string ImagePath { get; set; }
        public string FlagPath { get; set; }
        public string Description { get; set; }

        public LanguageModel()
        {
            
        }
    }
}
