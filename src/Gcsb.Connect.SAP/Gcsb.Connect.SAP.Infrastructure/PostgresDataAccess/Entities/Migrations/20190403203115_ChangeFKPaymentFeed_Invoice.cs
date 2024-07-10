using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class ChangeFKPaymentFeed_Invoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentFeed_Invoice_InvoiceNumber",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.RenameColumn(
                name: "InvoiceNumber",
                schema: "JsdnBill",
                table: "PaymentFeed",
                newName: "InvoiceNumberJsdn");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentFeed_InvoiceNumber",
                schema: "JsdnBill",
                table: "PaymentFeed",
                newName: "IX_PaymentFeed_InvoiceNumberJsdn");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentFeed_Invoice_InvoiceNumberJsdn",
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
                name: "FK_PaymentFeed_Invoice_InvoiceNumberJsdn",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.RenameColumn(
                name: "InvoiceNumberJsdn",
                schema: "JsdnBill",
                table: "PaymentFeed",
                newName: "InvoiceNumber");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentFeed_InvoiceNumberJsdn",
                schema: "JsdnBill",
                table: "PaymentFeed",
                newName: "IX_PaymentFeed_InvoiceNumber");

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
