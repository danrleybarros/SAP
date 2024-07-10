using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class DropFKInvoiceNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_PaymentFeed_InvoiceNumberJsdn1",
                schema: "JsdnBill",
                table: "PaymentFeed",
                column: "InvoiceNumberJsdn");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentFeed_Invoice_InvoiceNumberJsdn1",
                schema: "JsdnBill",
                table: "PaymentFeed",
                column: "InvoiceNumberJsdn",
                principalSchema: "JsdnBill",
                principalTable: "Invoice",
                principalColumn: "InvoiceNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentFeed_Invoice_InvoiceNumberJsdn1",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropIndex(
                name: "IX_PaymentFeed_InvoiceNumberJsdn1",
                schema: "JsdnBill",
                table: "PaymentFeed");

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
    }
}
