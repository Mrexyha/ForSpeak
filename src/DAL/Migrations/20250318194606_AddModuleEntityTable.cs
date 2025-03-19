using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddModuleEntityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersToLessons_LessonId",
                table: "UsersToLessons");

            migrationBuilder.AddColumn<int>(
                name: "ModuleEntityId",
                table: "TaskLangEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "LessonEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ModuleEntities",
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
                    table.PrimaryKey("PK_ModuleEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleEntities_LessonEntity_LessonId",
                        column: x => x.LessonId,
                        principalTable: "LessonEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Англійська мова");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Французька мова");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Німецька мова");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToLessons_LessonId",
                table: "UsersToLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskLangEntity_ModuleEntityId",
                table: "TaskLangEntity",
                column: "ModuleEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleEntities_LessonId",
                table: "ModuleEntities",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLangEntity_ModuleEntities_ModuleEntityId",
                table: "TaskLangEntity",
                column: "ModuleEntityId",
                principalTable: "ModuleEntities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskLangEntity_ModuleEntities_ModuleEntityId",
                table: "TaskLangEntity");

            migrationBuilder.DropTable(
                name: "ModuleEntities");

            migrationBuilder.DropIndex(
                name: "IX_UsersToLessons_LessonId",
                table: "UsersToLessons");

            migrationBuilder.DropIndex(
                name: "IX_TaskLangEntity_ModuleEntityId",
                table: "TaskLangEntity");

            migrationBuilder.DropColumn(
                name: "ModuleEntityId",
                table: "TaskLangEntity");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "LessonEntity");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Англійська");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Французька");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Німецька");

            migrationBuilder.CreateIndex(
                name: "IX_UsersToLessons_LessonId",
                table: "UsersToLessons",
                column: "LessonId",
                unique: true);
        }
    }
}
