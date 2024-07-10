using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddCustomerRelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Customer_CustomerId",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_CustomerId",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_InvoiceNumber",
                schema: "JsdnBill",
                table: "Customer",
                column: "InvoiceNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Invoice_InvoiceNumber",
                schema: "JsdnBill",
                table: "Customer",
                column: "InvoiceNumber",
                principalSchema: "JsdnBill",
                principalTable: "Invoice",
                principalColumn: "InvoiceNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Invoice_InvoiceNumber",
                schema: "JsdnBill",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_InvoiceNumber",
                schema: "JsdnBill",
                table: "Customer");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                schema: "JsdnBill",
                table: "Invoice",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CustomerId",
                schema: "JsdnBill",
                table: "Invoice",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Customer_CustomerId",
                schema: "JsdnBill",
                table: "Invoice",
                column: "CustomerId",
                principalSchema: "JsdnBill",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
