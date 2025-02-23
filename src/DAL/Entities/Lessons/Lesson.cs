using DAL.Entities.Relations;

namespace DAL.Entities.Lessons;
public class Lesson : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<LangTask> Tasks { get; set; } = new();
    public UsersToLessons UsersToLessons { get; set; }
}
