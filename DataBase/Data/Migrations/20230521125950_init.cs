using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceReservation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(newid())"),
                    PayAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    PriceService = table.Column<decimal>(type: "decimal(19,2)", nullable: true, defaultValueSql: "((0))"),
                    PriceReservedRoom = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    SelfPay = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "1"),
                    ReservationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__InvoiceR__3214EC07A70F1055", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceReservation_AspNetUsers_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceReservation_Reservation_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReservation_CreatorId",
                table: "InvoiceReservation",
                column: "CreatorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReservation_ReservationId",
                table: "InvoiceReservation",
                column: "ReservationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceReservation");
        }
    }
}
