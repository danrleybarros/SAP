using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddFinancialAccountsToInterestAndFine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FineBilledCounterchargeChargeback",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FineGrantedDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InterestBilledCounterchargeChargeback",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InterestGrantedDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FineChargebackFutureCreditUnusedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FineChargebackFutureCreditUnusedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InterestChargebackFutureCreditUnusedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InterestChargebackFutureCreditUnusedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FineChargebackFutureCreditUsedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FineChargebackFutureCreditUsedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InterestChargebackFutureCreditUsedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InterestChargebackFutureCreditUsedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FineChargebackRectifiedBoletoCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FineChargebackRectifiedBoletoDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InterestChargebackRectifiedBoletoCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InterestChargebackRectifiedBoletoDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FineGrantedDebitAccountingCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FineGrantedDebitAccountingDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InterestGrantedDebitAccountingCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InterestGrantedDebitAccountingDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FineBilledCounterchargeChargeback",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "FineGrantedDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "InterestBilledCounterchargeChargeback",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "InterestGrantedDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "FineChargebackFutureCreditUnusedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "FineChargebackFutureCreditUnusedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "InterestChargebackFutureCreditUnusedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "InterestChargebackFutureCreditUnusedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "FineChargebackFutureCreditUsedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "FineChargebackFutureCreditUsedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "InterestChargebackFutureCreditUsedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "InterestChargebackFutureCreditUsedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "FineChargebackRectifiedBoletoCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "FineChargebackRectifiedBoletoDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "InterestChargebackRectifiedBoletoCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "InterestChargebackRectifiedBoletoDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "FineGrantedDebitAccountingCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "FineGrantedDebitAccountingDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "InterestGrantedDebitAccountingCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");

            migrationBuilder.DropColumn(
                name: "InterestGrantedDebitAccountingDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount");
        }
    }
}
