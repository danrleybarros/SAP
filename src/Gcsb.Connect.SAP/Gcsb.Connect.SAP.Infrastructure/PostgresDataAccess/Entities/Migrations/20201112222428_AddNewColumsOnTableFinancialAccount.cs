using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddNewColumsOnTableFinancialAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContaContabilAjusteCompetenciaCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilAjusteCompetenciaDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilEstimativaCicloCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilEstimativaCicloDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilAjusteCompetenciaCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilAjusteCompetenciaDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilEstimativaCicloCred",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContaContabilEstimativaCicloDeb",
                schema: "JsdnBill",
                table: "FinancialAccount",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContaContabilAjusteCompetenciaCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilAjusteCompetenciaDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilEstimativaCicloCred",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilEstimativaCicloDeb",
                schema: "JsdnBill",
                table: "FinancialAccountDate");

            migrationBuilder.DropColumn(
                name: "ContaContabilAjusteCompetenciaCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilAjusteCompetenciaDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilEstimativaCicloCred",
                schema: "JsdnBill",
                table: "FinancialAccount");

            migrationBuilder.DropColumn(
                name: "ContaContabilEstimativaCicloDeb",
                schema: "JsdnBill",
                table: "FinancialAccount");
        }
    }
}
