using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class IncludedNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialAccountDate",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ServiceCode = table.Column<string>(maxLength: 100, nullable: false),
                    ServiceName = table.Column<string>(maxLength: 200, nullable: false),
                    FaturamentoFAT = table.Column<string>(maxLength: 15, nullable: false),
                    FaturamentoAJU = table.Column<string>(maxLength: 15, nullable: false),
                    DescontoFAT = table.Column<string>(maxLength: 15, nullable: false),
                    ArrecadacaoARR = table.Column<string>(maxLength: 15, nullable: false),
                    ArrecadacaoAJU = table.Column<string>(maxLength: 15, nullable: false),
                    DateIncluded = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialAccountDate", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialAccountDate",
                schema: "JsdnBill");
        }
    }
}
