using BLL.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Modules
{
    public class VocabularyModuleModel : BaseModel
    {
        public List<WordModel> Words { get; set; }
    }
}
