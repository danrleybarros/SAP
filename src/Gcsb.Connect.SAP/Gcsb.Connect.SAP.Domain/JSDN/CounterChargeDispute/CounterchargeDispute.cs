using Gcsb.Connect.SAP.Domain.Config;
using System;

namespace Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute
{
    public class CounterchargeDispute
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
        public string StoreAcronym { get; set; }
        public string ProviderCompanyAcronym { get; set; }
        public FinancialAccount FinancialAccount { get; set; } /*TODO: OLD*/
        public Domain.FinancialAccountsClient.FinancialAccount.FinancialAccount FinancialAccountNew { get; set; } /*TODO: NEW*/
        public string TipoAtividade { get; private set; }
        public TransactionType TransactionType => GetTransaction();
        public PaymentStatusType PaymentStatusType => GetPaymentStatus();
        public DisputeType DisputeType => GetDisputeType();
        public bool CicloNulo { get; private set; }
        public string NumeroOrdem { get; private set; }

        public CounterchargeDispute(string tipoSubscricao, DateTime? dataMovimentacao, string aReceber, string tipoTransacao,
            string uF, string ciclo, DateTime? referenciaCicloFaturamento, string codigoEmpresa, string flagTipoFaturamento,
            decimal valorTransacao, string numeroFatura, int customerCode, string codigoFranquia, string cNPJ, string cPF,
            string nomedaEmpresadoCliente, DateTime dataVencimento, DateTime dataCriacaoFatura, DateTime dataIniciodoCiclo,
            decimal? saldoTotalGeral, DateTime dataFimCiclo, DateTime? dataCriacaoPedido, char statusContadoCliente,
            char inadimplenciaPremeditada, string produto, string statusPagamento, string tipoDisputa, DateTime? dataConcessaoCredito,
            int numeroPedido, string motivoCredito, string nota, string loginUsuario, DateTime dataCortedoCiclo, string complemento,
            decimal? valorContestado, string centrodeCusto, string cicloContestado, string localdeTrabalho, DateTime? dataEmissaoBoletoRetificado,
            string codigoServico, decimal? valorContestacaoItem, string enderecoCobranca, string metodoPagamento, string storeAcronym, string tipoAtividade,
            string numeroOrdem, bool cicloNulo = false)
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
            TipoAtividade = tipoAtividade;
            StoreAcronym = storeAcronym;
            CicloNulo = cicloNulo;
            NumeroOrdem = numeroOrdem;
        }

        public CounterchargeDispute(string tipoSubscricao, DateTime? dataMovimentacao, string aReceber, string tipoTransacao,
            string uF, string ciclo, DateTime? referenciaCicloFaturamento, string codigoEmpresa, string flagTipoFaturamento,
            decimal valorTransacao, string numeroFatura, int customerCode, string codigoFranquia, string cNPJ, string cPF,
            string nomedaEmpresadoCliente, DateTime dataVencimento, DateTime dataCriacaoFatura, DateTime dataIniciodoCiclo,
            decimal? saldoTotalGeral, DateTime dataFimCiclo, DateTime? dataCriacaoPedido, char statusContadoCliente,
            char inadimplenciaPremeditada, string produto, string statusPagamento, string tipoDisputa, DateTime? dataConcessaoCredito,
            int numeroPedido, string motivoCredito, string nota, string loginUsuario, DateTime dataCortedoCiclo, string complemento,
            decimal? valorContestado, string centrodeCusto, string cicloContestado, string localdeTrabalho, DateTime? dataEmissaoBoletoRetificado,
            string codigoServico, decimal? valorContestacaoItem, string enderecoCobranca, string metodoPagamento, string storeAcronym, 
            string providerCompanyAcronym, string tipoAtividade, string numeroOrdem, bool cicloNulo = false)
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
            TipoAtividade = tipoAtividade;
            StoreAcronym = storeAcronym;
            ProviderCompanyAcronym = providerCompanyAcronym;
            CicloNulo = cicloNulo;
            NumeroOrdem = numeroOrdem;
        }

        public CounterchargeDispute() { }

        public void SetContestValue(decimal? valorCOntestado)
         => ValorContestado = valorCOntestado;

        public void SetCycle(DateTime referenciaCicloFaturamento)
        {
            ReferenciaCicloFaturamento = referenciaCicloFaturamento;
            Ciclo = referenciaCicloFaturamento.ToString("MM");
        }

        public TransactionType GetTransaction()
        {
            return TipoTransacao.ToUpper() switch
            {
                "PAYMENT" => TransactionType.Payment,
                "BILLING" => TransactionType.Billing,
                "ADJUSTMENT" => TransactionType.Adjustment,
                "ADJUST REVERSAL" => TransactionType.AdjustReversal,
                _ => throw new NotSupportedException()
            };
        }

        public DisputeType GetDisputeType()
        {
            return TipoDisputa.ToUpper() switch
            {
                "FUTURE ACCOUNT" => DisputeType.FutureAccount,
                "RECTIFIED BOLETO" => DisputeType.RectifiedBoleto,
                _ => throw new NotSupportedException()
            };
        }

        public PaymentStatusType GetPaymentStatus()
        {        
            return StatusPagamento.ToUpper() switch
            {
                "A VENCER" => PaymentStatusType.Avencer,
                "VENCIDO" => PaymentStatusType.Vencido,
                "PAGO" => PaymentStatusType.Pago,
                _ => throw new NotSupportedException()
            };
        }
    }
}
