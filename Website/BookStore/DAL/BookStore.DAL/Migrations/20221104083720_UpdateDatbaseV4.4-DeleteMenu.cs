using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DAL.Migrations
{
    public partial class UpdateDatbaseV44DeleteMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Menu_MenuId",
                table: "Tag");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Tag_MenuId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Tag");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Tag",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId1",
                table: "Tag",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TagId1",
                table: "Tag",
                column: "TagId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Tag_TagId1",
                table: "Tag",
                column: "TagId1",
                principalTable: "Tag",
                principalColumn: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Tag_TagId1",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_TagId1",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "TagId1",
                table: "Tag");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "Tag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Decription = table.Column<string>(type: "ntext", nullable: true, defaultValue: "Unknow"),
                    Keyword = table.Column<string>(type: "nvarchar(60)", nullable: true, defaultValue: "Unknow"),
                    MenuName = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Slug = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_MenuId",
                table: "Tag",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Menu_MenuId",
                table: "Tag",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "MenuId");
        }
    }
}
