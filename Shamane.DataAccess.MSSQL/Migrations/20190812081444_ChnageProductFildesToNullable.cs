using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shamane.DataAccess.MSSQL.Migrations
{
    public partial class ChnageProductFildesToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Centers_EspeciallyForCenterId",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "EspeciallyForCenterId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Centers_EspeciallyForCenterId",
                table: "Products",
                column: "EspeciallyForCenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Centers_EspeciallyForCenterId",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "EspeciallyForCenterId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Centers_EspeciallyForCenterId",
                table: "Products",
                column: "EspeciallyForCenterId",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
