using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class DropColumnArrecadacaoAJU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrecadacaoAJU",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ArrecadacaoAJU",
                schema: "JsdnBill",
                table: "FinancialAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArrecadacaoAJU",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ArrecadacaoAJU",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }
    }
}
