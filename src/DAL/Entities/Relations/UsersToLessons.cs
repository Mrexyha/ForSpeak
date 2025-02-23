using DAL.Entities.Lessons;
using DAL.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Relations;
public class UsersToLessons : BaseEntity
{
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }

    [ForeignKey(nameof(Lesson))]
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; }
}