using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleWebSite.Migrations
{
    public partial class Updatetag2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagModelId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_TagModelId",
                table: "Items",
                column: "TagModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Tags_TagModelId",
                table: "Items",
                column: "TagModelId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Tags_TagModelId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_TagModelId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TagModelId",
                table: "Items");
        }
    }
}
