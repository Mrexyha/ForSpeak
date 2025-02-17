using BLL.Models.Languages;
using DAL.Entities.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.User
{
    public class UserModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; } = "User";

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Country { get; set; } 

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public List<string> SelectedLanguages { get; set; } 
    }
}
