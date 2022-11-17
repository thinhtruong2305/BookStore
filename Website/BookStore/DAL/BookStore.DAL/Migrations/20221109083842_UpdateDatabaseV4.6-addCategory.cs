using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DAL.Migrations
{
    public partial class UpdateDatabaseV46addCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagInfos_Info_InfoId",
                table: "TagInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_TagInfos_Tag_TagId",
                table: "TagInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagInfos",
                table: "TagInfos");

            migrationBuilder.RenameTable(
                name: "TagInfos",
                newName: "TagInfo");

            migrationBuilder.RenameIndex(
                name: "IX_TagInfos_TagId",
                table: "TagInfo",
                newName: "IX_TagInfo_TagId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagInfo",
                table: "TagInfo",
                columns: new[] { "InfoId", "TagId" });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Slug = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    Orders = table.Column<int>(type: "int", nullable: true),
                    Keyword = table.Column<string>(type: "nvarchar(60)", nullable: true, defaultValue: "Unknow"),
                    Decription = table.Column<string>(type: "ntext", nullable: true, defaultValue: "Unknow"),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagInfo_Info_InfoId",
                table: "TagInfo",
                column: "InfoId",
                principalTable: "Info",
                principalColumn: "InfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagInfo_Tag_TagId",
                table: "TagInfo",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_TagInfo_Info_InfoId",
                table: "TagInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_TagInfo_Tag_TagId",
                table: "TagInfo");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Book_CategoryId",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagInfo",
                table: "TagInfo");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "TagInfo",
                newName: "TagInfos");

            migrationBuilder.RenameIndex(
                name: "IX_TagInfo_TagId",
                table: "TagInfos",
                newName: "IX_TagInfos_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagInfos",
                table: "TagInfos",
                columns: new[] { "InfoId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TagInfos_Info_InfoId",
                table: "TagInfos",
                column: "InfoId",
                principalTable: "Info",
                principalColumn: "InfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagInfos_Tag_TagId",
                table: "TagInfos",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
