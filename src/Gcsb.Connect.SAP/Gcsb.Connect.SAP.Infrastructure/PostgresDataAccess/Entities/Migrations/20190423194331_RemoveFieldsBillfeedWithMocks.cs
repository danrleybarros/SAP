using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class RemoveFieldsBillfeedWithMocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
