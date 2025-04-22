using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Test.Migrations
{
    /// <inheritdoc />
    public partial class relationtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InterestLink",
                columns: new[] { "InterestsId", "LinksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 }
                });

            migrationBuilder.InsertData(
                table: "InterestPeople",
                columns: new[] { "InterestsId", "PeopleId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "LinkPeople",
                columns: new[] { "LinksId", "PeopleId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 4 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 3 },
                    { 4, 4 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 4 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InterestLink",
                keyColumns: new[] { "InterestsId", "LinksId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "InterestLink",
                keyColumns: new[] { "InterestsId", "LinksId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "InterestLink",
                keyColumns: new[] { "InterestsId", "LinksId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "InterestLink",
                keyColumns: new[] { "InterestsId", "LinksId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "InterestLink",
                keyColumns: new[] { "InterestsId", "LinksId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "InterestLink",
                keyColumns: new[] { "InterestsId", "LinksId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "InterestLink",
                keyColumns: new[] { "InterestsId", "LinksId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "InterestPeople",
                keyColumns: new[] { "InterestsId", "PeopleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "InterestPeople",
                keyColumns: new[] { "InterestsId", "PeopleId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "InterestPeople",
                keyColumns: new[] { "InterestsId", "PeopleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "InterestPeople",
                keyColumns: new[] { "InterestsId", "PeopleId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "InterestPeople",
                keyColumns: new[] { "InterestsId", "PeopleId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "InterestPeople",
                keyColumns: new[] { "InterestsId", "PeopleId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "InterestPeople",
                keyColumns: new[] { "InterestsId", "PeopleId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "InterestPeople",
                keyColumns: new[] { "InterestsId", "PeopleId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "LinkPeople",
                keyColumns: new[] { "LinksId", "PeopleId" },
                keyValues: new object[] { 7, 4 });
        }
    }
}
