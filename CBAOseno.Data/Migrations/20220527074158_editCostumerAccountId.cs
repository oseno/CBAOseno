using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBAOseno.Data.Migrations
{
    public partial class editCostumerAccountId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "NewCustomerId",
                table: "CustomerAccount",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 1,
                column: "FinancialDate",
                value: new DateTime(2022, 5, 27, 8, 41, 56, 670, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 2,
                column: "FinancialDate",
                value: new DateTime(2022, 5, 27, 8, 41, 56, 678, DateTimeKind.Local).AddTicks(7525));

            migrationBuilder.UpdateData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 3,
                column: "FinancialDate",
                value: new DateTime(2022, 5, 27, 8, 41, 56, 679, DateTimeKind.Local).AddTicks(178));

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccount_Customer_CustomerId",
                table: "CustomerAccount",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccount_Customer_CustomerId",
                table: "CustomerAccount");

            migrationBuilder.DropColumn(
                name: "NewCustomerId",
                table: "CustomerAccount");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "CustomerAccount",
                newName: "NewCustomerIdCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAccount_CustomerId",
                table: "CustomerAccount",
                newName: "IX_CustomerAccount_NewCustomerIdCustomerId");

            migrationBuilder.UpdateData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 1,
                column: "FinancialDate",
                value: new DateTime(2022, 5, 25, 17, 52, 16, 353, DateTimeKind.Local).AddTicks(5899));

            migrationBuilder.UpdateData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 2,
                column: "FinancialDate",
                value: new DateTime(2022, 5, 25, 17, 52, 16, 516, DateTimeKind.Local).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 3,
                column: "FinancialDate",
                value: new DateTime(2022, 5, 25, 17, 52, 16, 516, DateTimeKind.Local).AddTicks(5957));

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccount_Customer_NewCustomerIdCustomerId",
                table: "CustomerAccount",
                column: "NewCustomerIdCustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
