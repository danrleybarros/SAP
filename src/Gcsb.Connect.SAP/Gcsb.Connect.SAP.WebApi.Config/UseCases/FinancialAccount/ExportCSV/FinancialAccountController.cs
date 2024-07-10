using System.Text;
using Gcsb.Connect.SAP.Application.UseCases.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccount.ExportCSV
{
    [Route("/api/FinancialAccount")]
    public class FinancialAccountController : ControllerBase
    {
        readonly IFinancialAccountSearchUseCase FinancialAccountResult;

        public FinancialAccountController(IFinancialAccountSearchUseCase FinancialAccountResult)
        {
            this.FinancialAccountResult = FinancialAccountResult;
        }

        /// <summary>
        /// Export Financial Accounts to CSV
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost()]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [Route("ExportCSV")]
        public FileResult ExportCSV([FromBody] FinancialAccountRequest request)
        {
            var sb = new StringBuilder();

            sb.AppendLine("ServiceCode;ServiceName;FaturamentoFAT;FaturamentoAJU;DescontoFAT;" +
                "ContaContabilFATCred;ContaContabilFATDeb;ContaContabilContestacaoCred;ContaContabilContestacaoDeb;ContaContabilIMPDEB;ContaContabilIMPCRED;" +
                "ContaContabilAjusteCompetenciaDeb;ContaContabilAjusteCompetenciaCred;ContaContabilEstimativaCicloDeb;ContaContabilEstimativaCicloCred;" +
                "MultaQuebraContFAT;ContaContabilMultaContDeb;ContaContabilMultaContCred;ContaContabilMultaContPagaDeb;ContaContabilMultaContPagaCred;" +
                "ContaContabilMultaContNpagaDeb;ContaContabilMultaContNpagaCred;ContaContabilMultaEstimativaCicloDeb;ContaContabilMultaEstimativaCicloCred;" +
                "ContaFaturaEstornoContestacao;ContaContabilESTCredFuturoValorNUTILDeb;ContaContabilESTCredFuturoValorNUTILCred;ContaContabilESTCredFuturoValorUTILDeb;" +
                "ContaContabilESTCredFuturoValorUTILCred;EstBoletoRetificadoDeb;EstBoletoRetificadoCred;ContaFaturaDebitoConcedido;ContaContabilDebitoConcedidoDeb;" +
                "ContaContabilDebitoConcedidoCred;ContaContabilProdutoNaoEmitidoPagoDeb;ContaContabilProdutoNaoEmitidoPagoCred;ContaContabilProdutoNaoEmitidoNaoPagoDeb;" +
                "ContaContabilProdutoNaoEmitidoNaoPagoCred;ContaContabilRecReceitaDeb;ContaContabilRecReceitaCred;StoreType");

            foreach (FinancialAccountResult data in FinancialAccountResult.Execute(request))
                sb.AppendLine(
                    data.ServiceCode + ";" +
                    data.ServiceName + ";" +
                    data.FaturamentoFAT + ";" +
                    data.FaturamentoAJU + ";" +
                    data.DescontoFAT + ";" +
                    data.ContaContabilFATCred + ";" +
                    data.ContaContabilFATDeb + ";" +
                    data.ContaContabilContestacaoCred + ";" +
                    data.ContaContabilContestacaoDeb + ";" +
                    data.ContaContabilIMPDEB + ";" +
                    data.ContaContabilIMPCRED + ";" +
                    data.ContaContabilAjusteCompetenciaDeb + ";" +
                    data.ContaContabilAjusteCompetenciaCred + ";" +
                    data.ContaContabilEstimativaCicloDeb + ";" +
                    data.ContaContabilEstimativaCicloCred + ";" +
                    data.MultaQuebraContFAT + ";" +
                    data.ContaContabilMultaContDeb + ";" +
                    data.ContaContabilMultaContCred + ";" +
                    data.ContaContabilMultaContPagaDeb + ";" +
                    data.ContaContabilMultaContPagaCred + ";" +
                    data.ContaContabilMultaContNpagaDeb + ";" +
                    data.ContaContabilMultaContNpagaCred + ";" +
                    data.ContaContabilMultaEstimativaCicloDeb + ";" +
                    data.ContaContabilMultaEstimativaCicloCred + ";" +
                    data.ContaFaturaEstornoContestacao + ";" +
                    data.ContaContabilESTCredFuturoValorNUTILDeb + ";" +
                    data.ContaContabilESTCredFuturoValorNUTILCred + ";" +
                    data.ContaContabilESTCredFuturoValorUTILDeb + ";" +
                    data.ContaContabilESTCredFuturoValorUTILCred + ";" +
                    data.EstBoletoRetificadoDeb + ";" +
                    data.EstBoletoRetificadoCred + ";" +
                    data.ContaFaturaDebitoConcedido + ";" +
                    data.ContaContabilDebitoConcedidoDeb + ";" +
                    data.ContaContabilDebitoConcedidoCred + ";" +
                    data.ContaContabilProdutoNaoEmitidoPagoDeb + ";" +
                    data.ContaContabilProdutoNaoEmitidoPagoCred + ";" +
                    data.ContaContabilProdutoNaoEmitidoNaoPagoDeb + ";" +
                    data.ContaContabilProdutoNaoEmitidoNaoPagoCred + ";" +
                    data.ContaContabilRecReceitaDeb + ";" +
                    data.ContaContabilRecReceitaCred + ";" +
                    data.StoreType
                    );

            return File(new UTF8Encoding().GetBytes(sb.ToString()), "text/csv", "FinancialAccount.csv");
        }
    }
}
