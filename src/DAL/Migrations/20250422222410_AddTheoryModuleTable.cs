using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTheoryModuleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonEntity_Languages_LanguageId",
                table: "LessonEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleEntities_LessonEntity_LessonId",
                table: "ModuleEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskLangEntity_ModuleEntities_ModuleId",
                table: "TaskLangEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersToLessons_LessonEntity_LessonId",
                table: "UsersToLessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskLangEntity",
                table: "TaskLangEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuleEntities",
                table: "ModuleEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LessonEntity",
                table: "LessonEntity");

            migrationBuilder.RenameTable(
                name: "TaskLangEntity",
                newName: "TaskLangs");

            migrationBuilder.RenameTable(
                name: "ModuleEntities",
                newName: "Modules");

            migrationBuilder.RenameTable(
                name: "LessonEntity",
                newName: "Lessons");

            migrationBuilder.RenameIndex(
                name: "IX_TaskLangEntity_ModuleId",
                table: "TaskLangs",
                newName: "IX_TaskLangs_ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleEntities_LessonId",
                table: "Modules",
                newName: "IX_Modules_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_LessonEntity_LanguageId",
                table: "Lessons",
                newName: "IX_Lessons_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskLangs",
                table: "TaskLangs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modules",
                table: "Modules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "QuizModuleEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizModuleEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizModuleEntity_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadingModuleEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingModuleEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReadingModuleEntity_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeakingModuleEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakingModuleEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeakingModuleEntity_Lessons_LessonId",
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
                name: "VocabularyModuleEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyModuleEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VocabularyModuleEntity_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestionEntity",
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
                    table.PrimaryKey("PK_QuizQuestionEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestionEntity_QuizModuleEntity_QuizModuleId",
                        column: x => x.QuizModuleId,
                        principalTable: "QuizModuleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FillInTheBlankTaskEntity",
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
                    table.PrimaryKey("PK_FillInTheBlankTaskEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FillInTheBlankTaskEntity_ReadingModuleEntity_ReadingModuleId",
                        column: x => x.ReadingModuleId,
                        principalTable: "ReadingModuleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpeakingPhraseEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudioUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeakingModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakingPhraseEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeakingPhraseEntity_SpeakingModuleEntity_SpeakingModuleId",
                        column: x => x.SpeakingModuleId,
                        principalTable: "SpeakingModuleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transcription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudioUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VocabularyModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordEntity_VocabularyModuleEntity_VocabularyModuleId",
                        column: x => x.VocabularyModuleId,
                        principalTable: "VocabularyModuleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FillInTheBlankTaskEntity_ReadingModuleId",
                table: "FillInTheBlankTaskEntity",
                column: "ReadingModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizModuleEntity_LessonId",
                table: "QuizModuleEntity",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestionEntity_QuizModuleId",
                table: "QuizQuestionEntity",
                column: "QuizModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingModuleEntity_LessonId",
                table: "ReadingModuleEntity",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpeakingModuleEntity_LessonId",
                table: "SpeakingModuleEntity",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpeakingPhraseEntity_SpeakingModuleId",
                table: "SpeakingPhraseEntity",
                column: "SpeakingModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_TheoryModules_LessonId",
                table: "TheoryModules",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyModuleEntity_LessonId",
                table: "VocabularyModuleEntity",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WordEntity_VocabularyModuleId",
                table: "WordEntity",
                column: "VocabularyModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Languages_LanguageId",
                table: "Lessons",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Lessons_LessonId",
                table: "Modules",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLangs_Modules_ModuleId",
                table: "TaskLangs",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersToLessons_Lessons_LessonId",
                table: "UsersToLessons",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Languages_LanguageId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Lessons_LessonId",
                table: "Modules");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskLangs_Modules_ModuleId",
                table: "TaskLangs");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersToLessons_Lessons_LessonId",
                table: "UsersToLessons");

            migrationBuilder.DropTable(
                name: "FillInTheBlankTaskEntity");

            migrationBuilder.DropTable(
                name: "QuizQuestionEntity");

            migrationBuilder.DropTable(
                name: "SpeakingPhraseEntity");

            migrationBuilder.DropTable(
                name: "TheoryModules");

            migrationBuilder.DropTable(
                name: "WordEntity");

            migrationBuilder.DropTable(
                name: "ReadingModuleEntity");

            migrationBuilder.DropTable(
                name: "QuizModuleEntity");

            migrationBuilder.DropTable(
                name: "SpeakingModuleEntity");

            migrationBuilder.DropTable(
                name: "VocabularyModuleEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskLangs",
                table: "TaskLangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modules",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lessons",
                table: "Lessons");

            migrationBuilder.RenameTable(
                name: "TaskLangs",
                newName: "TaskLangEntity");

            migrationBuilder.RenameTable(
                name: "Modules",
                newName: "ModuleEntities");

            migrationBuilder.RenameTable(
                name: "Lessons",
                newName: "LessonEntity");

            migrationBuilder.RenameIndex(
                name: "IX_TaskLangs_ModuleId",
                table: "TaskLangEntity",
                newName: "IX_TaskLangEntity_ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_Modules_LessonId",
                table: "ModuleEntities",
                newName: "IX_ModuleEntities_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Lessons_LanguageId",
                table: "LessonEntity",
                newName: "IX_LessonEntity_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskLangEntity",
                table: "TaskLangEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuleEntities",
                table: "ModuleEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LessonEntity",
                table: "LessonEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonEntity_Languages_LanguageId",
                table: "LessonEntity",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleEntities_LessonEntity_LessonId",
                table: "ModuleEntities",
                column: "LessonId",
                principalTable: "LessonEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLangEntity_ModuleEntities_ModuleId",
                table: "TaskLangEntity",
                column: "ModuleId",
                principalTable: "ModuleEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersToLessons_LessonEntity_LessonId",
                table: "UsersToLessons",
                column: "LessonId",
                principalTable: "LessonEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
