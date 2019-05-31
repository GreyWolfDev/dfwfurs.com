using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DFW.Furs.Database.Migrations
{
    public partial class UserAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "CrewMembers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo64",
                table: "CrewMembers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Roles",
                table: "CrewMembers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Authentications",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    photo_url = table.Column<string>(nullable: true),
                    auth_date = table.Column<string>(nullable: true),
                    hash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentications", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authentications");

            migrationBuilder.DropColumn(
                name: "About",
                table: "CrewMembers");

            migrationBuilder.DropColumn(
                name: "Photo64",
                table: "CrewMembers");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "CrewMembers");
        }
    }
}
