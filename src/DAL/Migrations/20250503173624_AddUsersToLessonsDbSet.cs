using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersToLessonsDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AwardedPoints",
                table: "UsersToLessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PointsAwarded",
                table: "UsersToLessons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "QuizCompleted",
                table: "UsersToLessons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReadingCompleted",
                table: "UsersToLessons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SpeakingCompleted",
                table: "UsersToLessons",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwardedPoints",
                table: "UsersToLessons");

            migrationBuilder.DropColumn(
                name: "PointsAwarded",
                table: "UsersToLessons");

            migrationBuilder.DropColumn(
                name: "QuizCompleted",
                table: "UsersToLessons");

            migrationBuilder.DropColumn(
                name: "ReadingCompleted",
                table: "UsersToLessons");

            migrationBuilder.DropColumn(
                name: "SpeakingCompleted",
                table: "UsersToLessons");
        }
    }
}
