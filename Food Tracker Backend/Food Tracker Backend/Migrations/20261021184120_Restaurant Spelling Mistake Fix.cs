using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food_Tracker_Backend.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantSpellingMistakeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Resturaunts_RestaurantId",
                table: "MenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resturaunts",
                table: "Resturaunts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem");

            migrationBuilder.RenameTable(
                name: "Resturaunts",
                newName: "Restaurants");

            migrationBuilder.RenameTable(
                name: "MenuItem",
                newName: "MenuItems");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItem_RestaurantId",
                table: "MenuItems",
                newName: "IX_MenuItems_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Restaurants_RestaurantId",
                table: "MenuItems",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Restaurants_RestaurantId",
                table: "MenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "Resturaunts");

            migrationBuilder.RenameTable(
                name: "MenuItems",
                newName: "MenuItem");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_RestaurantId",
                table: "MenuItem",
                newName: "IX_MenuItem_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resturaunts",
                table: "Resturaunts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Resturaunts_RestaurantId",
                table: "MenuItem",
                column: "RestaurantId",
                principalTable: "Resturaunts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
