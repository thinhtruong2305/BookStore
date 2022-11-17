using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DAL.Migrations
{
    public partial class UpdateDatabaseV32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "EditionPublishers");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "EditionPublishers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EditionPublishers");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "EditionPublishers");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "EditionPublishers");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "AuthorBooks");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "AuthorBooks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AuthorBooks");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "AuthorBooks");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "AuthorBooks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "EditionPublishers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "EditionPublishers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "EditionPublishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "EditionPublishers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "EditionPublishers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "AuthorBooks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "AuthorBooks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AuthorBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "AuthorBooks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "AuthorBooks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
