using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddFinancialAccountDebitoConcedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContaContabilDebitoConcedidoCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilDebitoConcedidoDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilESTCredFuturoValorNUTILCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilESTCredFuturoValorNUTILDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilESTCredFuturoValorUTILCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilESTCredFuturoValorUTILDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaFaturaDebitoConcedido",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaFaturaEstornoContestacao",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstBoletoRetificadoCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstBoletoRetificadoDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilDebitoConcedidoCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilDebitoConcedidoDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilESTCredFuturoValorNUTILCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilESTCredFuturoValorNUTILDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilESTCredFuturoValorUTILCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilESTCredFuturoValorUTILDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaFaturaDebitoConcedido",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaFaturaEstornoContestacao",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstBoletoRetificadoCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstBoletoRetificadoDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContaContabilDebitoConcedidoCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilDebitoConcedidoDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilESTCredFuturoValorNUTILCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilESTCredFuturoValorNUTILDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilESTCredFuturoValorUTILCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilESTCredFuturoValorUTILDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaFaturaDebitoConcedido",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaFaturaEstornoContestacao",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "EstBoletoRetificadoCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "EstBoletoRetificadoDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilDebitoConcedidoCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilDebitoConcedidoDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilESTCredFuturoValorNUTILCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilESTCredFuturoValorNUTILDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilESTCredFuturoValorUTILCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilESTCredFuturoValorUTILDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaFaturaDebitoConcedido",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaFaturaEstornoContestacao",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "EstBoletoRetificadoCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "EstBoletoRetificadoDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");
        }
    }
}
