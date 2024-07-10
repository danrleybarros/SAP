using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AlteredFieldCycleCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CycleCode",
                schema: "JsdnBill",
                table: "ServiceInvoice");

            migrationBuilder.AddColumn<DateTime>(
                name: "CycleCode",
                schema: "JsdnBill",
                table: "Invoice",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CycleCode",
                schema: "JsdnBill",
                table: "Invoice");

            migrationBuilder.AddColumn<DateTime>(
                name: "CycleCode",
                schema: "JsdnBill",
                table: "ServiceInvoice",
                nullable: true);
        }
    }
}
