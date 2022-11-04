using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DAL.Migrations
{
    public partial class UpdateDatabaseV43BookImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileUpload",
                table: "BookImage",
                newName: "FilePath");

            migrationBuilder.AddColumn<string>(
                name: "Decription",
                table: "BookImage",
                type: "ntext",
                nullable: true,
                defaultValue: "Unknow");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Decription",
                table: "BookImage");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "BookImage",
                newName: "FileUpload");
        }
    }
}
