using Microsoft.EntityFrameworkCore.Migrations;

namespace DFW.Furs.Database.Migrations
{
    public partial class FixTelegramId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "telegram_id",
                table: "Authentications",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "telegram_id",
                table: "Authentications");
        }
    }
}
