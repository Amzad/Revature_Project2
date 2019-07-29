using Microsoft.EntityFrameworkCore.Migrations;

namespace Revature_Project2API.Migrations
{
    public partial class M5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreditCardNumber",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpMonth",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpYear",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditCardNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ExpMonth",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ExpYear",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "Customers");
        }
    }
}
