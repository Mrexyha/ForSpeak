﻿using DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Languages
{
    public class LanguageEntity : BaseEntity
    {
        public string Name { get; set; }
        public string FlagImage { get; set; } 
        public string CountryImage { get; set; }
        public string Description { get; set; }

        public List<UserEntity> Users { get; set; }
    }
}
