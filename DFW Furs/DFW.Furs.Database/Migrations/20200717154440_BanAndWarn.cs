using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DFW.Furs.Database.Migrations
{
    public partial class BanAndWarn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowNSFW",
                table: "Groups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableCaptcha",
                table: "Groups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableCommunityBans",
                table: "Groups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MemberCount",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NSFWAction",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "TelegramId",
                table: "Groups",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "WelcomeMessage",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TelegramUserId",
                table: "CrewMembers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TgUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TelegramId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TgUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrewMembers_TelegramUserId",
                table: "CrewMembers",
                column: "TelegramUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrewMembers_TgUser_TelegramUserId",
                table: "CrewMembers",
                column: "TelegramUserId",
                principalTable: "TgUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrewMembers_TgUser_TelegramUserId",
                table: "CrewMembers");

            migrationBuilder.DropTable(
                name: "TgUser");

            migrationBuilder.DropIndex(
                name: "IX_CrewMembers_TelegramUserId",
                table: "CrewMembers");

            migrationBuilder.DropColumn(
                name: "AllowNSFW",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "EnableCaptcha",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "EnableCommunityBans",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "MemberCount",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "NSFWAction",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "TelegramId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "WelcomeMessage",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "TelegramUserId",
                table: "CrewMembers");
        }
    }
}
