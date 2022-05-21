using Microsoft.EntityFrameworkCore.Migrations;

namespace CBAOseno.Data.Migrations
{
    public partial class newUpdatesForThreePtTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccount_Customer_CustomerId",
                table: "CustomerAccount");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "CustomerAccount",
                newName: "NewCustomerIdCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAccount_CustomerId",
                table: "CustomerAccount",
                newName: "IX_CustomerAccount_NewCustomerIdCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccount_Customer_NewCustomerIdCustomerId",
                table: "CustomerAccount",
                column: "NewCustomerIdCustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccount_Customer_NewCustomerIdCustomerId",
                table: "CustomerAccount");

            migrationBuilder.RenameColumn(
                name: "NewCustomerIdCustomerId",
                table: "CustomerAccount",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAccount_NewCustomerIdCustomerId",
                table: "CustomerAccount",
                newName: "IX_CustomerAccount_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccount_Customer_CustomerId",
                table: "CustomerAccount",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
