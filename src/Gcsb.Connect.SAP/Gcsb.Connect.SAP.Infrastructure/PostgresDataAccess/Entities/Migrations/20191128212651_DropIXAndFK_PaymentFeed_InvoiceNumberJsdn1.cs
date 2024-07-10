using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class DropIXAndFK_PaymentFeed_InvoiceNumberJsdn1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_PaymentFeed_Invoice_InvoiceNumberJsdn1",
               schema: "JsdnBill",
               table: "PaymentFeed");

            migrationBuilder.DropIndex(
                name: "IX_PaymentFeed_InvoiceNumberJsdn1",
                schema: "JsdnBill",
                table: "PaymentFeed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
