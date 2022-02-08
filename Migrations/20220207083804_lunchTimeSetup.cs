using Microsoft.EntityFrameworkCore.Migrations;

namespace Seating.Migrations
{
    public partial class lunchTimeSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LunchTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftStart = table.Column<int>(type: "int", nullable: false),
                    LunchHour = table.Column<int>(type: "int", nullable: false),
                    LunchMinute = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchTimes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LunchTimes");
        }
    }
}
