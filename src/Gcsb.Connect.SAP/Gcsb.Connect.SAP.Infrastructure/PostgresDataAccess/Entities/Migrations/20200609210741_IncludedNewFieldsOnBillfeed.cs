using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class IncludedNewFieldsOnBillfeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdabasCode",
                schema: "JsdnBill",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CpfUserHasMadeCredit",
                schema: "JsdnBill",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpportunityId",
                schema: "JsdnBill",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProposalNumber",
                schema: "JsdnBill",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuoteId",
                schema: "JsdnBill",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdabasCode",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CpfUserHasMadeCredit",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpportunityId",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProposalNumber",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuoteId",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdabasCode",
                schema: "JsdnBill",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CpfUserHasMadeCredit",
                schema: "JsdnBill",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "OpportunityId",
                schema: "JsdnBill",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ProposalNumber",
                schema: "JsdnBill",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "QuoteId",
                schema: "JsdnBill",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "AdabasCode",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "CpfUserHasMadeCredit",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "OpportunityId",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "ProposalNumber",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "QuoteId",
                schema: "JsdnBill",
                table: "BillFeed");
        }
    }
}
