using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Data.Migrations
{
    public partial class addtableblogblogtypeblogtypedetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ShortTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PosterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blog_AspNetUsers",
                        column: x => x.PosterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BlogType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogTypeDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTypeId = table.Column<int>(type: "int", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTypeDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogTypeDetail_Blog",
                        column: x => x.BlogTypeId,
                        principalTable: "Blog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlogTypeDetail_BlogType",
                        column: x => x.BlogTypeId,
                        principalTable: "BlogType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_PosterId",
                table: "Blog",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTypeDetail_BlogTypeId",
                table: "BlogTypeDetail",
                column: "BlogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogTypeDetail");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "BlogType");
        }
    }
}
