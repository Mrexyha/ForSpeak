using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.User
{
    public class UserSettingsModel
    {
        public string? AccessToken { get; set; }
        public DateTime? AccessTokenExpireTime { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireTime { get; set; }
        public bool IsAdmin { get; set; }
        public int UserId { get; set; }

        public UserSettingsModel() { }
    }
}
