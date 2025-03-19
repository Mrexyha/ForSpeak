using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModuleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskLangEntity_LessonEntity_LessonId",
                table: "TaskLangEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskLangEntity_ModuleEntities_ModuleEntityId",
                table: "TaskLangEntity");

            migrationBuilder.DropIndex(
                name: "IX_TaskLangEntity_LessonId",
                table: "TaskLangEntity");

            migrationBuilder.DropIndex(
                name: "IX_TaskLangEntity_ModuleEntityId",
                table: "TaskLangEntity");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "TaskLangEntity");

            migrationBuilder.DropColumn(
                name: "ModuleEntityId",
                table: "TaskLangEntity");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "LessonEntity");

            migrationBuilder.DropColumn(
                name: "Theory",
                table: "LessonEntity");

            migrationBuilder.RenameColumn(
                name: "TaskLevel",
                table: "TaskLangEntity",
                newName: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLangEntity_ModuleId",
                table: "TaskLangEntity",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLangEntity_ModuleEntities_ModuleId",
                table: "TaskLangEntity",
                column: "ModuleId",
                principalTable: "ModuleEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskLangEntity_ModuleEntities_ModuleId",
                table: "TaskLangEntity");

            migrationBuilder.DropIndex(
                name: "IX_TaskLangEntity_ModuleId",
                table: "TaskLangEntity");

            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "TaskLangEntity",
                newName: "TaskLevel");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "TaskLangEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModuleEntityId",
                table: "TaskLangEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LessonEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Theory",
                table: "LessonEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLangEntity_LessonId",
                table: "TaskLangEntity",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLangEntity_ModuleEntityId",
                table: "TaskLangEntity",
                column: "ModuleEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLangEntity_LessonEntity_LessonId",
                table: "TaskLangEntity",
                column: "LessonId",
                principalTable: "LessonEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLangEntity_ModuleEntities_ModuleEntityId",
                table: "TaskLangEntity",
                column: "ModuleEntityId",
                principalTable: "ModuleEntities",
                principalColumn: "Id");
        }
    }
}
