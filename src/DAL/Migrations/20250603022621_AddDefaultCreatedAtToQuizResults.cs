using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultCreatedAtToQuizResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizResults_Lessons_LessonId",
                table: "QuizResults");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizResults_Users_UserId",
                table: "QuizResults");

            migrationBuilder.DropIndex(
                name: "IX_QuizResults_LessonId",
                table: "QuizResults");

            migrationBuilder.DropIndex(
                name: "IX_QuizResults_UserId",
                table: "QuizResults");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_LessonId",
                table: "QuizResults",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_UserId",
                table: "QuizResults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResults_Lessons_LessonId",
                table: "QuizResults",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizResults_Users_UserId",
                table: "QuizResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
