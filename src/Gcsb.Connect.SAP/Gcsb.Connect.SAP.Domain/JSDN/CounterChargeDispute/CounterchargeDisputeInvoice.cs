using System;

namespace Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute
{
    public class CounterchargeDisputeInvoice : CounterchargeDispute
    {
        public CounterchargeDisputeInvoice(string tipoSubscricao, DateTime? dataMovimentacao, string aReceber, string tipoTransacao,
            string uF, string ciclo, DateTime? referenciaCicloFaturamento, string codigoEmpresa, string flagTipoFaturamento,
            decimal valorTransacao, string numeroFatura, int customerCode, string codigoFranquia, string cNPJ, string cPF,
            string nomedaEmpresadoCliente, DateTime dataVencimento, DateTime dataCriacaoFatura, DateTime dataIniciodoCiclo,
            decimal? saldoTotalGeral, DateTime dataFimCiclo, DateTime? dataCriacaoPedido, char statusContadoCliente,
            char inadimplenciaPremeditada, string produto, string statusPagamento, string tipoDisputa, DateTime? dataConcessaoCredito,
            int numeroPedido, string motivoCredito, string nota, string loginUsuario, DateTime dataCortedoCiclo, string complemento,
            decimal? valorContestado, string centrodeCusto, string cicloContestado, string localdeTrabalho, DateTime? dataEmissaoBoletoRetificado,
            string codigoServico, decimal? valorContestacaoItem, string enderecoCobranca, string metodoPagamento, string storeAcronym, 
            string providerCompanyAcronym, string activity_type, string numeroOrdem, bool cicloNulo)
            : base(tipoSubscricao, dataMovimentacao, aReceber, tipoTransacao,
            uF, ciclo, referenciaCicloFaturamento, codigoEmpresa, flagTipoFaturamento,
            valorTransacao, numeroFatura, customerCode, codigoFranquia, cNPJ, cPF,
            nomedaEmpresadoCliente, dataVencimento, dataCriacaoFatura, dataIniciodoCiclo,
            saldoTotalGeral, dataFimCiclo, dataCriacaoPedido, statusContadoCliente,
            inadimplenciaPremeditada, produto, statusPagamento, tipoDisputa,
            dataConcessaoCredito, numeroPedido, motivoCredito, nota, loginUsuario,
            dataCortedoCiclo, complemento, valorContestado, centrodeCusto, cicloContestado,
            localdeTrabalho, dataEmissaoBoletoRetificado, codigoServico, valorContestacaoItem,
            enderecoCobranca, metodoPagamento, storeAcronym, providerCompanyAcronym, activity_type, 
            numeroOrdem, cicloNulo)
        { }

        public CounterchargeDisputeInvoice(CounterchargeDispute dispute) : base(dispute.TipoSubscricao, dispute.DataMovimentacao, dispute.AReceber,
            dispute.TipoTransacao, dispute.UF, dispute.Ciclo, dispute.ReferenciaCicloFaturamento, dispute.CodigoEmpresa, dispute.FlagTipoFaturamento,
            dispute.ValorTransacao, dispute.NumeroFatura, dispute.CustomerCode, dispute.CodigoFranquia, dispute.CNPJ, dispute.CPF,
            dispute.NomedaEmpresadoCliente, dispute.DataVencimento, dispute.DataCriacaoFatura, dispute.DataIniciodoCiclo,
            dispute.SaldoTotalGeral, dispute.DataFimCiclo, dispute.DataCriacaoPedido, dispute.StatusContadoCliente,
            dispute.InadimplenciaPremeditada, dispute.Produto, dispute.StatusPagamento, dispute.TipoDisputa,
            dispute.DataConcessaoCredito, dispute.NumeroPedido, dispute.MotivoCredito, dispute.Nota, dispute.LoginUsuario,
            dispute.DataCortedoCiclo, dispute.Complemento, dispute.ValorContestado, dispute.CentrodeCusto, dispute.CicloContestado,
            dispute.LocaldeTrabalho, dispute.DataEmissaoBoletoRetificado, dispute.CodigoServico, dispute.ValorContestacaoItem,
            dispute.EnderecoCobranca, dispute.MetodoPagamento, dispute.StoreAcronym, dispute.ProviderCompanyAcronym, dispute.TipoAtividade, 
            dispute.NumeroOrdem, dispute.CicloNulo)
        { }
    }
}
