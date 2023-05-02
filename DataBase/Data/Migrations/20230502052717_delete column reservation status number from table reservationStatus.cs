using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Data.Migrations
{
    public partial class deletecolumnreservationstatusnumberfromtablereservationStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusNumber",
                table: "ReservationStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusNumber",
                table: "ReservationStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
