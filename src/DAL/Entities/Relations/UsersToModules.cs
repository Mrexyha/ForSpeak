using DAL.Entities.Lessons;
using DAL.Entities.Modules;
using DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Relations
{
    public class UsersToModules : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        [ForeignKey(nameof(Module))]
        public int ModuleId { get; set; }
        public ModuleEntity Module { get; set; }

        public bool IsCompleted { get; set; }
    }
}
