using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBAOseno.Data.Migrations
{
    public partial class generateAccNum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "NewCustomerId",
                table: "CustomerAccount",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NewCustomerId",
                table: "CustomerAccount",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

           
        }
    }
}
