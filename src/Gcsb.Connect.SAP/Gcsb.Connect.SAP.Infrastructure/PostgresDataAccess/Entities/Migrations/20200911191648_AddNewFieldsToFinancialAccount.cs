using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddNewFieldsToFinancialAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompensacaoAJU",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaFuturaAJUCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaFuturaAJUDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompensacaoAJU",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaFuturaAJUCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaFuturaAJUDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompensacaoAJU",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaFuturaAJUCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaFuturaAJUDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "CompensacaoAJU",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaFuturaAJUCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaFuturaAJUDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");
        }
    }
}
