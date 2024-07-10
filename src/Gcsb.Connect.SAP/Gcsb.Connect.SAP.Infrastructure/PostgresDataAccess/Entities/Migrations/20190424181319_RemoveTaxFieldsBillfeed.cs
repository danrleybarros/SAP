using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class RemoveTaxFieldsBillfeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecurringTaxCOFINS",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "RecurringTaxISS",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "RecurringTaxPIS",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "SetupTaxCOFINS",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "SetupTaxISS",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "SetupTaxPIS",
                schema: "JsdnBill",
                table: "ServiceInvoice");

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
                name: "RecurringTaxCOFINS",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "RecurringTaxISS",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "RecurringTaxPIS",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "SetupTaxCOFINS",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "SetupTaxISS",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "SetupTaxPIS",
                schema: "JsdnBill",
                table: "BillFeed");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RecurringTaxCOFINS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RecurringTaxISS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RecurringTaxPIS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SetupTaxCOFINS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SetupTaxISS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SetupTaxPIS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxRateCOFINS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxRateISS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxRatePIS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RecurringTaxCOFINS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RecurringTaxISS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RecurringTaxPIS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SetupTaxCOFINS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SetupTaxISS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SetupTaxPIS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxRateCOFINS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxRateISS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxRatePIS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);
        }
    }
}
