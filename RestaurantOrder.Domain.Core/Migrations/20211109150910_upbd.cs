using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantOrder.Domain.Core.Migrations
{
    public partial class upbd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NeededDish_Dishes_DishId",
                table: "NeededDish");

            migrationBuilder.DropForeignKey(
                name: "FK_NeededDish_Orders_OrderId",
                table: "NeededDish");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NeededDish",
                table: "NeededDish");

            migrationBuilder.RenameTable(
                name: "NeededDish",
                newName: "NeededDishes");

            migrationBuilder.RenameIndex(
                name: "IX_NeededDish_OrderId",
                table: "NeededDishes",
                newName: "IX_NeededDishes_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_NeededDish_DishId",
                table: "NeededDishes",
                newName: "IX_NeededDishes_DishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NeededDishes",
                table: "NeededDishes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NeededDishes_Dishes_DishId",
                table: "NeededDishes",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NeededDishes_Orders_OrderId",
                table: "NeededDishes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NeededDishes_Dishes_DishId",
                table: "NeededDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_NeededDishes_Orders_OrderId",
                table: "NeededDishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NeededDishes",
                table: "NeededDishes");

            migrationBuilder.RenameTable(
                name: "NeededDishes",
                newName: "NeededDish");

            migrationBuilder.RenameIndex(
                name: "IX_NeededDishes_OrderId",
                table: "NeededDish",
                newName: "IX_NeededDish_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_NeededDishes_DishId",
                table: "NeededDish",
                newName: "IX_NeededDish_DishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NeededDish",
                table: "NeededDish",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NeededDish_Dishes_DishId",
                table: "NeededDish",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NeededDish_Orders_OrderId",
                table: "NeededDish",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
