using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopsRUsData.Migrations
{
    public partial class FirstInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_assetitems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketIntelligencePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_assetitems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsCustomerAffiliate = table.Column<bool>(type: "bit", nullable: false),
                    IsCustomerAnEmployee = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantID = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNo = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalItemAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubtotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalBalanceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalBalanceInWords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Initiator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_invoice", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_assetitems_ItemCode",
                table: "tbl_assetitems",
                column: "ItemCode",
                unique: true,
                filter: "[ItemCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customers_Email",
                table: "tbl_customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_customers_PhoneNo",
                table: "tbl_customers",
                column: "PhoneNo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_assetitems");

            migrationBuilder.DropTable(
                name: "tbl_customers");

            migrationBuilder.DropTable(
                name: "tbl_discounts");

            migrationBuilder.DropTable(
                name: "tbl_invoice");
        }
    }
}
