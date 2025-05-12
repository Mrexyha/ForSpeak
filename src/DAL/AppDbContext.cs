using DAL.Entities.Languages;
using DAL.Entities.Lessons;
using DAL.Entities.Modules;
using DAL.Entities.Relations;
using DAL.Entities.Tasks;
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
        public DbSet<UserLanguage> UserLanguages { get; set; }

        public DbSet<LanguageEntity> Languages { get; set; }

        public DbSet<LessonEntity> Lessons { get; set; }

        public DbSet<ModuleEntity> Modules { get; set; }
        public DbSet<TaskLangEntity> TaskLangs { get; set; }

        public DbSet<TheoryModuleEntity> TheoryModules { get; set; }

        public DbSet<VocabularyModuleEntity> VocabularyModules { get; set; }
        public DbSet<WordEntity> Words { get; set; }

        public DbSet<ReadingModuleEntity> ReadingModules { get; set; }
        public DbSet<FillInTheBlankTaskEntity> FillInTheBlankTasks { get; set; }

        public DbSet<SpeakingModuleEntity> SpeakingModules { get; set; }
        public DbSet<SpeakingPhraseEntity> SpeakingPhrases { get; set; }

        public DbSet<UsersToLessons> UsersToLessons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TheoryModuleEntity>()
            .ToTable("TheoryModules")
            .HasKey(t => t.Id);

            modelBuilder.Entity<TheoryModuleEntity>()
                .HasOne(t => t.Lesson)
                .WithOne(l => l.Theory)
                .HasForeignKey<TheoryModuleEntity>(t => t.LessonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReadingModuleEntity>()
        .ToTable("ReadingModules")               
        .HasKey(rm => rm.Id);

            modelBuilder.Entity<ReadingModuleEntity>()
        .HasOne(rm => rm.Lesson)
        .WithOne(l => l.Reading)
        .HasForeignKey<ReadingModuleEntity>(rm => rm.LessonId)
        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReadingModuleEntity>()
                .HasOne(rm => rm.Lesson)
                .WithOne(l => l.Reading)
                .HasForeignKey<ReadingModuleEntity>(rm => rm.LessonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FillInTheBlankTaskEntity>()
        .ToTable("FillInTheBlankTasks")          
        .HasKey(tb => tb.Id);

            modelBuilder.Entity<FillInTheBlankTaskEntity>()
                .HasOne(tb => tb.ReadingModule)
                .WithMany(rm => rm.Tasks)
                .HasForeignKey(tb => tb.ReadingModuleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpeakingModuleEntity>()
       .ToTable("SpeakingModules")
       .HasKey(sm => sm.Id);

            modelBuilder.Entity<SpeakingModuleEntity>()
                .HasOne(sm => sm.Lesson)
                .WithOne(l => l.Speaking)
                .HasForeignKey<SpeakingModuleEntity>(sm => sm.LessonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpeakingPhraseEntity>()
       .ToTable("SpeakingPhrases")
       .HasKey(sp => sp.Id);

            modelBuilder.Entity<SpeakingPhraseEntity>()
                .HasOne(sp => sp.SpeakingModule)
                .WithMany(sm => sm.Phrases)
                .HasForeignKey(sp => sp.SpeakingModuleId)
                .OnDelete(DeleteBehavior.Cascade);

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
                    FlagImage = "/assets/main/UK-flag.jpg",
                    CountryImage = "/assets/main/UK-main.jpg",
                    Description = "Англійська мова відкриває доступ до кращих освітніх, кар'єрних та культурних можливостей у світі, а також допомагає спілкуватися з людьми з різних країн. Це універсальний інструмент для подорожей, саморозвитку та успіху в багатьох сферах життя."
                },
                new LanguageEntity
                {
                    Id = 2,
                    Name = "Французька мова",
                    FlagImage = "/assets/main/France-flag.jpg",
                    CountryImage = "/assets/main/France-main.jpg",
                    Description = "Французька мова є однією з основних мов міжнародної дипломатії, культури та мистецтва, відкриваючи доступ до освіти та роботи у франкомовних країнах. Вона також корисна для подорожей і розширює можливості у спілкуванні по всьому світу."
                },
                new LanguageEntity
                {
                    Id = 3,
                    Name = "Німецька мова",
                    FlagImage = "/assets/main/Germany-flag.jpg",
                    CountryImage = "/assets/main/Germany-main.jpg",
                    Description = "Німецька мова відкриває доступ до якісної освіти, кар'єрних можливостей у Європі та культурної спадщини німецькомовних країн. Вона також корисна для подорожей і бізнесу, адже є однією з найпоширеніших мов у ЄС."
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
