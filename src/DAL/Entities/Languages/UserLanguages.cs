using DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Languages
{
    public class UserLanguage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public double Progress { get; set; }
    }
}
