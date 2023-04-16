using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatereservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Reservation");
        }
    }
}
