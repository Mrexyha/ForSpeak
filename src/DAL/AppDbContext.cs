using DAL.Entities.Languages;
using DAL.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(){ }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<LanguageEntity> Languages { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LanguageEntity>().HasData(
                new LanguageEntity
                {
                    Id = 1,
                    Name = "Англійська мова",
                    FlagImage = "..\\View\\for-speak\\src\\assets\\main\\UK-flag.jpg",
                    CountryImage = "..\\View\\for-speak\\src\\assets\\main\\UK-main.jpg",
                    Description = "Англійська мова відкриває доступ до кращих освітніх, кар'єрних та культурних можливостей у світі, а також допомагає спілкуватися з людьми з різних країн. Це універсальний інструмент для подорожей, саморозвитку та успіху в багатьох сферах життя.",
                },
                new LanguageEntity
                {
                    Id = 2,
                    Name = "Французька мова",
                    FlagImage = "View\\for-speak\\src\\assets\\main\\France-flag.jpg",
                    CountryImage = "View\\for-speak\\src\\assets\\main\\France-main.jpg",
                    Description = "Французька мова є однією з основних мов міжнародної дипломатії, культури та мистецтва, відкриваючи доступ до освіти та роботи у франкомовних країнах. Вона також корисна для подорожей і розширює можливості у спілкуванні по всьому світу.",
                },
                new LanguageEntity
                {
                    Id = 3,
                    Name = "Німецька мова",
                    FlagImage = "View\\for-speak\\src\\assets\\main\\Germany-flag.jpg",
                    CountryImage = "View\\for-speak\\src\\assets\\main\\Germany-main.jpg",
                    Description = "Німецька мова відкриває доступ до якісної освіти, кар'єрних можливостей у Європі та культурної спадщини німецькомовних країн. Вона також корисна для подорожей і бізнесу, адже є однією з найпоширеніших мов у ЄС.",
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=desktop-cn9lbkd\\mssqlserver01;Initial Catalog=for-speak-db;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
            }
        }

    }
}
