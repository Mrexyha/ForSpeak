using DAL.Entities.Users;

namespace DAL.Entities.Languages
{
    public class Language : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
    }
}
