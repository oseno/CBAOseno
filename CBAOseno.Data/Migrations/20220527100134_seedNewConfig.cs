using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBAOseno.Data.Migrations
{
    public partial class seedNewConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "Configuration",
                newName: "accountTType");

            migrationBuilder.AlterColumn<string>(
                name: "accountTType",
                table: "Configuration",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AccountType",
                table: "Configuration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 1,
                columns: new[] { "AccountType", "FinancialDate", "accountTType" },
                values: new object[] { 1, new DateTime(2022, 5, 27, 11, 1, 33, 266, DateTimeKind.Local).AddTicks(502), "Current" });

            migrationBuilder.UpdateData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 2,
                columns: new[] { "AccountType", "FinancialDate", "accountTType" },
                values: new object[] { 2, new DateTime(2022, 5, 27, 11, 1, 33, 306, DateTimeKind.Local).AddTicks(6840), "Savings" });

            migrationBuilder.UpdateData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 3,
                columns: new[] { "AccountType", "FinancialDate", "accountTType" },
                values: new object[] { 3, new DateTime(2022, 5, 27, 11, 1, 33, 306, DateTimeKind.Local).AddTicks(8856), "Loan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Configuration");

            migrationBuilder.RenameColumn(
                name: "accountTType",
                table: "Configuration",
                newName: "AccountType");

            migrationBuilder.AlterColumn<int>(
                name: "AccountType",
                table: "Configuration",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 1,
                columns: new[] { "AccountType", "FinancialDate" },
                values: new object[] { 1, new DateTime(2022, 5, 27, 8, 41, 56, 670, DateTimeKind.Local).AddTicks(9051) });

            migrationBuilder.UpdateData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 2,
                columns: new[] { "AccountType", "FinancialDate" },
                values: new object[] { 2, new DateTime(2022, 5, 27, 8, 41, 56, 678, DateTimeKind.Local).AddTicks(7525) });

            migrationBuilder.UpdateData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 3,
                columns: new[] { "AccountType", "FinancialDate" },
                values: new object[] { 3, new DateTime(2022, 5, 27, 8, 41, 56, 679, DateTimeKind.Local).AddTicks(178) });
        }
    }
}
