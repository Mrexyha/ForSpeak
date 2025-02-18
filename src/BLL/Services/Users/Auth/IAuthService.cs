using BLL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Users.Auth
{
    public interface IAuthService
    {
        Task<string> Register(UserModel user);
        Task<string> Login(UserModel user);
    }
}
