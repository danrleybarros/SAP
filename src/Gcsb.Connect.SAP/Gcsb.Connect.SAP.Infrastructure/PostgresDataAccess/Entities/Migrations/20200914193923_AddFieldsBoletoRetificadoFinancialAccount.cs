using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddFieldsBoletoRetificadoFinancialAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoletoRetificadoCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoletoRetificadoDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoletoRetificadoCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoletoRetificadoDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoletoRetificadoCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "BoletoRetificadoDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "BoletoRetificadoCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "BoletoRetificadoDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");
        }
    }
}
