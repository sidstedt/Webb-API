using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Test.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterestLink",
                columns: table => new
                {
                    InterestsId = table.Column<int>(type: "int", nullable: false),
                    LinksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestLink", x => new { x.InterestsId, x.LinksId });
                    table.ForeignKey(
                        name: "FK_InterestLink_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestLink_Links_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestPeople",
                columns: table => new
                {
                    InterestsId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestPeople", x => new { x.InterestsId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_InterestPeople_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestPeople_Peoples_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "Peoples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkPeople",
                columns: table => new
                {
                    LinksId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkPeople", x => new { x.LinksId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_LinkPeople_Links_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkPeople_Peoples_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "Peoples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Allt om kodning", "Programmering" },
                    { 2, "Allt om spel", "Gaming" },
                    { 3, "Allt om matlagning", "Matlagning" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "LinkName" },
                values: new object[,]
                {
                    { 1, "https://github.com" },
                    { 2, "https://stackoverflow.com" },
                    { 3, "https://www.gamereactor.com" },
                    { 4, "https://www.fz.se" },
                    { 5, "https://www.recept.se" },
                    { 6, "https://www.koket.se" },
                    { 7, "https://www.matklubben.se" }
                });

            migrationBuilder.InsertData(
                table: "Peoples",
                columns: new[] { "Id", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "0731234567" },
                    { 2, "Jane", "Smith", "0732345678" },
                    { 3, "Alice", "Johnson", "0733456789" },
                    { 4, "Bob", "Brown", "0734567890" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestLink_LinksId",
                table: "InterestLink",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestPeople_PeopleId",
                table: "InterestPeople",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkPeople_PeopleId",
                table: "LinkPeople",
                column: "PeopleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestLink");

            migrationBuilder.DropTable(
                name: "InterestPeople");

            migrationBuilder.DropTable(
                name: "LinkPeople");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Peoples");
        }
    }
}
