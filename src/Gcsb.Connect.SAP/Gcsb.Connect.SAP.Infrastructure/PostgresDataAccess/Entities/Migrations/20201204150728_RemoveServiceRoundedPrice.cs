using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class RemoveServiceRoundedPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRoundedPrice",
                schema: "JsdnBill");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceRoundedPrice",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdFile = table.Column<Guid>(nullable: false),
                    InvoiceNumber = table.Column<string>(nullable: false),
                    Qty = table.Column<double>(nullable: false),
                    RoundedPrice = table.Column<double>(nullable: false),
                    ServiceCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRoundedPrice", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRoundedPrice_IdFile",
                schema: "JsdnBill",
                table: "ServiceRoundedPrice",
                column: "IdFile");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRoundedPrice_InvoiceNumber",
                schema: "JsdnBill",
                table: "ServiceRoundedPrice",
                column: "InvoiceNumber");
        }
    }
}
