using DAL.Entities.Lessons;
using DLL.Repositories;

namespace DAL.Repositories.Lessons;
public interface ILessonRepository : IBaseRepository<Lesson>
{
    public Task<int> GetUserPointsAsync(int userId);
}
