using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class CreatePksInDocFeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_PaymentFeed_PaymentFeedIdFile",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentFeed",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillFeed",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_BillFeed_Sequence",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.RenameColumn(
                name: "PaymentFeedIdFile",
                schema: "JsdnBill",
                table: "Invoice",
                newName: "PaymentFeedId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_PaymentFeedIdFile",
                schema: "JsdnBill",
                table: "Invoice",
                newName: "IX_Invoice_PaymentFeedId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "JsdnBill",
                table: "PaymentFeed",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "JsdnBill",
                table: "BillFeed",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
             
            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentFeed",
                schema: "JsdnBill",
                table: "PaymentFeed",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillFeed",
                schema: "JsdnBill",
                table: "BillFeed",
                column: "Id");           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_PaymentFeed_PaymentFeedId",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentFeed",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillFeed",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "JsdnBill",
                table: "PaymentFeed");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "JsdnBill",
                table: "BillFeed");

            migrationBuilder.RenameColumn(
                name: "PaymentFeedId",
                schema: "JsdnBill",
                table: "Invoice",
                newName: "PaymentFeedIdFile");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_PaymentFeedId",
                schema: "JsdnBill",
                table: "Invoice",
                newName: "IX_Invoice_PaymentFeedIdFile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentFeed",
                schema: "JsdnBill",
                table: "PaymentFeed",
                column: "IdFile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillFeed",
                schema: "JsdnBill",
                table: "BillFeed",
                column: "IdFile");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_BillFeed_Sequence",
                schema: "JsdnBill",
                table: "BillFeed",
                column: "Sequence");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_PaymentFeed_PaymentFeedIdFile",
                schema: "JsdnBill",
                table: "Invoice",
                column: "PaymentFeedIdFile",
                principalSchema: "JsdnBill",
                principalTable: "PaymentFeed",
                principalColumn: "IdFile",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
