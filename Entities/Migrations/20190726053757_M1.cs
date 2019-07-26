using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerFirstName = table.Column<string>(nullable: true),
                    CustomerLastName = table.Column<string>(nullable: true),
                    CustomerAddress = table.Column<string>(nullable: true),
                    CustomerPhoneNumber = table.Column<string>(nullable: true),
                    CustomerEmail = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderDateTime = table.Column<DateTime>(nullable: false),
                    OrderPrice = table.Column<decimal>(nullable: false),
                    CustomerID = table.Column<string>(nullable: true),
                    CustomerID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID1",
                        column: x => x.CustomerID1,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drink",
                columns: table => new
                {
                    DrinkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrinkType = table.Column<string>(nullable: true),
                    OrderID = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drink", x => x.DrinkID);
                    table.ForeignKey(
                        name: "FK_Drink_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PizzaDetails",
                columns: table => new
                {
                    PizzaDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PizzaDetailPrice = table.Column<decimal>(nullable: false),
                    OrderID = table.Column<int>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    PizzaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PizzaType = table.Column<string>(nullable: true),
                    PizzaSize = table.Column<string>(nullable: true),
                    PizzaSauce = table.Column<string>(nullable: true),
                    PizzaBread = table.Column<string>(nullable: true),
                    PizzaCheese = table.Column<bool>(nullable: false),
                    PizzaDetailID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.PizzaID);
                    table.ForeignKey(
                        name: "FK_Pizzas_PizzaDetails_PizzaDetailID",
                        column: x => x.PizzaDetailID,
                        principalTable: "PizzaDetails",
                        principalColumn: "PizzaDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ToppingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ToppingName = table.Column<string>(nullable: true),
                    ToppingPrice = table.Column<decimal>(nullable: false),
                    ToppingType = table.Column<string>(nullable: true),
                    PizzaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.ToppingID);
                    table.ForeignKey(
                        name: "FK_Toppings_Pizzas_PizzaID",
                        column: x => x.PizzaID,
                        principalTable: "Pizzas",
                        principalColumn: "PizzaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drink_OrderID",
                table: "Drink",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID1",
                table: "Orders",
                column: "CustomerID1");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaDetails_OrderID",
                table: "PizzaDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_PizzaDetailID",
                table: "Pizzas",
                column: "PizzaDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_PizzaID",
                table: "Toppings",
                column: "PizzaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drink");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "PizzaDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
