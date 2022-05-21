using Microsoft.EntityFrameworkCore.Migrations;

namespace CBAOseno.Data.Migrations
{
    public partial class newUpdatesForThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "CustomerAccount",
                newName: "AccountType");

            migrationBuilder.AddColumn<decimal>(
                name: "AccountBalance",
                table: "CustomerAccount",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "CustomerAccount",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "CustomerAccount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountStatus",
                table: "CustomerAccount",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountBalance",
                table: "CustomerAccount");

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "CustomerAccount");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "CustomerAccount");

            migrationBuilder.DropColumn(
                name: "AccountStatus",
                table: "CustomerAccount");

            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "CustomerAccount",
                newName: "Status");
        }
    }
}
