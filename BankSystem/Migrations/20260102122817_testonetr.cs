using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Migrations
{
    /// <inheritdoc />
    public partial class testonetr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactionsn",
                table: "Transactionsn");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customern",
                table: "Customern");

            migrationBuilder.RenameTable(
                name: "Transactionsn",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "Customern",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_Transactionsn_CreatedAt",
                table: "Transactions",
                newName: "IX_Transactions_CreatedAt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transactionsn");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customern");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CreatedAt",
                table: "Transactionsn",
                newName: "IX_Transactionsn_CreatedAt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactionsn",
                table: "Transactionsn",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customern",
                table: "Customern",
                column: "Id");
        }
    }
}
