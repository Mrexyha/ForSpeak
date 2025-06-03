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
        Task<List<RegisterModel>> GetAllUsersAsync();
        Task<RegisterModel> GetUserByIdAsync(int userId);
        Task<UserModel> GetUserWithLanguagesAsync(int userId);
        Task<RegisterModel> UpdateUserAsync(RegisterModel userModel);
        Task<bool> AddLanguageToUserAsync(int userId, int languageId);
        Task<bool> DeleteUserAsync(int userId);
        Task<bool> RemoveLanguageFromUserAsync(int userId, int languageId);
    }
}
