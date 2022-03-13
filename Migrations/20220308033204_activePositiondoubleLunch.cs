using Microsoft.EntityFrameworkCore.Migrations;

namespace Seating.Migrations
{
    public partial class activePositiondoubleLunch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Positions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DblLunch",
                table: "Lunches",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "DblLunch",
                table: "Lunches");
        }
    }
}
