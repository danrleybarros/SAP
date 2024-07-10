using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDisputeByInvoices.RequestHandlers
{
    public class GetCounterChargeDisputesHandler : Handler
    {
        private readonly IJsdnRepository jsdnRepository;

        public GetCounterChargeDisputesHandler(IJsdnRepository jsdnRepository)
        {
            this.jsdnRepository = jsdnRepository;
        }

        public override void ProcessRequest(CounterchargeDisputeByInvoicesRequest request)
        {
            var result = jsdnRepository.GetCounterchargeDisputeByInvoice(request.InvoicesNumber);

            if (result.Count > 0)
            {
                request.CounterchargeDisputes = result.Select(s => new CounterchargeDisputeInvoice(
                    s.TipoSubscricao, s.DataMovimentacao, s.AReceber, s.TipoTransacao,
                    s.UF, s.Ciclo, s.ReferenciaCicloFaturamento, s.CodigoEmpresa, s.FlagTipoFaturamento,
                    s.ValorTransacao, s.NumeroFatura, s.CustomerCode, s.CodigoFranquia, s.CNPJ, s.CPF,
                    s.NomedaEmpresadoCliente, s.DataVencimento, s.DataCriacaoFatura, s.DataIniciodoCiclo,
                    s.SaldoTotalGeral, s.DataFimCiclo, s.DataCriacaoPedido, s.StatusContadoCliente,
                    s.InadimplenciaPremeditada, s.Produto, s.StatusPagamento, s.TipoDisputa,
                    s.DataConcessaoCredito, s.NumeroPedido, s.MotivoCredito, s.Nota, s.LoginUsuario,
                    s.DataCortedoCiclo, s.Complemento, s.ValorContestado, s.CentrodeCusto, s.CicloContestado,
                    s.LocaldeTrabalho, s.DataEmissaoBoletoRetificado, s.CodigoServico, s.ValorContestacaoItem,
                    s.EnderecoCobranca, s.MetodoPagamento, s.StoreAcronym, s.ProviderCompanyAcronym, s.TipoAtividade, 
                    s.NumeroOrdem, s.CicloNulo
                )).ToList();
            }

            sucessor?.ProcessRequest(request);
        }
    }
}
