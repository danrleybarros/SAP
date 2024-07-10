using Microsoft.EntityFrameworkCore.Migrations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.Migrations
{
    public partial class AddCloudCoFinancialAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlScript =
                @"insert into ""JsdnBill"".""FinancialAccount""
                select
                    md5(random()::text || clock_timestamp()::text)::uuid, ""ServiceCode"", ""ServiceCodeName"", ""FaturamentoFAT"", ""FaturamentoAJU"", ""DescontoFAT"", ""ContaContabilContestacaoCred"", ""ContaContabilFATCred"", ""ContaContabilFATDeb"", ""ContaContabilIMPCRED"", ""ContaContabilIMPDEB"", ""ContaContabilContestacaoDeb"", ""CompensacaoAJU"", ""ContaFuturaAJUCred"", ""ContaFuturaAJUDeb"", ""BoletoRetificadoCred"", ""BoletoRetificadoDeb"", ""ContaContabilAjusteCompetenciaCred"", ""ContaContabilAjusteCompetenciaDeb"", ""ContaContabilEstimativaCicloCred"", ""ContaContabilEstimativaCicloDeb"", 2 as ""StoreType""
                from ""JsdnBill"".""FinancialAccount""
                where ""StoreType"" = 1";

            migrationBuilder.Sql(sqlScript);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
