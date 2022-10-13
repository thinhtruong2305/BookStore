using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DAL.Migrations
{
    public partial class UpdateDatabaseV33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Info_SeriesId",
                table: "Info");

            migrationBuilder.DropIndex(
                name: "IX_BookImages_BookId",
                table: "BookImages");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Edition",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.CreateIndex(
                name: "IX_Info_SeriesId",
                table: "Info",
                column: "SeriesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookImages_BookId",
                table: "BookImages",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Info_SeriesId",
                table: "Info");

            migrationBuilder.DropIndex(
                name: "IX_BookImages_BookId",
                table: "BookImages");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Edition",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");

            migrationBuilder.CreateIndex(
                name: "IX_Info_SeriesId",
                table: "Info",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_BookImages_BookId",
                table: "BookImages",
                column: "BookId",
                unique: true);
        }
    }
}
