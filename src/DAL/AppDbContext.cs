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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=desktop-cn9lbkd\\mssqlserver01;Initial Catalog=for-speak-db;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
            }
        }

    }
}
