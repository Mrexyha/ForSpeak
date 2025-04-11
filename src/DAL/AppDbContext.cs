using DAL.Entities.Languages;
using DAL.Entities.Modules;
using DAL.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<LanguageEntity> Languages { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<ModuleEntity> ModuleEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserLanguage>()
                .HasKey(ul => new { ul.UserId, ul.LanguageId });

            modelBuilder.Entity<UserLanguage>()
                .HasOne(ul => ul.User)
                .WithMany(u => u.UserLanguages)
                .HasForeignKey(ul => ul.UserId);

            modelBuilder.Entity<UserLanguage>()
                .HasOne(ul => ul.Language)
                .WithMany(l => l.UserLanguages)
                .HasForeignKey(ul => ul.LanguageId);

            modelBuilder.Entity<LanguageEntity>().HasData(
                new LanguageEntity
                {
                    Id = 1,
                    Name = "Англійська мова",
                    FlagImage = "..\\View\\for-speak\\src\\assets\\main\\UK-flag.jpg",
                    CountryImage = "..\\View\\for-speak\\src\\assets\\main\\UK-main.jpg",
                    Description = "Англійська мова відкриває доступ до кращих освітніх, кар'єрних та культурних можливостей у світі..."
                },
                new LanguageEntity
                {
                    Id = 2,
                    Name = "Французька мова",
                    FlagImage = "View\\for-speak\\src\\assets\\main\\France-flag.jpg",
                    CountryImage = "View\\for-speak\\src\\assets\\main\\France-main.jpg",
                    Description = "Французька мова є однією з основних мов міжнародної дипломатії..."
                },
                new LanguageEntity
                {
                    Id = 3,
                    Name = "Німецька мова",
                    FlagImage = "View\\for-speak\\src\\assets\\main\\Germany-flag.jpg",
                    CountryImage = "View\\for-speak\\src\\assets\\main\\Germany-main.jpg",
                    Description = "Німецька мова відкриває доступ до якісної освіти, кар'єрних можливостей у Європі..."
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=desktop-cn9lbkd\\mssqlserver01;Initial Catalog=for-speak-db;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
            }
        }
    }
}
