using BLL.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Modules
{
    public class SpeakingModuleModel : BaseModel
    {
        public List<SpeakingPhraseModel> Phrases { get; set; }

        public double AverageAccuracy { get; set; }

    }
}
