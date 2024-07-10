using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddPaymentBoletoAndCreditCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VersionId",
                schema: "JsdnBill",
                table: "PaymentFeed",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "JsdnBill",
                table: "PaymentFeed",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TypeOperation",
                schema: "JsdnBill",
                table: "PaymentFeed",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "TerminalId",
                schema: "JsdnBill",
                table: "PaymentFeed",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<int>(
                name: "ResultCode",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "MerchantId",
                schema: "JsdnBill",
                table: "PaymentFeed",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "JsdnBill",
                table: "PaymentFeed",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "CicloFaturamento",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CodigoBanco",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoBarras",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoConvenio",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVencimento",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Item",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NSA",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeBanco",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UF",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorRecebido",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentFeed_InvoiceNumber",
                schema: "JsdnBill",
                table: "PaymentFeed",
                column: "InvoiceNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentFeed_Invoice_InvoiceNumber",
                schema: "JsdnBill",
                table: "PaymentFeed",
                column: "InvoiceNumber",
                principalSchema: "JsdnBill",
                principalTable: "Invoice",
                principalColumn: "InvoiceNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentFeed_Invoice_InvoiceNumber",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropIndex(
                name: "IX_PaymentFeed_InvoiceNumber",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "CicloFaturamento",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "CodigoBanco",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "CodigoBarras",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "CodigoConvenio",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "DataVencimento",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "Item",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "NSA",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "NomeBanco",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "UF",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "ValorRecebido",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.AlterColumn<string>(
                name: "VersionId",
                schema: "JsdnBill",
                table: "PaymentFeed",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "JsdnBill",
                table: "PaymentFeed",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypeOperation",
                schema: "JsdnBill",
                table: "PaymentFeed",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TerminalId",
                schema: "JsdnBill",
                table: "PaymentFeed",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResultCode",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MerchantId",
                schema: "JsdnBill",
                table: "PaymentFeed",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "JsdnBill",
                table: "PaymentFeed",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
