using DAL.Entities.Languages;
using DAL.Entities.Relations;

namespace DAL.Entities.Users
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public List<Language> Languages { get; set; }
        public UsersToLessons UsersToLessons { get; set; }
    }
}
