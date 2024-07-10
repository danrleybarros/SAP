using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddFieldTotalRetailPriceWithTaxesWithoutDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalRetailPriceWithTaxesWithoutDiscount",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalRetailPriceWithTaxesWithoutDiscount",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRetailPriceWithTaxesWithoutDiscount",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "TotalRetailPriceWithTaxesWithoutDiscount",
                schema: "JsdnBill",
                table: "BillFeed");
        }
    }
}
