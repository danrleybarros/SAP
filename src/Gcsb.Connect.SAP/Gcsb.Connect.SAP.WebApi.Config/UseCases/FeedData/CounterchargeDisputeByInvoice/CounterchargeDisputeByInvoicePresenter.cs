using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CounterchargeDisputeByInvoice
{
    public class CounterchargeDisputeByInvoicePresenter : IOutputPort<List<CounterchargeDisputeInvoice>>
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "Error",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);

        public void Standard(List<CounterchargeDisputeInvoice> output)
        {
            var response = new List<CounterchargeDisputeByInvoiceResponse>();

            output.ForEach(f =>
            {
                response.Add(new CounterchargeDisputeByInvoiceResponse
                    (
                        f.TipoSubscricao,
                        f.DataMovimentacao,
                        f.AReceber,
                        f.TipoTransacao,
                        f.UF,
                        f.Ciclo,
                        f.ReferenciaCicloFaturamento,
                        f.CodigoEmpresa,
                        f.FlagTipoFaturamento,
                        f.ValorTransacao,
                        f.NumeroFatura,
                        f.CustomerCode,
                        f.CodigoFranquia,
                        f.CNPJ,
                        f.CPF,
                        f.NomedaEmpresadoCliente,
                        f.DataVencimento,
                        f.DataCriacaoFatura,
                        f.DataIniciodoCiclo,
                        f.SaldoTotalGeral,
                        f.DataFimCiclo,
                        f.DataCriacaoPedido,
                        f.StatusContadoCliente,
                        f.InadimplenciaPremeditada,
                        f.Produto,
                        f.StatusPagamento,
                        f.TipoDisputa,
                        f.DataConcessaoCredito,
                        f.NumeroPedido,
                        f.MotivoCredito,
                        f.Nota,
                        f.LoginUsuario,
                        f.DataCortedoCiclo,
                        f.Complemento,
                        f.ValorContestado,
                        f.CentrodeCusto,
                        f.CicloContestado,
                        f.LocaldeTrabalho,
                        f.DataEmissaoBoletoRetificado,
                        f.CodigoServico,
                        f.ValorContestacaoItem,
                        f.EnderecoCobranca,
                        f.MetodoPagamento,
                        f.StoreAcronym,
                        f.ProviderCompanyAcronym,
                        f.TipoAtividade
                    ));
            });

            ViewModel = new OkObjectResult(response);
        }
    }
}
