using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DAL.Migrations
{
    public partial class UpdateDatabaseV42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Info_Series_SeriesId",
                table: "Info");

            migrationBuilder.DropIndex(
                name: "IX_Info_SeriesId",
                table: "Info");

            migrationBuilder.DropColumn(
                name: "OrderAt",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Edition");

            migrationBuilder.AlterColumn<string>(
                name: "TagName",
                table: "Tag",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Tag",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                type: "nvarchar(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<int>(
                name: "PlannedVolume",
                table: "Series",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "Rating",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PulishingHouse",
                table: "Publisher",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPrice",
                table: "OrderDetail",
                type: "decimal(18,2)",
                nullable: true,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "Menu",
                type: "nvarchar(70)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldDefaultValue: "Unknow");

            migrationBuilder.AlterColumn<int>(
                name: "SeriesId",
                table: "Info",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiscountPercent",
                table: "Info",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicationDate",
                table: "Edition",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Edition",
                type: "decimal(18,2)",
                nullable: true,
                defaultValue: 1000m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 1m);

            migrationBuilder.AlterColumn<int>(
                name: "Pages",
                table: "Edition",
                type: "int",
                nullable: true,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Edition",
                type: "char(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Author",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Info_SeriesId",
                table: "Info",
                column: "SeriesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Info_Series_SeriesId",
                table: "Info",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "SeriesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Info_Series_SeriesId",
                table: "Info");

            migrationBuilder.DropIndex(
                name: "IX_Info_SeriesId",
                table: "Info");

            migrationBuilder.AlterColumn<string>(
                name: "TagName",
                table: "Tag",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "Tag",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                oldType: "nvarchar(40)");

            migrationBuilder.AlterColumn<int>(
                name: "PlannedVolume",
                table: "Series",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "Rating",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PulishingHouse",
                table: "Publisher",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPrice",
                table: "OrderDetail",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true,
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "Order",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderAt",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "MenuName",
                table: "Menu",
                type: "nvarchar(70)",
                nullable: false,
                defaultValue: "Unknow",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)");

            migrationBuilder.AlterColumn<int>(
                name: "SeriesId",
                table: "Info",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DiscountPercent",
                table: "Info",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicationDate",
                table: "Edition",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Edition",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 1m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true,
                oldDefaultValue: 1000m);

            migrationBuilder.AlterColumn<int>(
                name: "Pages",
                table: "Edition",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Edition",
                type: "char(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(15)");

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Edition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Info_SeriesId",
                table: "Info",
                column: "SeriesId",
                unique: true,
                filter: "[SeriesId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Info_Series_SeriesId",
                table: "Info",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "SeriesId");
        }
    }
}
