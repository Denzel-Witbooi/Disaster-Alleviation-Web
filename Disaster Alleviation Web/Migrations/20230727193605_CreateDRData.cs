using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Disaster_Alleviation_Web.Migrations
{
    public partial class CreateDRData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AidType",
                columns: table => new
                {
                    AidTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AidType", x => x.AidTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Monetary",
                columns: table => new
                {
                    MonetaryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonationAmount = table.Column<decimal>(type: "money", nullable: false),
                    DonorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monetary", x => x.MonetaryID);
                });

            migrationBuilder.CreateTable(
                name: "Disaster",
                columns: table => new
                {
                    DisasterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AidTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disaster", x => x.DisasterID);
                    table.ForeignKey(
                        name: "FK_Disaster_AidType_AidTypeID",
                        column: x => x.AidTypeID,
                        principalTable: "AidType",
                        principalColumn: "AidTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Good",
                columns: table => new
                {
                    GoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    DisasterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Good", x => x.GoodID);
                    table.ForeignKey(
                        name: "FK_Good_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Good_Disaster_DisasterID",
                        column: x => x.DisasterID,
                        principalTable: "Disaster",
                        principalColumn: "DisasterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodsPurchase",
                columns: table => new
                {
                    GoodsPurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisasterId = table.Column<int>(type: "int", nullable: false),
                    MonetaryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    purchaseAmount = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsPurchase", x => x.GoodsPurchaseId);
                    table.ForeignKey(
                        name: "FK_GoodsPurchase_Disaster_DisasterId",
                        column: x => x.DisasterId,
                        principalTable: "Disaster",
                        principalColumn: "DisasterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsPurchase_Monetary_MonetaryId",
                        column: x => x.MonetaryId,
                        principalTable: "Monetary",
                        principalColumn: "MonetaryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disaster_AidTypeID",
                table: "Disaster",
                column: "AidTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Good_CategoryID",
                table: "Good",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Good_DisasterID",
                table: "Good",
                column: "DisasterID");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsPurchase_DisasterId",
                table: "GoodsPurchase",
                column: "DisasterId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsPurchase_MonetaryId",
                table: "GoodsPurchase",
                column: "MonetaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Good");

            migrationBuilder.DropTable(
                name: "GoodsPurchase");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Disaster");

            migrationBuilder.DropTable(
                name: "Monetary");

            migrationBuilder.DropTable(
                name: "AidType");
        }
    }
}
