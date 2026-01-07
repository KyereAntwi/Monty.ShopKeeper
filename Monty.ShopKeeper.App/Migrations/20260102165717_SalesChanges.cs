using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Monty.ShopKeeper.App.Migrations
{
    /// <inheritdoc />
    public partial class SalesChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BalancePaid",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalancePaid",
                table: "Sales");
        }
    }
}
