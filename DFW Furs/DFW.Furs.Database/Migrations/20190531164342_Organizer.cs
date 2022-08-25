using Microsoft.EntityFrameworkCore.Migrations;

namespace DFW.Furs.Database.Migrations
{
    public partial class Organizer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrewMembers_EventDescriptions_EventDescriptionId",
                table: "CrewMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventDescriptions_DescriptionId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_DescriptionId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_CrewMembers_EventDescriptionId",
                table: "CrewMembers");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventDescriptionId",
                table: "CrewMembers");

            migrationBuilder.AddColumn<int>(
                name: "EventDescriptionId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventOrganizer",
                columns: table => new
                {
                    EventDescriptionId = table.Column<int>(nullable: false),
                    CrewMemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOrganizer", x => new { x.CrewMemberId, x.EventDescriptionId });
                    table.ForeignKey(
                        name: "FK_EventOrganizer_CrewMembers_CrewMemberId",
                        column: x => x.CrewMemberId,
                        principalTable: "CrewMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventOrganizer_EventDescriptions_EventDescriptionId",
                        column: x => x.EventDescriptionId,
                        principalTable: "EventDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventDescriptionId",
                table: "Events",
                column: "EventDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_EventOrganizer_EventDescriptionId",
                table: "EventOrganizer",
                column: "EventDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventDescriptions_EventDescriptionId",
                table: "Events",
                column: "EventDescriptionId",
                principalTable: "EventDescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventDescriptions_EventDescriptionId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "EventOrganizer");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventDescriptionId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventDescriptionId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventDescriptionId",
                table: "CrewMembers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_DescriptionId",
                table: "Events",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewMembers_EventDescriptionId",
                table: "CrewMembers",
                column: "EventDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrewMembers_EventDescriptions_EventDescriptionId",
                table: "CrewMembers",
                column: "EventDescriptionId",
                principalTable: "EventDescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventDescriptions_DescriptionId",
                table: "Events",
                column: "DescriptionId",
                principalTable: "EventDescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
