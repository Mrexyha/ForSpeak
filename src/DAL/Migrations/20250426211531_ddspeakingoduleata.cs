using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ddspeakingoduleata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpeakingModuleEntity_Lessons_LessonId",
                table: "SpeakingModuleEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakingPhraseEntity_SpeakingModuleEntity_SpeakingModuleId",
                table: "SpeakingPhraseEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakingPhraseEntity",
                table: "SpeakingPhraseEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakingModuleEntity",
                table: "SpeakingModuleEntity");

            migrationBuilder.DropColumn(
                name: "AudioUrl",
                table: "SpeakingPhraseEntity");

            migrationBuilder.RenameTable(
                name: "SpeakingPhraseEntity",
                newName: "SpeakingPhrases");

            migrationBuilder.RenameTable(
                name: "SpeakingModuleEntity",
                newName: "SpeakingModules");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakingPhraseEntity_SpeakingModuleId",
                table: "SpeakingPhrases",
                newName: "IX_SpeakingPhrases_SpeakingModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakingModuleEntity_LessonId",
                table: "SpeakingModules",
                newName: "IX_SpeakingModules_LessonId");

            migrationBuilder.AddColumn<double>(
                name: "AverageAccuracy",
                table: "SpeakingModules",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakingPhrases",
                table: "SpeakingPhrases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakingModules",
                table: "SpeakingModules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakingModules_Lessons_LessonId",
                table: "SpeakingModules",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakingPhrases_SpeakingModules_SpeakingModuleId",
                table: "SpeakingPhrases",
                column: "SpeakingModuleId",
                principalTable: "SpeakingModules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpeakingModules_Lessons_LessonId",
                table: "SpeakingModules");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakingPhrases_SpeakingModules_SpeakingModuleId",
                table: "SpeakingPhrases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakingPhrases",
                table: "SpeakingPhrases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakingModules",
                table: "SpeakingModules");

            migrationBuilder.DropColumn(
                name: "AverageAccuracy",
                table: "SpeakingModules");

            migrationBuilder.RenameTable(
                name: "SpeakingPhrases",
                newName: "SpeakingPhraseEntity");

            migrationBuilder.RenameTable(
                name: "SpeakingModules",
                newName: "SpeakingModuleEntity");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakingPhrases_SpeakingModuleId",
                table: "SpeakingPhraseEntity",
                newName: "IX_SpeakingPhraseEntity_SpeakingModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakingModules_LessonId",
                table: "SpeakingModuleEntity",
                newName: "IX_SpeakingModuleEntity_LessonId");

            migrationBuilder.AddColumn<string>(
                name: "AudioUrl",
                table: "SpeakingPhraseEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakingPhraseEntity",
                table: "SpeakingPhraseEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakingModuleEntity",
                table: "SpeakingModuleEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakingModuleEntity_Lessons_LessonId",
                table: "SpeakingModuleEntity",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakingPhraseEntity_SpeakingModuleEntity_SpeakingModuleId",
                table: "SpeakingPhraseEntity",
                column: "SpeakingModuleId",
                principalTable: "SpeakingModuleEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
