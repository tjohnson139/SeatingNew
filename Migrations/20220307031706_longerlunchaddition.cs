using Microsoft.EntityFrameworkCore.Migrations;

namespace Seating.Migrations
{
    public partial class longerlunchaddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongerLunch",
                table: "Lunches");

            migrationBuilder.CreateTable(
                name: "LunchTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LunchHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LunchMinute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftStart = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchTimes", x => x.Id);
                });
        }
    }
}
