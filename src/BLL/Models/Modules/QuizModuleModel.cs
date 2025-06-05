using BLL.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Modules
{
    public class QuizModuleModel : BaseModel
    {
        public List<QuizQuestionModel> Questions { get; set; }

        public double Score { get; set; }
    }
}
