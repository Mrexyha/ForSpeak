using BLL.Models.Languages;
using DAL.Entities.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.User
{
    public class UserLanguageModel : BaseModel
    {
        public int UserId { get; set; }
        public RegisterModel User { get; set; }

        public int LanguageId { get; set; }
        public LanguageModel Language { get; set; }

        public double Progress { get; set; }
    }
}
