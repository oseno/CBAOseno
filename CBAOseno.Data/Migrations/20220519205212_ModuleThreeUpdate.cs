using Microsoft.EntityFrameworkCore.Migrations;

namespace CBAOseno.Data.Migrations
{
    public partial class ModuleThreeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Categories",
                table: "GLCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "CategoryCode",
                table: "GLCategory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "CategoryDescription",
                table: "GLCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GLAccountBalance",
                table: "GLAccount",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categories",
                table: "GLCategory");

            migrationBuilder.DropColumn(
                name: "CategoryCode",
                table: "GLCategory");

            migrationBuilder.DropColumn(
                name: "CategoryDescription",
                table: "GLCategory");

            migrationBuilder.DropColumn(
                name: "GLAccountBalance",
                table: "GLAccount");
        }
    }
}
