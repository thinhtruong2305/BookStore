using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DAL.Migrations
{
    public partial class UpdateDatabaseV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Info_InfoId",
                table: "Tag");

            migrationBuilder.AlterColumn<int>(
                name: "InfoId",
                table: "Tag",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SeriesName",
                table: "Series",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Info_InfoId",
                table: "Tag",
                column: "InfoId",
                principalTable: "Info",
                principalColumn: "InfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Info_InfoId",
                table: "Tag");

            migrationBuilder.AlterColumn<int>(
                name: "InfoId",
                table: "Tag",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SeriesName",
                table: "Series",
                type: "nvarchar(30)",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldDefaultValue: "Unknow");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Info_InfoId",
                table: "Tag",
                column: "InfoId",
                principalTable: "Info",
                principalColumn: "InfoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
