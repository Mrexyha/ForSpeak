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
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int userId);
        Task<UserModel> UpdateUserAsync(UserModel userModel);
        Task<bool> DeleteUserAsync(int userId);
        //Task<UserModel> SignUp(UserModel user);
        //Task<UserSettingsModel> SignIn(UserModel user);
        //Task<bool> ChangeSettings(UserSettingsModel settings);
    }
}
