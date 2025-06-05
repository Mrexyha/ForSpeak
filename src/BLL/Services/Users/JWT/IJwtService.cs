using BLL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Users.JWT
{
    public interface IJwtService
    {
        string GenerateToken(UserModel user);
    }
}
