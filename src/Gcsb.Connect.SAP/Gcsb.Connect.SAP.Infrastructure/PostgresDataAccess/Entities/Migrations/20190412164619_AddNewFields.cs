using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "TaxCodeCOFINS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxCodeISS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxCodePIS",
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
                name: "TotalTaxCOFINS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTaxISS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTaxPIS",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AffiliateCode",
                schema: "JsdnBill",
                table: "Invoice",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityHallServiceDescription",
                schema: "JsdnBill",
                table: "Invoice",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityServiceCode",
                schema: "JsdnBill",
                table: "Invoice",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCode",
                schema: "JsdnBill",
                table: "Invoice",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MunicipalTaxpayerRegistration",
                schema: "JsdnBill",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialProcedureNumber",
                schema: "JsdnBill",
                table: "Invoice",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalInvoicePrice",
                schema: "JsdnBill",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CnpjMarketPlace",
                schema: "JsdnBill",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyNameMarketPlace",
                schema: "JsdnBill",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndividualInvoice",
                schema: "JsdnBill",
                table: "Customer",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AffiliateCode",
                schema: "JsdnBill",
                table: "BillFeed",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityHallServiceDescription",
                schema: "JsdnBill",
                table: "BillFeed",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityServiceCode",
                schema: "JsdnBill",
                table: "BillFeed",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CnpjMarketPlace",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCode",
                schema: "JsdnBill",
                table: "BillFeed",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyNameMarketPlace",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndividualInvoice",
                schema: "JsdnBill",
                table: "BillFeed",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MunicipalTaxpayerRegistration",
                schema: "JsdnBill",
                table: "BillFeed",
                maxLength: 20,
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

            migrationBuilder.AddColumn<string>(
                name: "SpecialProcedureNumber",
                schema: "JsdnBill",
                table: "BillFeed",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxCode",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxCodeCOFINS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxCodePIS",
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

            migrationBuilder.AddColumn<decimal>(
                name: "TotalInvoicePrice",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTaxCOFINS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTaxISS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTaxPIS",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "TaxCodeCOFINS",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "TaxCodeISS",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "TaxCodePIS",
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
                name: "TotalTaxCOFINS",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "TotalTaxISS",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "TotalTaxPIS",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "AffiliateCode",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CityHallServiceDescription",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CityServiceCode",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CompanyCode",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "MunicipalTaxpayerRegistration",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "SpecialProcedureNumber",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "TotalInvoicePrice",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CnpjMarketPlace",
                schema: "JsdnBill",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CompanyNameMarketPlace",
                schema: "JsdnBill",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IndividualInvoice",
                schema: "JsdnBill",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "AffiliateCode",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "CityHallServiceDescription",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "CityServiceCode",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "CnpjMarketPlace",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "CompanyCode",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "CompanyNameMarketPlace",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "IndividualInvoice",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "MunicipalTaxpayerRegistration",
                schema: "JsdnBill",
                table: "BillFeed");

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
                name: "SpecialProcedureNumber",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "TaxCode",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "TaxCodeCOFINS",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "TaxCodePIS",
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

            migrationBuilder.DropColumn(
                name: "TotalInvoicePrice",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "TotalTaxCOFINS",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "TotalTaxISS",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "TotalTaxPIS",
                schema: "JsdnBill",
                table: "BillFeed");
        }
    }
}
