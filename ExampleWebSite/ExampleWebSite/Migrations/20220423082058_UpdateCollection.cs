using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleWebSite.Migrations
{
    public partial class UpdateCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Collections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Collections");
        }
    }
}
