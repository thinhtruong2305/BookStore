using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DAL.Migrations
{
    public partial class UpdateDatabaseV41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Author_AuthorId",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Book_BookId",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BookImages_Book_BookId",
                table: "BookImages");

            migrationBuilder.DropForeignKey(
                name: "FK_EditionPublishers_Edition_EditionId",
                table: "EditionPublishers");

            migrationBuilder.DropForeignKey(
                name: "FK_EditionPublishers_Publisher_PublisherId",
                table: "EditionPublishers");

            migrationBuilder.DropForeignKey(
                name: "FK_Info_Series_SeriesId",
                table: "Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Menus_MenuId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Info_SeriesId",
                table: "Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EditionPublishers",
                table: "EditionPublishers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookImages",
                table: "BookImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBooks",
                table: "AuthorBooks");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.RenameTable(
                name: "EditionPublishers",
                newName: "EditionPublisher");

            migrationBuilder.RenameTable(
                name: "BookImages",
                newName: "BookImage");

            migrationBuilder.RenameTable(
                name: "AuthorBooks",
                newName: "AuthorBook");

            migrationBuilder.RenameIndex(
                name: "IX_EditionPublishers_EditionId",
                table: "EditionPublisher",
                newName: "IX_EditionPublisher_EditionId");

            migrationBuilder.RenameIndex(
                name: "IX_BookImages_BookId",
                table: "BookImage",
                newName: "IX_BookImage_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBooks_BookId",
                table: "AuthorBook",
                newName: "IX_AuthorBook_BookId");

            migrationBuilder.AlterColumn<string>(
                name: "Keyword",
                table: "Tag",
                type: "nvarchar(60)",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Decription",
                table: "Tag",
                type: "ntext",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Keyword",
                table: "Publisher",
                type: "nvarchar(60)",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Decription",
                table: "Publisher",
                type: "ntext",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Publisher",
                type: "nvarchar(20)",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<string>(
                name: "ShipName",
                table: "Order",
                type: "nvarchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<int>(
                name: "SeriesId",
                table: "Info",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Info",
                type: "nvarchar(20)",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountPercent",
                table: "Info",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicationDate",
                table: "Edition",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PrintRunSize",
                table: "Edition",
                type: "nvarchar(30)",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Edition",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 1m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");

            migrationBuilder.AlterColumn<int>(
                name: "Pages",
                table: "Edition",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Edition",
                type: "char(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldMaxLength: 10,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<string>(
                name: "Format",
                table: "Edition",
                type: "nvarchar(20)",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Book",
                type: "nvarchar(70)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<string>(
                name: "Keyword",
                table: "Book",
                type: "nvarchar(60)",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Decription",
                table: "Book",
                type: "ntext",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Keyword",
                table: "Author",
                type: "nvarchar(60)",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)");

            migrationBuilder.AlterColumn<string>(
                name: "Decription",
                table: "Author",
                type: "ntext",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "ntext");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CountryOfResidence",
                table: "Author",
                type: "nvarchar(20)",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Keyword",
                table: "Menu",
                type: "nvarchar(60)",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)");

            migrationBuilder.AlterColumn<string>(
                name: "Decription",
                table: "Menu",
                type: "ntext",
                nullable: true,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "ntext");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EditionPublisher",
                table: "EditionPublisher",
                columns: new[] { "PublisherId", "EditionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookImage",
                table: "BookImage",
                column: "BookImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.CreateIndex(
                name: "IX_Info_SeriesId",
                table: "Info",
                column: "SeriesId",
                unique: true,
                filter: "[SeriesId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Author_AuthorId",
                table: "AuthorBook",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Book_BookId",
                table: "AuthorBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookImage_Book_BookId",
                table: "BookImage",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EditionPublisher_Edition_EditionId",
                table: "EditionPublisher",
                column: "EditionId",
                principalTable: "Edition",
                principalColumn: "EditionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EditionPublisher_Publisher_PublisherId",
                table: "EditionPublisher",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Info_Series_SeriesId",
                table: "Info",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Menu_MenuId",
                table: "Tag",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Author_AuthorId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Book_BookId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_BookImage_Book_BookId",
                table: "BookImage");

            migrationBuilder.DropForeignKey(
                name: "FK_EditionPublisher_Edition_EditionId",
                table: "EditionPublisher");

            migrationBuilder.DropForeignKey(
                name: "FK_EditionPublisher_Publisher_PublisherId",
                table: "EditionPublisher");

            migrationBuilder.DropForeignKey(
                name: "FK_Info_Series_SeriesId",
                table: "Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Menu_MenuId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Info_SeriesId",
                table: "Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EditionPublisher",
                table: "EditionPublisher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookImage",
                table: "BookImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.RenameTable(
                name: "EditionPublisher",
                newName: "EditionPublishers");

            migrationBuilder.RenameTable(
                name: "BookImage",
                newName: "BookImages");

            migrationBuilder.RenameTable(
                name: "AuthorBook",
                newName: "AuthorBooks");

            migrationBuilder.RenameIndex(
                name: "IX_EditionPublisher_EditionId",
                table: "EditionPublishers",
                newName: "IX_EditionPublishers_EditionId");

            migrationBuilder.RenameIndex(
                name: "IX_BookImage_BookId",
                table: "BookImages",
                newName: "IX_BookImages_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_BookId",
                table: "AuthorBooks",
                newName: "IX_AuthorBooks_BookId");

            migrationBuilder.AlterColumn<string>(
                name: "Keyword",
                table: "Tag",
                type: "nvarchar(60)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<string>(
                name: "Decription",
                table: "Tag",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<string>(
                name: "Keyword",
                table: "Publisher",
                type: "nvarchar(60)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<string>(
                name: "Decription",
                table: "Publisher",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Publisher",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<string>(
                name: "ShipName",
                table: "Order",
                type: "nvarchar(60)",
                nullable: false,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)");

            migrationBuilder.AlterColumn<int>(
                name: "SeriesId",
                table: "Info",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Info",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountPercent",
                table: "Info",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicationDate",
                table: "Edition",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "PrintRunSize",
                table: "Edition",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Edition",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 1m);

            migrationBuilder.AlterColumn<int>(
                name: "Pages",
                table: "Edition",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Edition",
                type: "char(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Format",
                table: "Edition",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Book",
                type: "nvarchar(70)",
                nullable: false,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)");

            migrationBuilder.AlterColumn<string>(
                name: "Keyword",
                table: "Book",
                type: "nvarchar(60)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<string>(
                name: "Decription",
                table: "Book",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<string>(
                name: "Keyword",
                table: "Author",
                type: "nvarchar(60)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<string>(
                name: "Decription",
                table: "Author",
                type: "ntext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Author",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "CountryOfResidence",
                table: "Author",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<string>(
                name: "Keyword",
                table: "Menus",
                type: "nvarchar(60)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<string>(
                name: "Decription",
                table: "Menus",
                type: "ntext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true,
                oldDefaultValue: "Unknow");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EditionPublishers",
                table: "EditionPublishers",
                columns: new[] { "PublisherId", "EditionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookImages",
                table: "BookImages",
                column: "BookImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBooks",
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.CreateIndex(
                name: "IX_Info_SeriesId",
                table: "Info",
                column: "SeriesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Author_AuthorId",
                table: "AuthorBooks",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Book_BookId",
                table: "AuthorBooks",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookImages_Book_BookId",
                table: "BookImages",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EditionPublishers_Edition_EditionId",
                table: "EditionPublishers",
                column: "EditionId",
                principalTable: "Edition",
                principalColumn: "EditionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EditionPublishers_Publisher_PublisherId",
                table: "EditionPublishers",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Info_Series_SeriesId",
                table: "Info",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "SeriesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Menus_MenuId",
                table: "Tag",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "MenuId");
        }
    }
}
