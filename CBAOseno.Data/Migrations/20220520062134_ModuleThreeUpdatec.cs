using Microsoft.EntityFrameworkCore.Migrations;

namespace CBAOseno.Data.Migrations
{
    public partial class ModuleThreeUpdatec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewCustomerId",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewCustomerId",
                table: "Customer");
        }
    }
}
