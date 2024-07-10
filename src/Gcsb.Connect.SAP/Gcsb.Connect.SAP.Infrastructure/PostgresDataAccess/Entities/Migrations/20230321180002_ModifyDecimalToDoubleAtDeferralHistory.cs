using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class ModifyDecimalToDoubleAtDeferralHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalShortBalanceExceeded",
                schema: "JsdnBill",
                table: "DeferralHistory");

            migrationBuilder.AlterColumn<string>(
                name: "ActivationStatus",
                schema: "JsdnBill",
                table: "StatusActivationService",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActivationDate",
                schema: "JsdnBill",
                table: "StatusActivationService",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                schema: "JsdnBill",
                table: "StatusActivationService",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalShortBalance",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "TotalRetailPrice",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "TotalLongBalance",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceType",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Receivable",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentOption",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InternalOrder",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "GrandTotalRetailPrice",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "FilialCode",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "DeferralType",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeferralCycleCut",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<double>(
                name: "DeferralAmountProvisionShortTerm",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "DeferralAmountProvisionLongTerm",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "DeferralAmountProvision",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "DeferralAmountLowProvisionShortTerm",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "DeferralAmountLowProvisionLongTerm",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "DeferralAmount",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "CostCenter",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessLocation",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BillTo",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActivationDate",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<DateTime>(
                name: "InclusionDate",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "TransferShortBalanceToLongBalance",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                schema: "JsdnBill",
                table: "StatusActivationService");

            migrationBuilder.DropColumn(
                name: "InclusionDate",
                schema: "JsdnBill",
                table: "DeferralHistory");

            migrationBuilder.DropColumn(
                name: "TransferShortBalanceToLongBalance",
                schema: "JsdnBill",
                table: "DeferralHistory");

            migrationBuilder.AlterColumn<string>(
                name: "ActivationStatus",
                schema: "JsdnBill",
                table: "StatusActivationService",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActivationDate",
                schema: "JsdnBill",
                table: "StatusActivationService",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalShortBalance",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalRetailPrice",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalLongBalance",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceType",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Receivable",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentOption",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "InternalOrder",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "GrandTotalRetailPrice",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "FilialCode",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeferralType",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeferralCycleCut",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DeferralAmountProvisionShortTerm",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "DeferralAmountProvisionLongTerm",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "DeferralAmountProvision",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "DeferralAmountLowProvisionShortTerm",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "DeferralAmountLowProvisionLongTerm",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "DeferralAmount",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "CostCenter",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessLocation",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BillTo",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ActivationDate",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalShortBalanceExceeded",
                schema: "JsdnBill",
                table: "DeferralHistory",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
