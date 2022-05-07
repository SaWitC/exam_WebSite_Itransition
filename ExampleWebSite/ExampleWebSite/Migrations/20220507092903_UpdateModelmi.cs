using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleWebSite.Migrations
{
    public partial class UpdateModelmi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Tags_TagModelId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_ItemTagsrelationships_ItemTagsrelationshipspModelId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ItemTagsrelationshipspModelId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Items_TagModelId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemTagsrelationshipspModelId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Item_Tags_RelationshipId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TagModelId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemModelId",
                table: "Tags",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "ItemTagsrelationships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ItemModelId",
                table: "Tags",
                column: "ItemModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTagsrelationships_TagId",
                table: "ItemTagsrelationships",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTagsrelationships_Tags_TagId",
                table: "ItemTagsrelationships",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Items_ItemModelId",
                table: "Tags",
                column: "ItemModelId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTagsrelationships_Tags_TagId",
                table: "ItemTagsrelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Items_ItemModelId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ItemModelId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_ItemTagsrelationships_TagId",
                table: "ItemTagsrelationships");

            migrationBuilder.DropColumn(
                name: "ItemModelId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "ItemTagsrelationships");

            migrationBuilder.AddColumn<int>(
                name: "ItemTagsrelationshipspModelId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Item_Tags_RelationshipId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TagModelId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ItemTagsrelationshipspModelId",
                table: "Tags",
                column: "ItemTagsrelationshipspModelId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_ItemTagsrelationships_ItemTagsrelationshipspModelId",
                table: "Tags",
                column: "ItemTagsrelationshipspModelId",
                principalTable: "ItemTagsrelationships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
