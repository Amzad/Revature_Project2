using Microsoft.EntityFrameworkCore.Migrations;

namespace Revature_Project2.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Order_OrderID",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_ApplicationUserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerID1",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_PizzaDetail_OrderDetailID",
                table: "Pizza");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaDetail_Order_OrderID",
                table: "PizzaDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Topping_Pizza_PizzaID",
                table: "Topping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topping",
                table: "Topping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaDetail",
                table: "PizzaDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizza",
                table: "Pizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Topping",
                newName: "Toppings");

            migrationBuilder.RenameTable(
                name: "PizzaDetail",
                newName: "PizzaDetails");

            migrationBuilder.RenameTable(
                name: "Pizza",
                newName: "Pizzas");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Topping_PizzaID",
                table: "Toppings",
                newName: "IX_Toppings_PizzaID");

            migrationBuilder.RenameIndex(
                name: "IX_PizzaDetail_OrderID",
                table: "PizzaDetails",
                newName: "IX_PizzaDetails_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_Pizza_OrderDetailID",
                table: "Pizzas",
                newName: "IX_Pizzas_OrderDetailID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerID1",
                table: "Orders",
                newName: "IX_Orders_CustomerID1");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ApplicationUserId",
                table: "Orders",
                newName: "IX_Orders_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "ToppingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaDetails",
                table: "PizzaDetails",
                column: "OrderDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas",
                column: "PizzaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Orders_OrderID",
                table: "Drink",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID1",
                table: "Orders",
                column: "CustomerID1",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaDetails_Orders_OrderID",
                table: "PizzaDetails",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_PizzaDetails_OrderDetailID",
                table: "Pizzas",
                column: "OrderDetailID",
                principalTable: "PizzaDetails",
                principalColumn: "OrderDetailID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Pizzas_PizzaID",
                table: "Toppings",
                column: "PizzaID",
                principalTable: "Pizzas",
                principalColumn: "PizzaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Orders_OrderID",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID1",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaDetails_Orders_OrderID",
                table: "PizzaDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_PizzaDetails_OrderDetailID",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_PizzaID",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaDetails",
                table: "PizzaDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "Topping");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "Pizza");

            migrationBuilder.RenameTable(
                name: "PizzaDetails",
                newName: "PizzaDetail");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_Toppings_PizzaID",
                table: "Topping",
                newName: "IX_Topping_PizzaID");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_OrderDetailID",
                table: "Pizza",
                newName: "IX_Pizza_OrderDetailID");

            migrationBuilder.RenameIndex(
                name: "IX_PizzaDetails_OrderID",
                table: "PizzaDetail",
                newName: "IX_PizzaDetail_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerID1",
                table: "Order",
                newName: "IX_Order_CustomerID1");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Order",
                newName: "IX_Order_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topping",
                table: "Topping",
                column: "ToppingID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizza",
                table: "Pizza",
                column: "PizzaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaDetail",
                table: "PizzaDetail",
                column: "OrderDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Order_OrderID",
                table: "Drink",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_ApplicationUserId",
                table: "Order",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerID1",
                table: "Order",
                column: "CustomerID1",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_PizzaDetail_OrderDetailID",
                table: "Pizza",
                column: "OrderDetailID",
                principalTable: "PizzaDetail",
                principalColumn: "OrderDetailID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaDetail_Order_OrderID",
                table: "PizzaDetail",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topping_Pizza_PizzaID",
                table: "Topping",
                column: "PizzaID",
                principalTable: "Pizza",
                principalColumn: "PizzaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
