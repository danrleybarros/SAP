using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddColumnTableFinancialAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContaContabilProdutoNaoEmitidoNaoPagoCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilProdutoNaoEmitidoNaoPagoDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilProdutoNaoEmitidoPagoCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilProdutoNaoEmitidoPagoDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilRecReceitaCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilRecReceitaDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilProdutoNaoEmitidoNaoPagoCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilProdutoNaoEmitidoNaoPagoDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilProdutoNaoEmitidoPagoCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilProdutoNaoEmitidoPagoDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilRecReceitaCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilRecReceitaDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContaContabilProdutoNaoEmitidoNaoPagoCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilProdutoNaoEmitidoNaoPagoDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilProdutoNaoEmitidoPagoCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilProdutoNaoEmitidoPagoDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilRecReceitaCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilRecReceitaDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilProdutoNaoEmitidoNaoPagoCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilProdutoNaoEmitidoNaoPagoDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilProdutoNaoEmitidoPagoCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilProdutoNaoEmitidoPagoDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilRecReceitaCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilRecReceitaDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");
        }
    }
}
