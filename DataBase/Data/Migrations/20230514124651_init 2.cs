using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceAttachDetail_ServiceAttachId",
                table: "ServiceAttachDetail");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAttachDetail_ServiceAttachId_RoomTypeId",
                table: "ServiceAttachDetail",
                columns: new[] { "ServiceAttachId", "RoomTypeId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceAttachDetail_ServiceAttachId_RoomTypeId",
                table: "ServiceAttachDetail");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAttachDetail_ServiceAttachId",
                table: "ServiceAttachDetail",
                column: "ServiceAttachId");
        }
    }
}
