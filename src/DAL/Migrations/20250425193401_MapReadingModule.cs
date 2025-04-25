using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class MapReadingModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FillInTheBlankTaskEntity_ReadingModuleEntity_ReadingModuleId",
                table: "FillInTheBlankTaskEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ReadingModuleEntity_Lessons_LessonId",
                table: "ReadingModuleEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReadingModuleEntity",
                table: "ReadingModuleEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FillInTheBlankTaskEntity",
                table: "FillInTheBlankTaskEntity");

            migrationBuilder.RenameTable(
                name: "ReadingModuleEntity",
                newName: "ReadingModules");

            migrationBuilder.RenameTable(
                name: "FillInTheBlankTaskEntity",
                newName: "FillInTheBlankTasks");

            migrationBuilder.RenameIndex(
                name: "IX_ReadingModuleEntity_LessonId",
                table: "ReadingModules",
                newName: "IX_ReadingModules_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_FillInTheBlankTaskEntity_ReadingModuleId",
                table: "FillInTheBlankTasks",
                newName: "IX_FillInTheBlankTasks_ReadingModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReadingModules",
                table: "ReadingModules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FillInTheBlankTasks",
                table: "FillInTheBlankTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FillInTheBlankTasks_ReadingModules_ReadingModuleId",
                table: "FillInTheBlankTasks",
                column: "ReadingModuleId",
                principalTable: "ReadingModules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingModules_Lessons_LessonId",
                table: "ReadingModules",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FillInTheBlankTasks_ReadingModules_ReadingModuleId",
                table: "FillInTheBlankTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ReadingModules_Lessons_LessonId",
                table: "ReadingModules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReadingModules",
                table: "ReadingModules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FillInTheBlankTasks",
                table: "FillInTheBlankTasks");

            migrationBuilder.RenameTable(
                name: "ReadingModules",
                newName: "ReadingModuleEntity");

            migrationBuilder.RenameTable(
                name: "FillInTheBlankTasks",
                newName: "FillInTheBlankTaskEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ReadingModules_LessonId",
                table: "ReadingModuleEntity",
                newName: "IX_ReadingModuleEntity_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_FillInTheBlankTasks_ReadingModuleId",
                table: "FillInTheBlankTaskEntity",
                newName: "IX_FillInTheBlankTaskEntity_ReadingModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReadingModuleEntity",
                table: "ReadingModuleEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FillInTheBlankTaskEntity",
                table: "FillInTheBlankTaskEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FillInTheBlankTaskEntity_ReadingModuleEntity_ReadingModuleId",
                table: "FillInTheBlankTaskEntity",
                column: "ReadingModuleId",
                principalTable: "ReadingModuleEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingModuleEntity_Lessons_LessonId",
                table: "ReadingModuleEntity",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
