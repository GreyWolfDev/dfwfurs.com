using Microsoft.EntityFrameworkCore.Migrations;

namespace DFW.Furs.Database.Migrations
{
    public partial class EventActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "EventDescriptions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "EventDescriptions");
        }
    }
}
