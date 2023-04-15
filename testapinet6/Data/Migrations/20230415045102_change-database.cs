using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebHotel.Data.Migrations
{
    public partial class changedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Discount",
                type: "bit",
                nullable: true,
                defaultValueSql: "((1))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Discount");
        }
    }
}
