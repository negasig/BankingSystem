using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Migrations
{
    /// <inheritdoc />
    public partial class changeAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ToCustomerId",
                table: "Transactions",
                newName: "SenderAccount");

            migrationBuilder.RenameColumn(
                name: "FromCustomerId",
                table: "Transactions",
                newName: "ReceiverAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderAccount",
                table: "Transactions",
                newName: "ToCustomerId");

            migrationBuilder.RenameColumn(
                name: "ReceiverAccount",
                table: "Transactions",
                newName: "FromCustomerId");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
