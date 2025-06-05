using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.User
{
    public class AuthResult
    {
        public string Token { get; set; } = null!;
        public int UserId { get; set; }
    }
}
