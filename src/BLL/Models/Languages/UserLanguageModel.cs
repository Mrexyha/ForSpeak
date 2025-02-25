using BLL.Models.User;
using DAL.Entities.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Languages
{
    public class UserLanguageModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }

        public int LanguageId { get; set; }
        public LanguageEntity Language { get; set; }

        public double Progress { get; set; }
    }
}
