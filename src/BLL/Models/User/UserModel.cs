using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.User
{
    public class UserModel:BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public ICollection<int>? TestResultEntities { get; set; } = new List<int>();

        public UserModel() { }
    }
}
