using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Monty.ShopKeeper.App.Migrations
{
    /// <inheritdoc />
    public partial class AddedSaleTypeAndReturned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseType",
                table: "Baskets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.AddColumn<bool>(
                name: "Returned",
                table: "Baskets",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseType",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "Returned",
                table: "Baskets");
        }
    }
}
