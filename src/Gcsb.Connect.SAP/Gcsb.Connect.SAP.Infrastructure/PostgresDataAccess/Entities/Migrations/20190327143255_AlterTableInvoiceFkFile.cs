using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AlterTableInvoiceFkFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_File_FileId",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInvoice_Invoice_InvoiceId",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropIndex(
                name: "IX_ServiceInvoice_InvoiceId",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_FileId",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "FileId",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "JsdnBill",
                table: "Log",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                schema: "JsdnBill",
                table: "Invoice",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdFile",
                schema: "JsdnBill",
                table: "Invoice",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                schema: "JsdnBill",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                schema: "JsdnBill",
                table: "Invoice",
                column: "InvoiceNumber");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Customer_InvoiceNumber",
                schema: "JsdnBill",
                table: "Customer",
                column: "InvoiceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInvoice_InvoiceNumber",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                column: "InvoiceNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_IdFile",
                schema: "JsdnBill",
                table: "Invoice",
                column: "IdFile");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_File_IdFile",
                schema: "JsdnBill",
                table: "Invoice",
                column: "IdFile",
                principalSchema: "JsdnBill",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInvoice_Invoice_InvoiceNumber",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                column: "InvoiceNumber",
                principalSchema: "JsdnBill",
                principalTable: "Invoice",
                principalColumn: "InvoiceNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_File_IdFile",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInvoice_Invoice_InvoiceNumber",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropIndex(
                name: "IX_ServiceInvoice_InvoiceNumber",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_IdFile",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Customer_InvoiceNumber",
                schema: "JsdnBill",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IdFile",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "JsdnBill",
                table: "Log",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                schema: "JsdnBill",
                table: "Invoice",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "JsdnBill",
                table: "Invoice",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                schema: "JsdnBill",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                schema: "JsdnBill",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                schema: "JsdnBill",
                table: "Invoice",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInvoice_InvoiceId",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_FileId",
                schema: "JsdnBill",
                table: "Invoice",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_File_FileId",
                schema: "JsdnBill",
                table: "Invoice",
                column: "FileId",
                principalSchema: "JsdnBill",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInvoice_Invoice_InvoiceId",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                column: "InvoiceId",
                principalSchema: "JsdnBill",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
