using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddQuizModulesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizModuleEntity_Lessons_LessonId",
                table: "QuizModuleEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestionEntity_QuizModuleEntity_QuizModuleId",
                table: "QuizQuestionEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizQuestionEntity",
                table: "QuizQuestionEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizModuleEntity",
                table: "QuizModuleEntity");

            migrationBuilder.RenameTable(
                name: "QuizQuestionEntity",
                newName: "QuizQuestions");

            migrationBuilder.RenameTable(
                name: "QuizModuleEntity",
                newName: "QuizModules");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestionEntity_QuizModuleId",
                table: "QuizQuestions",
                newName: "IX_QuizQuestions_QuizModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizModuleEntity_LessonId",
                table: "QuizModules",
                newName: "IX_QuizModules_LessonId");

            migrationBuilder.AddColumn<double>(
                name: "Accuracy",
                table: "SpeakingPhrases",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizQuestions",
                table: "QuizQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizModules",
                table: "QuizModules",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_SpeakingPhraseAttempts_SpeakingPhraseId",
                table: "SpeakingPhraseAttempts",
                column: "SpeakingPhraseId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizModules_Lessons_LessonId",
                table: "QuizModules",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_QuizModules_QuizModuleId",
                table: "QuizQuestions",
                column: "QuizModuleId",
                principalTable: "QuizModules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizModules_Lessons_LessonId",
                table: "QuizModules");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_QuizModules_QuizModuleId",
                table: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "SpeakingPhraseAttempts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizQuestions",
                table: "QuizQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizModules",
                table: "QuizModules");

            migrationBuilder.DropColumn(
                name: "Accuracy",
                table: "SpeakingPhrases");

            migrationBuilder.RenameTable(
                name: "QuizQuestions",
                newName: "QuizQuestionEntity");

            migrationBuilder.RenameTable(
                name: "QuizModules",
                newName: "QuizModuleEntity");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestions_QuizModuleId",
                table: "QuizQuestionEntity",
                newName: "IX_QuizQuestionEntity_QuizModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizModules_LessonId",
                table: "QuizModuleEntity",
                newName: "IX_QuizModuleEntity_LessonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizQuestionEntity",
                table: "QuizQuestionEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizModuleEntity",
                table: "QuizModuleEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizModuleEntity_Lessons_LessonId",
                table: "QuizModuleEntity",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestionEntity_QuizModuleEntity_QuizModuleId",
                table: "QuizQuestionEntity",
                column: "QuizModuleId",
                principalTable: "QuizModuleEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
