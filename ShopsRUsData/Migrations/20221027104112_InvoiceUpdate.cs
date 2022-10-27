using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopsRUsData.Migrations
{
    public partial class InvoiceUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "tbl_invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "tbl_invoice");
        }
    }
}
