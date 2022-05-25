using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBAOseno.Data.Migrations
{
    public partial class seedConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Configuration",
                columns: new[] { "ConfigId", "AccountType", "CoT", "FinancialDate", "InterestRate", "MinBalance" },
                values: new object[] { 1, 1, 0.00m, new DateTime(2022, 5, 25, 17, 52, 16, 353, DateTimeKind.Local).AddTicks(5899), 0.00m, 0.00m });

            migrationBuilder.InsertData(
                table: "Configuration",
                columns: new[] { "ConfigId", "AccountType", "CoT", "FinancialDate", "InterestRate", "MinBalance" },
                values: new object[] { 2, 2, 0.00m, new DateTime(2022, 5, 25, 17, 52, 16, 516, DateTimeKind.Local).AddTicks(1096), 0.00m, 0.00m });

            migrationBuilder.InsertData(
                table: "Configuration",
                columns: new[] { "ConfigId", "AccountType", "CoT", "FinancialDate", "InterestRate", "MinBalance" },
                values: new object[] { 3, 3, 0.00m, new DateTime(2022, 5, 25, 17, 52, 16, 516, DateTimeKind.Local).AddTicks(5957), 0.00m, 0.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Configuration",
                keyColumn: "ConfigId",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "Functions", "RoleName", "Status" },
                values: new object[] { 1, null, "Super Admin", 1 });
        }
    }
}
