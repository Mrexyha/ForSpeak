using DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Users
{
    public interface IUserRepository
    {
        User GetById(int id);
        List<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
