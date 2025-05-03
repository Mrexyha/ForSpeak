using DAL.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Tasks
{
    public class SpeakingPhraseEntity : BaseEntity
    {
        public string Text { get; set; }

        public int SpeakingModuleId { get; set; }
        public SpeakingModuleEntity SpeakingModule { get; set; }
    }
}
