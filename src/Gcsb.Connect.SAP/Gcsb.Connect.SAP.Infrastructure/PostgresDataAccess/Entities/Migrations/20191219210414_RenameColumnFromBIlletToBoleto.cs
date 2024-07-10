using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class RenameColumnFromBIlletToBoleto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountingAccountBilletDebit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                newName: "AccountingAccountBoletoDebit");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountBilletCredit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                newName: "AccountingAccountBoletoCredit");

            migrationBuilder.RenameColumn(
                name: "FinancialAccountBillet",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                newName: "FinancialAccountBoleto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountingAccountBoletoDebit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                newName: "AccountingAccountBilletDebit");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountBoletoCredit",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                newName: "AccountingAccountBilletCredit");

            migrationBuilder.RenameColumn(
                name: "FinancialAccountBoleto",
                schema: "JsdnBill",
                table: "ManagementFinancialAccount",
                newName: "FinancialAccountBillet");
        }
    }
}
