using Microsoft.EntityFrameworkCore.Migrations;

namespace Shamane.DataAccess.MSSQL.Migrations
{
    public partial class AddProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Centers_Id",
                table: "Centers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Centers_Id",
                table: "Centers",
                column: "Id",
                unique: true);
        }
    }
}
