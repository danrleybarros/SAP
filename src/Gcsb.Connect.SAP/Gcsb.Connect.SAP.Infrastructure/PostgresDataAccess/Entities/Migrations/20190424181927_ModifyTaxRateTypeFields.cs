using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class ModifyTaxRateTypeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TaxRateCOFINS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRateISS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRatePIS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRateCOFINS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRateISS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRatePIS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxRateCOFINS",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "TaxRateISS",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "TaxRatePIS",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "TaxRateCOFINS",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "TaxRateISS",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "TaxRatePIS",
                schema: "JsdnBill",
                table: "BillFeed");
        }
    }
}
