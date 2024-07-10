using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddFinancilAccountContractualFine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaContCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaContDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaContNpagaCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaContNpagaDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaContPagaCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaContPagaDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaEstimativaCicloCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaEstimativaCicloDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MultaQuebraContFAT",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaContCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaContDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaContNpagaCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaContNpagaDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaContPagaCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaContPagaDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaEstimativaCicloCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilMultaEstimativaCicloDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MultaQuebraContFAT",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 15,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContaContabilMultaContCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaContDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaContNpagaCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaContNpagaDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaContPagaCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaContPagaDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaEstimativaCicloCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaEstimativaCicloDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "MultaQuebraContFAT",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaContCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaContDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaContNpagaCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaContNpagaDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaContPagaCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaContPagaDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaEstimativaCicloCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilMultaEstimativaCicloDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "MultaQuebraContFAT",
                schema: "JsdnBill",
                table: "FinancialAccount");
        }
    }
}
