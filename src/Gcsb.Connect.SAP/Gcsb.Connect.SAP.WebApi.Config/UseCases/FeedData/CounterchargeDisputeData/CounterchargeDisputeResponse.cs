using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.CounterchargeDisputeData
{
    public class CounterchargeDisputeResponse
    {
        public string TipoSubscricao { get; private set; }
        public DateTime? DataMovimentacao { get; private set; }
        public string AReceber { get; private set; }
        public string TipoTransacao { get; private set; }
        public string UF { get; private set; }
        public string Ciclo { get; private set; }
        public DateTime? ReferenciaCicloFaturamento { get; private set; }
        public string CodigoEmpresa { get; private set; }
        public string FlagTipoFaturamento { get; private set; }
        public decimal ValorTransacao { get; private set; }
        public string NumeroFatura { get; private set; }
        public int CustomerCode { get; private set; }
        public string CodigoFranquia { get; private set; }
        public string CNPJ { get; private set; }
        public string CPF { get; private set; }
        public string NomedaEmpresadoCliente { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public DateTime DataCriacaoFatura { get; private set; }
        public DateTime DataIniciodoCiclo { get; private set; }
        public decimal? SaldoTotalGeral { get; private set; }
        public DateTime DataFimCiclo { get; private set; }
        public DateTime? DataCriacaoPedido { get; private set; }
        public char StatusContadoCliente { get; private set; }
        public char InadimplenciaPremeditada { get; private set; }
        public string Produto { get; private set; }
        public string StatusPagamento { get; private set; }
        public string TipoDisputa { get; private set; }
        public DateTime? DataConcessaoCredito { get; private set; }
        public int NumeroPedido { get; private set; }
        public string MotivoCredito { get; private set; }
        public string Nota { get; private set; }
        public string LoginUsuario { get; private set; }
        public DateTime DataCortedoCiclo { get; private set; }
        public string Complemento { get; private set; }
        public decimal? ValorContestado { get; private set; }
        public string CentrodeCusto { get; private set; }
        public string CicloContestado { get; private set; }
        public string LocaldeTrabalho { get; private set; }
        public DateTime? DataEmissaoBoletoRetificado { get; private set; }
        public string CodigoServico { get; private set; }
        public decimal? ValorContestacaoItem { get; private set; }
        public string EnderecoCobranca { get; private set; }
        public string MetodoPagamento { get; private set; }
        public string StoreAcronym { get; private set; }
        public string ProviderCompanyAcronym { get; private set; }
        public string ActivityType { get; private set; }
        public string NumeroOrdem { get; private set; }

        public CounterchargeDisputeResponse(string tipoSubscricao, DateTime? dataMovimentacao, string aReceber,
            string tipoTransacao, string uF, string ciclo, DateTime? referenciaCicloFaturamento, string codigoEmpresa,
            string flagTipoFaturamento, decimal valorTransacao, string numeroFatura, int customerCode,
            string codigoFranquia, string cNPJ, string cPF, string nomedaEmpresadoCliente, DateTime dataVencimento,
            DateTime dataCriacaoFatura, DateTime dataIniciodoCiclo, decimal? saldoTotalGeral, DateTime dataFimCiclo,
            DateTime? dataCriacaoPedido, char statusContadoCliente, char inadimplenciaPremeditada, string produto,
            string statusPagamento, string tipoDisputa, DateTime? dataConcessaoCredito, int numeroPedido,
            string motivoCredito, string nota, string loginUsuario, DateTime dataCortedoCiclo, string complemento,
            decimal? valorContestado, string centrodeCusto, string cicloContestado, string localdeTrabalho,
            DateTime? dataEmissaoBoletoRetificado, string codigoServico, decimal? valorContestacaoItem,
            string enderecoCobranca, string metodoPagamento, string storeAcronym, string providerCompanyAcronym, 
            string activityType, string numeroOrdem)
        {
            TipoSubscricao = tipoSubscricao;
            DataMovimentacao = dataMovimentacao;
            AReceber = aReceber;
            TipoTransacao = tipoTransacao;
            UF = uF;
            Ciclo = ciclo;
            ReferenciaCicloFaturamento = referenciaCicloFaturamento;
            CodigoEmpresa = codigoEmpresa;
            FlagTipoFaturamento = flagTipoFaturamento;
            ValorTransacao = valorTransacao;
            NumeroFatura = numeroFatura;
            CustomerCode = customerCode;
            CodigoFranquia = codigoFranquia;
            CNPJ = cNPJ;
            CPF = cPF;
            NomedaEmpresadoCliente = nomedaEmpresadoCliente;
            DataVencimento = dataVencimento;
            DataCriacaoFatura = dataCriacaoFatura;
            DataIniciodoCiclo = dataIniciodoCiclo;
            SaldoTotalGeral = saldoTotalGeral;
            DataFimCiclo = dataFimCiclo;
            DataCriacaoPedido = dataCriacaoPedido;
            StatusContadoCliente = statusContadoCliente;
            InadimplenciaPremeditada = inadimplenciaPremeditada;
            Produto = produto;
            StatusPagamento = statusPagamento;
            TipoDisputa = tipoDisputa;
            DataConcessaoCredito = dataConcessaoCredito;
            NumeroPedido = numeroPedido;
            MotivoCredito = motivoCredito;
            Nota = nota;
            LoginUsuario = loginUsuario;
            DataCortedoCiclo = dataCortedoCiclo;
            Complemento = complemento;
            ValorContestado = valorContestado;
            CentrodeCusto = centrodeCusto;
            CicloContestado = cicloContestado;
            LocaldeTrabalho = localdeTrabalho;
            DataEmissaoBoletoRetificado = dataEmissaoBoletoRetificado;
            CodigoServico = codigoServico;
            ValorContestacaoItem = valorContestacaoItem;
            EnderecoCobranca = enderecoCobranca;
            MetodoPagamento = metodoPagamento;
            StoreAcronym = storeAcronym;
            ProviderCompanyAcronym = providerCompanyAcronym;
            ActivityType = activityType;
            NumeroOrdem = numeroOrdem;
        }
    }
}
