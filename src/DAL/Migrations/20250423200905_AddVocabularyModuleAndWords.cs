using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddVocabularyModuleAndWords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VocabularyModuleEntity_Lessons_LessonId",
                table: "VocabularyModuleEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_WordEntity_VocabularyModuleEntity_VocabularyModuleId",
                table: "WordEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordEntity",
                table: "WordEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VocabularyModuleEntity",
                table: "VocabularyModuleEntity");

            migrationBuilder.DropColumn(
                name: "AudioUrl",
                table: "WordEntity");

            migrationBuilder.RenameTable(
                name: "WordEntity",
                newName: "Words");

            migrationBuilder.RenameTable(
                name: "VocabularyModuleEntity",
                newName: "VocabularyModules");

            migrationBuilder.RenameIndex(
                name: "IX_WordEntity_VocabularyModuleId",
                table: "Words",
                newName: "IX_Words_VocabularyModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_VocabularyModuleEntity_LessonId",
                table: "VocabularyModules",
                newName: "IX_VocabularyModules_LessonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Words",
                table: "Words",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VocabularyModules",
                table: "VocabularyModules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VocabularyModules_Lessons_LessonId",
                table: "VocabularyModules",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_VocabularyModules_VocabularyModuleId",
                table: "Words",
                column: "VocabularyModuleId",
                principalTable: "VocabularyModules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VocabularyModules_Lessons_LessonId",
                table: "VocabularyModules");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_VocabularyModules_VocabularyModuleId",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Words",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VocabularyModules",
                table: "VocabularyModules");

            migrationBuilder.RenameTable(
                name: "Words",
                newName: "WordEntity");

            migrationBuilder.RenameTable(
                name: "VocabularyModules",
                newName: "VocabularyModuleEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Words_VocabularyModuleId",
                table: "WordEntity",
                newName: "IX_WordEntity_VocabularyModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_VocabularyModules_LessonId",
                table: "VocabularyModuleEntity",
                newName: "IX_VocabularyModuleEntity_LessonId");

            migrationBuilder.AddColumn<string>(
                name: "AudioUrl",
                table: "WordEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordEntity",
                table: "WordEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VocabularyModuleEntity",
                table: "VocabularyModuleEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VocabularyModuleEntity_Lessons_LessonId",
                table: "VocabularyModuleEntity",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordEntity_VocabularyModuleEntity_VocabularyModuleId",
                table: "WordEntity",
                column: "VocabularyModuleId",
                principalTable: "VocabularyModuleEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
