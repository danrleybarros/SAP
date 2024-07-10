using Gcsb.Connect.SAP.Application.Boundaries.FinancialAccount;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccount.GetById
{
    public sealed class FinancialAccountGetbyIdPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "Error",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
         => ViewModel = new NotFoundObjectResult(message);


        public void Standard(Domain.Config.FinancialAccount financialAccount)
        {
            var response = new FinancialAccountGebyIdResponse
                (financialAccount.Id, financialAccount.ServiceCode,
                financialAccount.ServiceCodeName, financialAccount.FaturamentoFAT,
                financialAccount.FaturamentoAJU, financialAccount.DescontoFAT,
                financialAccount.ContaContabilFATCred, financialAccount.ContaContabilFATDeb,
                financialAccount.ContaContabilContestacaoCred, financialAccount.ContaContabilContestacaoDeb,
                financialAccount.BoletoRetificadoDeb, financialAccount.BoletoRetificadoCred,
                financialAccount.ContaContabilIMPCRED, financialAccount.ContaContabilIMPDEB,
                financialAccount.CompensacaoAJU, financialAccount.ContaFuturaAJUDeb, financialAccount.ContaFuturaAJUCred,
                financialAccount.ContaContabilAjusteCompetenciaDeb, financialAccount.ContaContabilAjusteCompetenciaCred,
                financialAccount.ContaContabilEstimativaCicloDeb, financialAccount.ContaContabilEstimativaCicloCred,
                financialAccount.MultaQuebraContFAT, financialAccount.ContaContabilMultaContDeb, financialAccount.ContaContabilMultaContCred,
                financialAccount.ContaContabilMultaContPagaDeb, financialAccount.ContaContabilMultaContPagaCred, financialAccount.ContaContabilMultaContNpagaDeb,
                financialAccount.ContaContabilMultaContNpagaCred, financialAccount.ContaContabilMultaEstimativaCicloDeb, financialAccount.ContaContabilMultaEstimativaCicloCred,
                financialAccount.ContaFaturaEstornoContestacao, financialAccount.ContaContabilESTCredFuturoValorNUTILDeb, financialAccount.ContaContabilESTCredFuturoValorNUTILCred,
                financialAccount.ContaContabilESTCredFuturoValorUTILDeb, financialAccount.ContaContabilESTCredFuturoValorUTILCred, financialAccount.EstBoletoRetificadoDeb,
                financialAccount.EstBoletoRetificadoCred, financialAccount.ContaFaturaDebitoConcedido, financialAccount.ContaContabilDebitoConcedidoDeb,
                financialAccount.ContaContabilDebitoConcedidoCred, financialAccount.ContaContabilProdutoNaoEmitidoPagoDeb, financialAccount.ContaContabilProdutoNaoEmitidoPagoCred,
                financialAccount.ContaContabilProdutoNaoEmitidoNaoPagoDeb, financialAccount.ContaContabilProdutoNaoEmitidoNaoPagoCred,
                financialAccount.ContaContabilRecReceitaDeb, financialAccount.ContaContabilRecReceitaCred);

            ViewModel = new OkObjectResult(response);
        }
    }
}
