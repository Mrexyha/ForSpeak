using BLL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Users.User
{
    public interface IUserService
    {
        Task<UserModel> SignUp(UserModel user);
        Task<UserSettingsModel> SignIn(UserModel user);
        Task<bool> ChangeSettings(UserSettingsModel settings);
    }
}
