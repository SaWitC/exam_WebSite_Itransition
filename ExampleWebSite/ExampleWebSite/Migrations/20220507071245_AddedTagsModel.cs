using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleWebSite.Migrations
{
    public partial class AddedTagsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "Item_Tags_RelationshipId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ItemTagsrelationships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTagsrelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTagsrelationships_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ItemTagsrelationshipspModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_ItemTagsrelationships_ItemTagsrelationshipspModelId",
                        column: x => x.ItemTagsrelationshipspModelId,
                        principalTable: "ItemTagsrelationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTagsrelationships_ItemId",
                table: "ItemTagsrelationships",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ItemTagsrelationshipspModelId",
                table: "Tags",
                column: "ItemTagsrelationshipspModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "ItemTagsrelationships");

            migrationBuilder.DropColumn(
                name: "Item_Tags_RelationshipId",
                table: "Items");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
