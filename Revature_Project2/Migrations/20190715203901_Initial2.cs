using Microsoft.EntityFrameworkCore.Migrations;

namespace Revature_Project2.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Toppings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Toppings",
                nullable: false,
                defaultValue: 0);
        }
    }
}
