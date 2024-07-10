using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddFKPaymentFeed_Invoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropForeignKey(
                name: "FK_Invoice_PaymentFeed_PaymentFeedId",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_PaymentFeedId",
                schema: "JsdnBill",
                table: "Invoice");
            */
            migrationBuilder.DropColumn(
                name: "InvoiceNumberJsdn",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "PaymentFeedId",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: true);

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
                name: "InvoiceNumber",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumberJsdn",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentFeedId",
                schema: "JsdnBill",
                table: "Invoice",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_PaymentFeedId",
                schema: "JsdnBill",
                table: "Invoice",
                column: "PaymentFeedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_PaymentFeed_PaymentFeedId",
                schema: "JsdnBill",
                table: "Invoice",
                column: "PaymentFeedId",
                principalSchema: "JsdnBill",
                principalTable: "PaymentFeed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
