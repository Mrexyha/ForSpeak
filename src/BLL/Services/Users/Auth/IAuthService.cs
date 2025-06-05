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
        Task<AuthResult> Register(RegisterModel user);
        Task<AuthResult> Login(LoginModel user);
    }
}
