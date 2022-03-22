using Microsoft.EntityFrameworkCore.Migrations;

namespace Seating.Migrations
{
    public partial class changepositiontoinactive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Inactive",
                table: "Positions",
                newName: "Inactive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Inactive",
                table: "Positions",
                newName: "Inactive");
        }
    }
}
