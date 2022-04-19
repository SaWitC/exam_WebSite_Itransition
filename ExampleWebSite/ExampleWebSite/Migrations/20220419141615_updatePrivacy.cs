using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleWebSite.Migrations
{
    public partial class updatePrivacy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvtorName",
                table: "Collections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvtorName",
                table: "Collections");
        }
    }
}
