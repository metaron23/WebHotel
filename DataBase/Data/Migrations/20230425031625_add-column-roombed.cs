using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Data.Migrations
{
    public partial class addcolumnroombed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfBed",
                table: "Room",
                newName: "NumberOfSimpleBed");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDoubleBed",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfDoubleBed",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "NumberOfSimpleBed",
                table: "Room",
                newName: "NumberOfBed");
        }
    }
}
