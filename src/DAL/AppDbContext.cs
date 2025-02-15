using DAL.Entities.Languages;
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

        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Language>().HasData(
                new Language
                {
                    Id = 1,
                    Name = "Англійська",
                    FlagImage = "uk_flag.png",
                    CountryImage = "uk_flag.png",
                    Description = "Description UK",
                },
                new Language
                {
                    Id = 2,
                    Name = "Французька",
                    FlagImage = "fr_flag.png",
                    CountryImage = "fr_flag.png",
                    Description = "Description FR",
                },
                new Language
                {
                    Id = 3,
                    Name = "Німецька",
                    FlagImage = "de_flag.png",
                    CountryImage = "de_flag.png",
                    Description = "Description DE",
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
