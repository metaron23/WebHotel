using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebHotel.Data.Migrations
{
    public partial class changedatabase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsPermanent",
                table: "Discount",
                type: "bit",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "((false))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsPermanent",
                table: "Discount",
                type: "bit",
                nullable: true,
                defaultValueSql: "((false))",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "((0))");
        }
    }
}
