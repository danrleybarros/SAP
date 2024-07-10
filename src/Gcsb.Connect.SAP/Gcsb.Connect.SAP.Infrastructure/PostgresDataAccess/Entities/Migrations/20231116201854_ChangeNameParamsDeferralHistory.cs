using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class ChangeNameParamsDeferralHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeferralAmountProvisionShortTerm",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "DeferralAmountShortTermTotal");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountShortTermProvisionDebit",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountShortTermDeferralDebitInstallment");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountShortTermProvisionCredit",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountShortTermDeferralCreditInstallment");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountShortTermDebit",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountShortTermDebitTotal");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountShortTermCredit",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountShortTermCreditTotal");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountLongTermLowDebit",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountLongTermDebitTotal");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountLongTermLowCredit",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountLongTermDebitInstallment");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountLongTermDebit",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountLongTermCreditTotal");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountLongTermCredit",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountLongTermCreditInstallment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeferralAmountShortTermTotal",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "DeferralAmountProvisionShortTerm");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountShortTermDeferralDebitInstallment",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountShortTermProvisionDebit");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountShortTermDeferralCreditInstallment",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountShortTermProvisionCredit");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountShortTermDebitTotal",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountShortTermDebit");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountShortTermCreditTotal",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountShortTermCredit");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountLongTermDebitTotal",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountLongTermLowDebit");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountLongTermDebitInstallment",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountLongTermLowCredit");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountLongTermCreditTotal",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountLongTermDebit");

            migrationBuilder.RenameColumn(
                name: "AccountingAccountLongTermCreditInstallment",
                schema: "JsdnBill",
                table: "DeferralHistory",
                newName: "AccountingAccountLongTermCredit");
        }
    }
}
