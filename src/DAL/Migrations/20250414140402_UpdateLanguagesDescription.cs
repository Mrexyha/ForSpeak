using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLanguagesDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Англійська мова відкриває доступ до кращих освітніх, кар'єрних та культурних можливостей у світі, а також допомагає спілкуватися з людьми з різних країн. Це універсальний інструмент для подорожей, саморозвитку та успіху в багатьох сферах життя.");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Французька мова є однією з основних мов міжнародної дипломатії, культури та мистецтва, відкриваючи доступ до освіти та роботи у франкомовних країнах. Вона також корисна для подорожей і розширює можливості у спілкуванні по всьому світу.");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Німецька мова відкриває доступ до якісної освіти, кар'єрних можливостей у Європі та культурної спадщини німецькомовних країн. Вона також корисна для подорожей і бізнесу, адже є однією з найпоширеніших мов у ЄС.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Англійська мова відкриває доступ до кращих освітніх, кар'єрних та культурних можливостей у світі...");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Французька мова є однією з основних мов міжнародної дипломатії...");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Німецька мова відкриває доступ до якісної освіти, кар'єрних можливостей у Європі...");
        }
    }
}
