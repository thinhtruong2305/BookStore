using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.DAL.Migrations
{
    public partial class UpdateDatabaseV45AddTagInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Info_InfoId",
                table: "Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Tag_TagId1",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_InfoId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_TagId1",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "InfoId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "TagId1",
                table: "Tag");

            migrationBuilder.CreateTable(
                name: "TagInfos",
                columns: table => new
                {
                    InfoId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagInfos", x => new { x.InfoId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TagInfos_Info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "Info",
                        principalColumn: "InfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagInfos_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagInfos_TagId",
                table: "TagInfos",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagInfos");

            migrationBuilder.AddColumn<int>(
                name: "InfoId",
                table: "Tag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TagId1",
                table: "Tag",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_InfoId",
                table: "Tag",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TagId1",
                table: "Tag",
                column: "TagId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Info_InfoId",
                table: "Tag",
                column: "InfoId",
                principalTable: "Info",
                principalColumn: "InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Tag_TagId1",
                table: "Tag",
                column: "TagId1",
                principalTable: "Tag",
                principalColumn: "TagId");
        }
    }
}
