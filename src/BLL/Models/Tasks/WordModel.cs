using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Tasks
{
    public class WordModel : BaseModel
    {
        public string Word { get; set; }
        public string Transcription { get; set; }
        public string Translation { get; set; }
    }
}
