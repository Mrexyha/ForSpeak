using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCountryImagePaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CountryImage",
                value: "/assets/main/UK-main.jpg");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CountryImage", "FlagImage" },
                values: new object[] { "/assets/main/France-main.jpg", "/assets/main/France-flag.jpg" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CountryImage", "FlagImage" },
                values: new object[] { "/assets/main/Germany-main.jpg", "/assets/main/Germany-flag.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CountryImage",
                value: "../View/for-speak/src/assets/main/UK-main.jpg");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CountryImage", "FlagImage" },
                values: new object[] { "../View/for-speak/src/assets/main/France-main.jpg", "../View/for-speak/src/assets/main/France-flag.jpg" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CountryImage", "FlagImage" },
                values: new object[] { "../View/for-speak/src/assets/main/Germany-main.jpg", "../View/for-speak/src/assets/main/Germany-flag.jpg" });
        }
    }
}
