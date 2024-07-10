using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddContaContabilContestacaoDeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContaContabilContestacaoDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilContestacaoDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContaContabilContestacaoDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilContestacaoDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");
        }
    }
}
