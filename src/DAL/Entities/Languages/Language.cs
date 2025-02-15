using DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Languages
{
    public class Language
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public List<User> Users { get; set; }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
