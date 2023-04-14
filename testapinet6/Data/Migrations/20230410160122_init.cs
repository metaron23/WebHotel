using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CMND = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: true, defaultValueSql: "GetDate()"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discount__3214EC070D2B3684", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusNumber = table.Column<int>(type: "int", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservat__3214EC0748171EE6", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RoomType__3214EC078A6FFBFF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceAttach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ServiceA__3214EC07B90411A4", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    Picture = table.Column<string>(type: "ntext", nullable: true),
                    PriceDiscount = table.Column<decimal>(type: "decimal(19,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ServiceR__3214EC077BECCD82", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TokenInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    AmountUse = table.Column<int>(type: "int", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsPermanent = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    DiscountTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discount__3214EC078ED86676", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_AspNetUsers",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Discount_DiscountType",
                        column: x => x.DiscountTypeId,
                        principalTable: "DiscountType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(newid())"),
                    RoomNumber = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "('true')"),
                    Description = table.Column<string>(type: "ntext", nullable: true),
                    RoomPicture = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    StarSum = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    PeopleNumber = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    NumberOfBed = table.Column<int>(type: "int", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(19,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    StarAmount = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    StarValue = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Room__3214EC078410FF00", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_RoomType",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceAttachDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    ServiceAttachId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ServiceA__3214EC0770EA377F", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceAttachDetail_RoomType",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceAttachDetail_ServiceAttach",
                        column: x => x.ServiceAttachId,
                        principalTable: "ServiceAttach",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiscountServiceDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discount__3214EC07F7AD559D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountServiceDetail_Discount",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountServiceDetail_ServiceRoom",
                        column: x => x.ServiceId,
                        principalTable: "ServiceRoom",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountService_AspNetUsers",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiscountRoomDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discount__3214EC0780B8A9E7", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountRoomDetail_AspNetUsers",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountRoomDetail_Discount",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountRoomDetail_Room",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "(newid())"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumberOfDay = table.Column<float>(type: "real", nullable: false, defaultValueSql: "1.0"),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RoomPrice = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    DepositEndAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedAt = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReservationPrice = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservat__3214EC075152009A", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_AspNetUsers",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservation_Room",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoomStar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RoomStar__3214EC0789A3F679", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomStar_Room",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiscountReservationDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discount__3214EC076173384A", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountReservationDetai_Reservation",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountReservationDetail_AspNetUsers",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountReservationDetail_Discount",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceReservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssuedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    PaidAt = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    PriceService = table.Column<decimal>(type: "decimal(19,2)", nullable: true, defaultValueSql: "((0))"),
                    PriceReservedRoom = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    ReservationId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ConfirmerId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__InvoiceR__3214EC07A70F1055", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceReservation_AspNetUsers",
                        column: x => x.ConfirmerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceReservation_Reservation",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ServiceRoomId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ReservationId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderSer__3214EC07E6ACBE95", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderService_AspNetUsers",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderService_Reservation",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderService_ServiceRoom",
                        column: x => x.ServiceRoomId,
                        principalTable: "ServiceRoom",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReservationChat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendUsername = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReceiveUsername = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Message = table.Column<string>(type: "ntext", nullable: true),
                    SendAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    IdFather = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservat__3214EC073328611D", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationChat_Reservation",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReservationStatusEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReservationId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReservationStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservat__3214EC07950B4BF3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationStatusEvents_ReservationStatus",
                        column: x => x.ReservationStatusId,
                        principalTable: "ReservationStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReservationStatusEventsn_Reservation",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "Discount_DiscountCode",
                table: "Discount",
                column: "DiscountCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discount_CreatorId",
                table: "Discount",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_DiscountTypeId",
                table: "Discount",
                column: "DiscountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountReservationDetail_CreatorId",
                table: "DiscountReservationDetail",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountReservationDetail_DiscountId",
                table: "DiscountReservationDetail",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountReservationDetail_ReservationId",
                table: "DiscountReservationDetail",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountRoomDetail_CreatorId",
                table: "DiscountRoomDetail",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountRoomDetail_DiscountId",
                table: "DiscountRoomDetail",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountRoomDetail_RoomId",
                table: "DiscountRoomDetail",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountServiceDetail_CreatorId",
                table: "DiscountServiceDetail",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountServiceDetail_DiscountId",
                table: "DiscountServiceDetail",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountServiceDetail_ServiceId",
                table: "DiscountServiceDetail",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "DiscountType_Name",
                table: "DiscountType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReservation_ConfirmerId",
                table: "InvoiceReservation",
                column: "ConfirmerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReservation_ReservationId",
                table: "InvoiceReservation",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderService_ReservationId",
                table: "OrderService",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderService_ServiceRoomId",
                table: "OrderService",
                column: "ServiceRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderService_UserId",
                table: "OrderService",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RoomId",
                table: "Reservation",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationChat_ReservationId",
                table: "ReservationChat",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationStatusEvents_ReservationId",
                table: "ReservationStatusEvents",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationStatusEvents_ReservationStatusId",
                table: "ReservationStatusEvents",
                column: "ReservationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeId",
                table: "Room",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "Room_Name",
                table: "Room",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Room_RoomNumber",
                table: "Room",
                column: "RoomNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomStar_RoomId",
                table: "RoomStar",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "RoomType_TypeName",
                table: "RoomType",
                column: "TypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ServiceAttach_Name",
                table: "ServiceAttach",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAttachDetail_RoomTypeId",
                table: "ServiceAttachDetail",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAttachDetail_ServiceAttachId",
                table: "ServiceAttachDetail",
                column: "ServiceAttachId");

            migrationBuilder.CreateIndex(
                name: "ServiceRoom_Name",
                table: "ServiceRoom",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DiscountReservationDetail");

            migrationBuilder.DropTable(
                name: "DiscountRoomDetail");

            migrationBuilder.DropTable(
                name: "DiscountServiceDetail");

            migrationBuilder.DropTable(
                name: "InvoiceReservation");

            migrationBuilder.DropTable(
                name: "OrderService");

            migrationBuilder.DropTable(
                name: "ReservationChat");

            migrationBuilder.DropTable(
                name: "ReservationStatusEvents");

            migrationBuilder.DropTable(
                name: "RoomStar");

            migrationBuilder.DropTable(
                name: "ServiceAttachDetail");

            migrationBuilder.DropTable(
                name: "TokenInfo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "ServiceRoom");

            migrationBuilder.DropTable(
                name: "ReservationStatus");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "ServiceAttach");

            migrationBuilder.DropTable(
                name: "DiscountType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "RoomType");
        }
    }
}
