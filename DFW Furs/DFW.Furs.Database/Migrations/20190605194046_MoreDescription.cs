using Microsoft.EntityFrameworkCore.Migrations;

namespace DFW.Furs.Database.Migrations
{
    public partial class MoreDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "EventDescriptions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "EventDescriptions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "EventDescriptions");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "EventDescriptions");
        }
    }
}
