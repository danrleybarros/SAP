using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddInterestAndFineFinancialAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterestAndFineFinancialAccount",
                schema: "JsdnBill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InterestFinancialAccount = table.Column<string>(type: "varchar(15)", nullable: false),
                    InterestCredit = table.Column<string>(type: "varchar(15)", nullable: false),
                    InterestDebit = table.Column<string>(type: "varchar(15)", nullable: false),
                    InterestUnpaidInvoiceCredit = table.Column<string>(type: "varchar(15)", nullable: false),
                    InterestUnpaidInvoiceDebit = table.Column<string>(type: "varchar(15)", nullable: false),
                    InterestPaidInvoiceCredit = table.Column<string>(type: "varchar(15)", nullable: false),
                    InterestPaidInvoiceDebit = table.Column<string>(type: "varchar(15)", nullable: false),
                    InterestCycleEstimateCredit = table.Column<string>(type: "varchar(15)", nullable: false),
                    InterestCycleEstimateDebit = table.Column<string>(type: "varchar(15)", nullable: false),
                    FineFinancialAccount = table.Column<string>(type: "varchar(15)", nullable: false),
                    FineCredit = table.Column<string>(type: "varchar(15)", nullable: false),
                    FineDebit = table.Column<string>(type: "varchar(15)", nullable: false),
                    FineUnpaidInvoiceCredit = table.Column<string>(type: "varchar(15)", nullable: false),
                    FineUnpaidInvoiceDebit = table.Column<string>(type: "varchar(15)", nullable: false),
                    FinePaidInvoiceCredit = table.Column<string>(type: "varchar(15)", nullable: false),
                    FinePaidInvoiceDebit = table.Column<string>(type: "varchar(15)", nullable: false),
                    FineCycleEstimateCredit = table.Column<string>(type: "varchar(15)", nullable: false),
                    FineCycleEstimateDebit = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestAndFineFinancialAccount", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestAndFineFinancialAccount",
                schema: "JsdnBill");
        }
    }
}
