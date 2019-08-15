using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shamane.DataAccess.MSSQL.Migrations
{
    public partial class AddOrderAndOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdateBy = table.Column<Guid>(nullable: true),
                    AcceptedBy = table.Column<Guid>(nullable: false),
                    RejectedBy = table.Column<Guid>(nullable: false),
                    CompletedBy = table.Column<Guid>(nullable: false),
                    AcceptedDateTime = table.Column<DateTime>(nullable: true),
                    RejectedDateTime = table.Column<DateTime>(nullable: true),
                    CompletedDateTime = table.Column<DateTime>(nullable: true),
                    SendToDelivertDateTime = table.Column<DateTime>(nullable: true),
                    OrderStaus = table.Column<int>(nullable: false),
                    OrderDeliverType = table.Column<int>(nullable: false),
                    RejectReason = table.Column<string>(nullable: true),
                    TargetAddressIsUserProfileAddress = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CenterId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TotlaPrice = table.Column<long>(nullable: true),
                    Discount = table.Column<long>(nullable: true),
                    Tax = table.Column<long>(nullable: true),
                    DeliveryPrice = table.Column<long>(nullable: true),
                    OrderCode = table.Column<string>(nullable: true),
                    RegisterdAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdateBy = table.Column<Guid>(nullable: true),
                    CenterProductId = table.Column<Guid>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_CenterProducts_CenterProductId",
                        column: x => x.CenterProductId,
                        principalTable: "CenterProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Centers_CityId",
                table: "Centers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_CenterProductId",
                table: "OrderDetail",
                column: "CenterProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CenterId",
                table: "Orders",
                column: "CenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_Cities_CityId",
                table: "Centers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centers_Cities_CityId",
                table: "Centers");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Centers_CityId",
                table: "Centers");
        }
    }
}
