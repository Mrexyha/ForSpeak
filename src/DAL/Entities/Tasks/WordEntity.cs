using DAL.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Tasks
{
    public class WordEntity : BaseEntity
    {
        public string Word { get; set; }
        public string Transcription { get; set; }
        public string Translation { get; set; }

        public int VocabularyModuleId { get; set; }
        public VocabularyModuleEntity VocabularyModule { get; set; }
    }
}
