using Microsoft.EntityFrameworkCore.Migrations;

namespace DFW.Furs.Database.Migrations
{
    public partial class FursuitFriendly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FursuitFriendly",
                table: "EventDescriptions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FursuitFriendly",
                table: "EventDescriptions");
        }
    }
}
