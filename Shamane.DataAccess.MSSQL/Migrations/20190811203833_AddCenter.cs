using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shamane.DataAccess.MSSQL.Migrations
{
    public partial class AddCenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Centers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdateBy = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    CenterType = table.Column<int>(nullable: false),
                    Tellphone = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    CityId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    ContractStartDate = table.Column<DateTime>(nullable: false),
                    ContractEndDate = table.Column<DateTime>(nullable: false),
                    ContractNumber = table.Column<string>(nullable: true),
                    Tax = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    DeliveryType = table.Column<int>(nullable: false),
                    DeliveryComment = table.Column<string>(nullable: true),
                    Lat = table.Column<long>(nullable: false),
                    Lng = table.Column<long>(nullable: false),
                    AttachmentImage = table.Column<string>(nullable: true),
                    LogoImage = table.Column<string>(nullable: true),
                    BannerImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Centers_Id",
                table: "Centers",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Centers");
        }
    }
}
