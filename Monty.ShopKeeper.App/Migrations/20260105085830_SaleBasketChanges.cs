using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Monty.ShopKeeper.App.Migrations
{
    /// <inheritdoc />
    public partial class SaleBasketChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "BalancePaid",
                table: "Sales",
                newName: "CurrentPricePaid");

            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "Sales",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalAmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalancePaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BasketId",
                table: "Sales",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Baskets_BasketId",
                table: "Sales",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Baskets_BasketId",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Sales_BasketId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "CurrentPricePaid",
                table: "Sales",
                newName: "BalancePaid");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaid",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
