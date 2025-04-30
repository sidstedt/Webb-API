using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Test.Migrations
{
    /// <inheritdoc />
    public partial class Add_LinkTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "LinkName", "PeopleInterestId" },
                values: new object[,]
                {
                    { 1, "https://github.com", 2 },
                    { 2, "https://stackoverflow.com", 2 },
                    { 3, "https://www.gamereactor.com", 1 },
                    { 4, "https://www.fz.se", 1 },
                    { 5, "https://www.recept.se", 3 },
                    { 6, "https://www.koket.se", 3 },
                    { 7, "https://www.matklubben.se", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
