using DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Lessons
{
    public class SpeechRecognition
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string Phrase { get; set; } 
        public double Accuracy { get; set; } 
    }
}
