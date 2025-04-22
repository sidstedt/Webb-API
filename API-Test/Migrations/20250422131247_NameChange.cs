using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Test.Migrations
{
    /// <inheritdoc />
    public partial class NameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestPeople_Peoples_PeopleId",
                table: "InterestPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkPeople_Peoples_PeopleId",
                table: "LinkPeople");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Peoples",
                table: "Peoples");

            migrationBuilder.RenameTable(
                name: "Peoples",
                newName: "People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestPeople_People_PeopleId",
                table: "InterestPeople",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkPeople_People_PeopleId",
                table: "LinkPeople",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestPeople_People_PeopleId",
                table: "InterestPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkPeople_People_PeopleId",
                table: "LinkPeople");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Peoples");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Peoples",
                table: "Peoples",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestPeople_Peoples_PeopleId",
                table: "InterestPeople",
                column: "PeopleId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkPeople_Peoples_PeopleId",
                table: "LinkPeople",
                column: "PeopleId",
                principalTable: "Peoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
