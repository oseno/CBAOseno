using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBAOseno.Data.Migrations
{
    public partial class accountConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    ConfigId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    MinBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinancialDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.ConfigId);
                });

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.DropTable(
                name: "Configuration");

         
          
        }
    }
}
