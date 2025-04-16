using DAL.Entities.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Tasks
{
    public class FillInTheBlankTaskEntity : BaseEntity
    {
        public string Sentence { get; set; }
        public string CorrectWord { get; set; }

        public int ReadingModuleId { get; set; }
        public ReadingModuleEntity ReadingModule { get; set; }
    }
}
