using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Test.Migrations
{
    /// <inheritdoc />
    public partial class add_PeopleInterest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "PeopleInterests");

            migrationBuilder.InsertData(
                table: "PeopleInterests",
                columns: new[] { "Id", "InterestId", "PeopleId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 1, 2 },
                    { 3, 3, 2 },
                    { 4, 2, 3 },
                    { 5, 3, 3 },
                    { 6, 1, 4 },
                    { 7, 2, 4 },
                    { 8, 3, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PeopleInterests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PeopleInterests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PeopleInterests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PeopleInterests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PeopleInterests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PeopleInterests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PeopleInterests",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PeopleInterests",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "PeopleInterests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
