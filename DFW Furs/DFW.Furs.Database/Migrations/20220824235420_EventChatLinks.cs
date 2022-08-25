using Microsoft.EntityFrameworkCore.Migrations;

namespace DFW.Furs.Database.Migrations
{
    public partial class EventChatLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChatLink",
                table: "EventDescriptions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RSVPRequired",
                table: "EventDescriptions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChatLink",
                table: "EventDescriptions");

            migrationBuilder.DropColumn(
                name: "RSVPRequired",
                table: "EventDescriptions");
        }
    }
}
