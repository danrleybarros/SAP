using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class RemoveFinancial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceInvoice_FinancialAccount_AccountId",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropIndex(
                name: "IX_ServiceInvoice_AccountId",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "JsdnBill",
                table: "ServiceInvoice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceInvoice_AccountId",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceInvoice_FinancialAccount_AccountId",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                column: "AccountId",
                principalSchema: "JsdnBill",
                principalTable: "FinancialAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
