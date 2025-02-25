using DAL.Entities.Lessons;
using DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Relations
{
    public class UsersToLessons : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        [ForeignKey(nameof(Lesson))]
        public int LessonId { get; set; }
        public LessonEntity Lesson { get; set; }
    }
}
