using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleWebSite.Migrations
{
    public partial class updatedTagModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Items_ItemModelId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ItemModelId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ItemModelId",
                table: "Tags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemModelId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ItemModelId",
                table: "Tags",
                column: "ItemModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Items_ItemModelId",
                table: "Tags",
                column: "ItemModelId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
