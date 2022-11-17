using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DAL.Migrations
{
    public partial class UpdateDatabaseV31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Tác giả_AuthorId",
                table: "AuthorBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tác giả",
                table: "Tác giả");

            migrationBuilder.RenameTable(
                name: "Tác giả",
                newName: "Author");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Author_AuthorId",
                table: "AuthorBooks",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Author_AuthorId",
                table: "AuthorBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Tác giả");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tác giả",
                table: "Tác giả",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Tác giả_AuthorId",
                table: "AuthorBooks",
                column: "AuthorId",
                principalTable: "Tác giả",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
