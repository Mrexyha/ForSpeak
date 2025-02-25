using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Lessons;

namespace DAL.Repositories.Lessons
{
    public interface ILessonRepository : IBaseRepository<LessonEntity>
    {
        public Task<int> GetUserPointsAsync(int userId);
    }
}
