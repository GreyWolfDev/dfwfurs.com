using Microsoft.EntityFrameworkCore.Migrations;

namespace DFW.Furs.Database.Migrations
{
    public partial class AddEventDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EventDescriptions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "EventDescriptions");
        }
    }
}
