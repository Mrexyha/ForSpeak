using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixModuleLanguageFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlagImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguages",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Progress = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguages", x => new { x.UserId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_UserLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLanguages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizModules_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadingModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingModules_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeakingModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    AverageAccuracy = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakingModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeakingModules_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TheoryModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheoryModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheoryModules_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersToLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    QuizCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ReadingCompleted = table.Column<bool>(type: "bit", nullable: false),
                    SpeakingCompleted = table.Column<bool>(type: "bit", nullable: false),
                    PointsAwarded = table.Column<bool>(type: "bit", nullable: false),
                    AwardedPoints = table.Column<int>(type: "int", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersToLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersToLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersToLessons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VocabularyModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VocabularyModules_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    ContentJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskLangs_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectOptionIndex = table.Column<int>(type: "int", nullable: false),
                    QuizModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_QuizModules_QuizModuleId",
                        column: x => x.QuizModuleId,
                        principalTable: "QuizModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FillInTheBlankTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sentence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReadingModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FillInTheBlankTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FillInTheBlankTasks_ReadingModules_ReadingModuleId",
                        column: x => x.ReadingModuleId,
                        principalTable: "ReadingModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeakingPhrases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeakingModuleId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accuracy = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakingPhrases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeakingPhrases_SpeakingModules_SpeakingModuleId",
                        column: x => x.SpeakingModuleId,
                        principalTable: "SpeakingModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transcription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VocabularyModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_VocabularyModules_VocabularyModuleId",
                        column: x => x.VocabularyModuleId,
                        principalTable: "VocabularyModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeakingPhraseAttempts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeakingPhraseId = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<double>(type: "float", nullable: false),
                    AttemptedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakingPhraseAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeakingPhraseAttempts_SpeakingPhrases_SpeakingPhraseId",
                        column: x => x.SpeakingPhraseId,
                        principalTable: "SpeakingPhrases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CountryImage", "Description", "FlagImage", "Name", "UserEntityId" },
                values: new object[,]
                {
                    { 1, "/assets/main/UK-main.jpg", "Англійська мова відкриває доступ до кращих освітніх, кар'єрних та культурних можливостей у світі, а також допомагає спілкуватися з людьми з різних країн. Це універсальний інструмент для подорожей, саморозвитку та успіху в багатьох сферах життя.", "/assets/main/UK-flag.jpg", "Англійська мова", null },
                    { 2, "/assets/main/France-main.jpg", "Французька мова є однією з основних мов міжнародної дипломатії, культури та мистецтва, відкриваючи доступ до освіти та роботи у франкомовних країнах. Вона також корисна для подорожей і розширює можливості у спілкуванні по всьому світу.", "/assets/main/France-flag.jpg", "Французька мова", null },
                    { 3, "/assets/main/Germany-main.jpg", "Німецька мова відкриває доступ до якісної освіти, кар'єрних можливостей у Європі та культурної спадщини німецькомовних країн. Вона також корисна для подорожей і бізнесу, адже є однією з найпоширеніших мов у ЄС.", "/assets/main/Germany-flag.jpg", "Німецька мова", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FillInTheBlankTasks_ReadingModuleId",
                table: "FillInTheBlankTasks",
                column: "ReadingModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_UserEntityId",
                table: "Languages",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LanguageId",
                table: "Lessons",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_LessonId",
                table: "Modules",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizModules_LessonId",
                table: "QuizModules",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuizModuleId",
                table: "QuizQuestions",
                column: "QuizModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingModules_LessonId",
                table: "ReadingModules",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpeakingModules_LessonId",
                table: "SpeakingModules",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpeakingPhraseAttempts_SpeakingPhraseId",
                table: "SpeakingPhraseAttempts",
                column: "SpeakingPhraseId");

            migrationBuilder.CreateIndex(
                name: "IX_SpeakingPhrases_SpeakingModuleId",
                table: "SpeakingPhrases",
                column: "SpeakingModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLangs_ModuleId",
                table: "TaskLangs",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_TheoryModules_LessonId",
                table: "TheoryModules",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_LanguageId",
                table: "UserLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToLessons_LessonId",
                table: "UsersToLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToLessons_UserId",
                table: "UsersToLessons",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyModules_LessonId",
                table: "VocabularyModules",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_VocabularyModuleId",
                table: "Words",
                column: "VocabularyModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FillInTheBlankTasks");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "SpeakingPhraseAttempts");

            migrationBuilder.DropTable(
                name: "TaskLangs");

            migrationBuilder.DropTable(
                name: "TheoryModules");

            migrationBuilder.DropTable(
                name: "UserLanguages");

            migrationBuilder.DropTable(
                name: "UsersToLessons");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "ReadingModules");

            migrationBuilder.DropTable(
                name: "QuizModules");

            migrationBuilder.DropTable(
                name: "SpeakingPhrases");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "VocabularyModules");

            migrationBuilder.DropTable(
                name: "SpeakingModules");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
