using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Results
{
    public class SpeakingResultEntity
    {
        public int Id { get; set; }

        public int LessonId { get; set; }

        public int UserId { get; set; }

        public double AverageAccuracy { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
