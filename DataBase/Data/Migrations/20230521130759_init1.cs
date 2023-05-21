using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceReservation_AspNetUsers_ReservationId",
                table: "InvoiceReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceReservation_Reservation_CreatorId",
                table: "InvoiceReservation");

            migrationBuilder.AlterColumn<string>(
                name: "ReservationId",
                table: "InvoiceReservation",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "InvoiceReservation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceReservation_AspNetUsers_CreatorId",
                table: "InvoiceReservation",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceReservation_Reservation_ReservationId",
                table: "InvoiceReservation",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceReservation_AspNetUsers_CreatorId",
                table: "InvoiceReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceReservation_Reservation_ReservationId",
                table: "InvoiceReservation");

            migrationBuilder.AlterColumn<string>(
                name: "ReservationId",
                table: "InvoiceReservation",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "InvoiceReservation",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceReservation_AspNetUsers_ReservationId",
                table: "InvoiceReservation",
                column: "ReservationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceReservation_Reservation_CreatorId",
                table: "InvoiceReservation",
                column: "CreatorId",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
