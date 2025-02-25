using DAL.Entities.Languages;
using DAL.Entities.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Users
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } = "User";
        public string Gender { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string> SelectedLanguages { get; set; }
        public List<UserLanguage> UserLanguages { get; set; }

        public List<LanguageEntity> Languages { get; set; }
        public UsersToLessons UsersToLessons { get; set; }
    }
}
