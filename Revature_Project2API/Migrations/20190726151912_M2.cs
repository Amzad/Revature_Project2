using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_PizzaDetails_PizzaDetailID",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "PizzaDetails");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_PizzaDetailID",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerID1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerID1",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Pizzas",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PizzaPrice",
                table: "Pizzas",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderID",
                table: "Pizzas",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Orders_OrderID",
                table: "Pizzas",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_OrderID",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_OrderID",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "PizzaPrice",
                table: "Pizzas");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerID",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID1",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PizzaDetails",
                columns: table => new
                {
                    PizzaDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<int>(nullable: true),
                    PizzaDetailPrice = table.Column<decimal>(nullable: false),
                    PizzaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaDetails", x => x.PizzaDetailID);
                    table.ForeignKey(
                        name: "FK_PizzaDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_PizzaDetailID",
                table: "Pizzas",
                column: "PizzaDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID1",
                table: "Orders",
                column: "CustomerID1");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaDetails_OrderID",
                table: "PizzaDetails",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID1",
                table: "Orders",
                column: "CustomerID1",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_PizzaDetails_PizzaDetailID",
                table: "Pizzas",
                column: "PizzaDetailID",
                principalTable: "PizzaDetails",
                principalColumn: "PizzaDetailID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
