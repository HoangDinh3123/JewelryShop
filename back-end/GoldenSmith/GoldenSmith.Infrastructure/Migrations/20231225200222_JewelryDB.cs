using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenSmith.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JewelryDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserPermission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Jewelry",
                columns: table => new
                {
                    JewelryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JewelryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JewelryDescription = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    JewelryWeight = table.Column<double>(type: "float", nullable: false),
                    JewelrySize = table.Column<double>(type: "float", nullable: false),
                    JewelryPrice = table.Column<double>(type: "float", nullable: false),
                    JewelryColor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jewelry", x => x.JewelryId);
                    table.ForeignKey(
                        name: "FK_Jewelry_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JewelryImage",
                columns: table => new
                {
                    JewelryImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JewelryImagePath = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    JewelryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JewelryImage", x => x.JewelryImageId);
                    table.ForeignKey(
                        name: "FK_JewelryImage_Jewelry_JewelryId",
                        column: x => x.JewelryId,
                        principalTable: "Jewelry",
                        principalColumn: "JewelryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JewelryReview",
                columns: table => new
                {
                    JewelryReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JewelryReviewRating = table.Column<double>(type: "float", nullable: false),
                    JewelryReviewComment = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    JewelryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JewelryReview", x => x.JewelryReviewId);
                    table.ForeignKey(
                        name: "FK_JewelryReview_Jewelry_JewelryId",
                        column: x => x.JewelryId,
                        principalTable: "Jewelry",
                        principalColumn: "JewelryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JewelryReview_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderDetailPrice = table.Column<double>(type: "float", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    JewelryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Jewelry_JewelryId",
                        column: x => x.JewelryId,
                        principalTable: "Jewelry",
                        principalColumn: "JewelryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jewelry_CategoryId",
                table: "Jewelry",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JewelryImage_JewelryId",
                table: "JewelryImage",
                column: "JewelryId");

            migrationBuilder.CreateIndex(
                name: "IX_JewelryReview_JewelryId",
                table: "JewelryReview",
                column: "JewelryId");

            migrationBuilder.CreateIndex(
                name: "IX_JewelryReview_UserId",
                table: "JewelryReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_JewelryId",
                table: "OrderDetail",
                column: "JewelryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JewelryImage");

            migrationBuilder.DropTable(
                name: "JewelryReview");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Jewelry");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
