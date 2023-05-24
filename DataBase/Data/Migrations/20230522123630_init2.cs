using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceReservation_AspNetUsers_CreatorId",
                table: "InvoiceReservation");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceReservation_CreatorId",
                table: "InvoiceReservation");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReservation_CreatorId",
                table: "InvoiceReservation",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceReservation_ApplicationUser",
                table: "InvoiceReservation",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceReservation_ApplicationUser",
                table: "InvoiceReservation");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceReservation_CreatorId",
                table: "InvoiceReservation");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReservation_CreatorId",
                table: "InvoiceReservation",
                column: "CreatorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceReservation_AspNetUsers_CreatorId",
                table: "InvoiceReservation",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
