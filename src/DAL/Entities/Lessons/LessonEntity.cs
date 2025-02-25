﻿using DAL.Entities.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Lessons
{
    public class LessonEntity
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public LanguageEntity Language { get; set; }

        public string Title { get; set; } 
        public string Theory { get; set; }
    }
}
