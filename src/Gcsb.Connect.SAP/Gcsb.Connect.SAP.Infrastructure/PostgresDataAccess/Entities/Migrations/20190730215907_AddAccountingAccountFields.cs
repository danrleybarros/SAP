using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddAccountingAccountFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContaContabilARRCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilARRDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilContestacaoCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilFATCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilFATDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilIMPCRED",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilIMPDEB",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilARRCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilARRDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilContestacaoCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilFATCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilFATDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilIMPCRED",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilIMPDEB",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContaContabilARRCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilARRDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilContestacaoCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilFATCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilFATDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilIMPCRED",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilIMPDEB",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilARRCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilARRDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilContestacaoCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilFATCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilFATDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilIMPCRED",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilIMPDEB",
                schema: "JsdnBill",
                table: "FinancialAccount");
        }
    }
}
