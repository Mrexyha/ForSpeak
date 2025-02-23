using DAL.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities.Lessons;
public class LangTask : BaseEntity
{

    [ForeignKey(nameof(Lesson))]
    public int LessonId { get; set; }
    public string ContentJson { get; set; }
    public TaskLevel TaskLevel { get; set; }
    public TaskType Type { get; set; }

    public Lesson Lesson { get; set; }
}
