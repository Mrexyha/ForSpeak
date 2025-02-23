using DAL.Entities.Lessons;

namespace BLL.Services.Lessons;
public interface ILessonsService
{
    public Task<IEnumerable<Lesson>> GetAllLessonsAsync();
    public Task<Lesson> GetLessonAsync(int lessonId);
    public Task<Lesson> AddLessonAsync(Lesson lesson);
    public Task<Lesson> UpdateLessonAsync(Lesson lesson);
    public Task<int> GetUserPoints(int userId);
}
