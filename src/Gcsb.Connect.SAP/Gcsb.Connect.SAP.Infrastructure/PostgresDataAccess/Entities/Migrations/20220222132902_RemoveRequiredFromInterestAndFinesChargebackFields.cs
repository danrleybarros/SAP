using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class RemoveRequiredFromInterestAndFinesChargebackFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InterestGrantedDebitAccountingDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "InterestGrantedDebitAccountingCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "FineGrantedDebitAccountingDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "FineGrantedDebitAccountingCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "InterestChargebackRectifiedBoletoDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "InterestChargebackRectifiedBoletoCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "FineChargebackRectifiedBoletoDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "FineChargebackRectifiedBoletoCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "InterestChargebackFutureCreditUsedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "InterestChargebackFutureCreditUsedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "FineChargebackFutureCreditUsedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "FineChargebackFutureCreditUsedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "InterestChargebackFutureCreditUnusedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "InterestChargebackFutureCreditUnusedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "FineChargebackFutureCreditUnusedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "FineChargebackFutureCreditUnusedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "InterestGrantedDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "InterestBilledCounterchargeChargeback",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "FineGrantedDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "FineBilledCounterchargeChargeback",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InterestGrantedDebitAccountingDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InterestGrantedDebitAccountingCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FineGrantedDebitAccountingDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FineGrantedDebitAccountingCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InterestChargebackRectifiedBoletoDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InterestChargebackRectifiedBoletoCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FineChargebackRectifiedBoletoDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FineChargebackRectifiedBoletoCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InterestChargebackFutureCreditUsedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InterestChargebackFutureCreditUsedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FineChargebackFutureCreditUsedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FineChargebackFutureCreditUsedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InterestChargebackFutureCreditUnusedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InterestChargebackFutureCreditUnusedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FineChargebackFutureCreditUnusedValueDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FineChargebackFutureCreditUnusedValueCredit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InterestGrantedDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InterestBilledCounterchargeChargeback",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FineGrantedDebit",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FineBilledCounterchargeChargeback",
                schema: "JsdnBill",
                table: "InterestAndFineFinancialAccount",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);
        }
    }
}
