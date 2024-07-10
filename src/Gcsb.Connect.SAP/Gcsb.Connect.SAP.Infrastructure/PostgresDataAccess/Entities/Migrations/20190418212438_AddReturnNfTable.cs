using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddReturnNfTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReturnNF",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: false),
                    InvoiceID = table.Column<string>(maxLength: 50, nullable: false),
                    NumeroNF = table.Column<string>(maxLength: 50, nullable: false),
                    SerieNF = table.Column<string>(maxLength: 50, nullable: false),
                    DataEmissaoNF = table.Column<DateTime>(nullable: false),
                    ValorTotalNF = table.Column<decimal>(nullable: false),
                    ValorTotalDescontoNF = table.Column<decimal>(nullable: false),
                    NFCancelada = table.Column<string>(nullable: false),
                    ChaveNF = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnNF", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReturnNF_InvoiceID",
                schema: "JsdnBill",
                table: "ReturnNF",
                column: "InvoiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturnNF",
                schema: "JsdnBill");
        }
    }
}
