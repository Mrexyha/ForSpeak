using DAL.Entities.Lessons;
using DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Results
{
    public class QuizResultEntity
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int UserId { get; set; }
        public double Score { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
