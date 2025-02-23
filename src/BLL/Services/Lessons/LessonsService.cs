using DAL.Entities.Lessons;
using DAL.Repositories.Lessons;
using DLL.Repositories;

namespace BLL.Services.Lessons;
internal class LessonsService : ILessonsService
{
    private readonly ILessonRepository _lessonRepository;

    public LessonsService(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<Lesson> AddLessonAsync(Lesson lesson)
    {
        await _lessonRepository.AddAsync(lesson);

        return lesson;
    }

    public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
    {
        var lessons = await _lessonRepository.GetAllAsync();

        return lessons;
    }

    public async Task<Lesson> GetLessonAsync(int lessonId)
    {
        var lesson = await _lessonRepository.GetByIdAsync(lessonId);

        return lesson;
    }

    public async Task<int> GetUserPoints(int userId)
    {
        var points = await _lessonRepository.GetUserPointsAsync(userId);

        return points;
    }

    public async Task<Lesson> UpdateLessonAsync(Lesson lesson)
    {
        await _lessonRepository.UpdateAsync(lesson);

        return lesson; throw new NotImplementedException();
    }
}
