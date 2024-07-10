using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.JSDN.CounterChargeDispute
{
    public class CounterchargeDisputeBuilder
    {
        public string TipoSubscricao;
        public DateTime DataMovimentacao;
        public string AReceber;
        public string TipoTransacao;
        public string UF;
        public string Ciclo;
        public DateTime ReferenciaCicloFaturamento;
        public string CodigoEmpresa;
        public string FlagTipoFaturamento;
        public decimal ValorTransacao;
        public string NumeroFatura;
        public int CustomerCode;
        public string CodigoFranquia;
        public string CNPJ;
        public string CPF;
        public string NomedaEmpresadoCliente;
        public DateTime DataVencimento;
        public DateTime DataCriacaoFatura;
        public DateTime DataIniciodoCiclo;
        public decimal? SaldoTotalGeral;
        public DateTime DataFimCiclo;
        public DateTime DataCriacaoPedido;
        public char StatusContadoCliente;
        public char InadimplenciaPremeditada;
        public string Produto;
        public string StatusPagamento;
        public string TipoDisputa;
        public DateTime? DataConcessaoCredito;
        public int NumeroPedido;
        public string MotivoCredito;
        public string Nota;
        public string LoginUsuario;
        public DateTime DataCortedoCiclo;
        public string Complemento;
        public decimal? ValorContestado;
        public string CentrodeCusto;
        public string CicloContestado;
        public string LocaldeTrabalho;
        public DateTime? DataEmissaoBoletoRetificado;
        public string CodigoServico;
        public decimal? ValorContestacaoItem;
        public string EnderecoCobranca;
        public string MetodoPagamento;
        public string StoreAcronym;
        public string ProviderCompanyAcronym;
        public string ActivityType;
        public string NumeroOrdem;
        public bool CicloNulo;
        public Domain.Config.FinancialAccount FinancialAccount;
        public Domain.FinancialAccountsClient.FinancialAccount.FinancialAccount FinancialAccountNew;


        public static CounterchargeDisputeBuilder New()
        {
            return new CounterchargeDisputeBuilder
            {
                TipoSubscricao = "IAAS",
                DataMovimentacao = DateTime.UtcNow,
                AReceber = "SPIAASVIVO PLATAFORMA DIGITAL",
                TipoTransacao = "Billing",
                UF = "SP",
                Ciclo = DateTime.UtcNow.Month.ToString(),
                ReferenciaCicloFaturamento = DateTime.UtcNow,
                CodigoEmpresa = "Teste3",
                FlagTipoFaturamento = "Boleto",
                ValorTransacao = 20.0M,
                NumeroFatura = "VVL-1-00024185",
                CustomerCode = 4017028,
                CodigoFranquia = "VIVO PLATAFORMA DIGITAL",
                CNPJ = "06.988.078/0001-42",
                CPF = "16726869703",
                NomedaEmpresadoCliente = "Teste3",
                DataVencimento = DateTime.UtcNow,
                DataCriacaoFatura = DateTime.UtcNow,
                DataIniciodoCiclo = DateTime.UtcNow,
                SaldoTotalGeral = 100,
                DataFimCiclo = DateTime.UtcNow,
                DataCriacaoPedido = DateTime.UtcNow,
                StatusContadoCliente = 'C',
                InadimplenciaPremeditada = 'C',
                Produto = "Office 365 Business Essentials",
                StatusPagamento = null,
                TipoDisputa = "Future Account",
                DataConcessaoCredito = DateTime.UtcNow,
                NumeroPedido = 4014541,
                MotivoCredito = "",
                Nota = "",
                LoginUsuario = "binacop585.youlynx.com",
                DataCortedoCiclo = DateTime.UtcNow,
                Complemento = "",
                ValorContestado = 100,
                CentrodeCusto = "",
                CicloContestado = string.Concat(DateTime.UtcNow.Year.ToString(), "/", DateTime.UtcNow.Month.ToString()),
                LocaldeTrabalho = "9141",
                DataEmissaoBoletoRetificado = DateTime.UtcNow,
                CodigoServico = "Office365F1",
                ValorContestacaoItem = 100,
                EnderecoCobranca = "",
                MetodoPagamento = "",
                StoreAcronym = "telerese",
                ProviderCompanyAcronym = "telerese",
                ActivityType = "interest",
                NumeroOrdem = "4012114",
                CicloNulo = false
            };
        }

        public CounterchargeDisputeBuilder WithTipoSubscricao(string tipoSubscricao)
        {
            TipoSubscricao = tipoSubscricao;
            return this;
        }

        public CounterchargeDisputeBuilder WithDataMovimentacao(DateTime dataMovimentacao)
        {
            DataMovimentacao = dataMovimentacao;
            return this;
        }

        public CounterchargeDisputeBuilder WithAReceber(string aReceber)
        {
            AReceber = aReceber;
            return this;
        }

        public CounterchargeDisputeBuilder WithTipoTransacao(string tipotransacao)
        {
            TipoTransacao = tipotransacao;
            return this;
        }

        public CounterchargeDisputeBuilder WithUF(string uF)
        {
            UF = uF;
            return this;
        }

        public CounterchargeDisputeBuilder WithCiclo(string ciclo)
        {
            Ciclo = ciclo;
            return this;
        }

        public CounterchargeDisputeBuilder WithReferenciaCicloFaturamento(DateTime referenciaCicloFaturamento)
        {
            ReferenciaCicloFaturamento = referenciaCicloFaturamento;
            return this;
        }

        public CounterchargeDisputeBuilder WithCodigoEmpresa(string codigoEmpresa)
        {
            CodigoEmpresa = codigoEmpresa;
            return this;
        }

        public CounterchargeDisputeBuilder WithFlagTipoFaturamento(string flagTipofaturamento)
        {
            FlagTipoFaturamento = flagTipofaturamento;
            return this;
        }

        public CounterchargeDisputeBuilder WithValorTransacao(decimal valorTransacao)
        {
            ValorTransacao = valorTransacao;
            return this;
        }

        public CounterchargeDisputeBuilder WithNumeroFatura(string numeroFatura)
        {
            NumeroFatura = numeroFatura;
            return this;
        }

        public CounterchargeDisputeBuilder WithCustomerCode(int customercode)
        {
            CustomerCode = customercode;
            return this;
        }

        public CounterchargeDisputeBuilder WithCodigoFranquia(string codigoFranquia)
        {
            CodigoFranquia = codigoFranquia;
            return this;
        }

        public CounterchargeDisputeBuilder WithCNPJ(string cNPJ)
        {
            CNPJ = cNPJ;
            return this;
        }

        public CounterchargeDisputeBuilder WithCPF(string cPF)
        {
            CPF = cPF;
            return this;
        }

        public CounterchargeDisputeBuilder WithNomedaEmpresadoCliente(string nomedaEmpresadoCliente)
        {
            NomedaEmpresadoCliente = nomedaEmpresadoCliente;
            return this;
        }

        public CounterchargeDisputeBuilder WithDataVencimento(DateTime dataVencimento)
        {
            DataVencimento = dataVencimento;
            return this;
        }

        public CounterchargeDisputeBuilder WithDataCriacaoFatura(DateTime dataCriacaoFatura)
        {
            DataCriacaoFatura = dataCriacaoFatura;
            return this;
        }

        public CounterchargeDisputeBuilder WithDataIniciodoCiclo(DateTime dataIniciodoCiclo)
        {
            DataIniciodoCiclo = dataIniciodoCiclo;
            return this;
        }

        public CounterchargeDisputeBuilder WithSaldoTotalGeral(decimal? saldoTotalGeral)
        {
            SaldoTotalGeral = saldoTotalGeral;
            return this;
        }

        public CounterchargeDisputeBuilder WithDataFimCiclo(DateTime dataFimCiclo)
        {
            DataFimCiclo = dataFimCiclo;
            return this;
        }

        public CounterchargeDisputeBuilder WithDataCriacaoPedido(DateTime dataCriacaoPedido)
        {
            DataCriacaoPedido = dataCriacaoPedido;
            return this;
        }

        public CounterchargeDisputeBuilder WithStatusContadoCliente(char statusContadoCliente)
        {
            StatusContadoCliente = statusContadoCliente;
            return this;
        }

        public CounterchargeDisputeBuilder WithInadimplenciaPremeditada(char inadimplenciaPremeditada)
        {
            InadimplenciaPremeditada = inadimplenciaPremeditada;
            return this;
        }

        public CounterchargeDisputeBuilder WithProduto(string produto)
        {
            Produto = produto;
            return this;
        }

        public CounterchargeDisputeBuilder WithStatusPagamento(string statusPagamento)
        {
            StatusPagamento = statusPagamento;
            return this;
        }

        public CounterchargeDisputeBuilder WithTipoDisputa(string tipoDisputa)
        {
            TipoDisputa = tipoDisputa;
            return this;
        }

        public CounterchargeDisputeBuilder WithDataConcessaoCredito(DateTime? dataConcessaoCredito)
        {
            DataConcessaoCredito = dataConcessaoCredito;
            return this;
        }

        public CounterchargeDisputeBuilder WithNumeroPedido(int numeroPedido)
        {
            NumeroPedido = numeroPedido;
            return this;
        }

        public CounterchargeDisputeBuilder WithMotivoCredito(string motivoCredito)
        {
            MotivoCredito = motivoCredito;
            return this;
        }

        public CounterchargeDisputeBuilder WithNota(string nota)
        {
            Nota = nota;
            return this;
        }

        public CounterchargeDisputeBuilder WithLoginUsuario(string loginUsuario)
        {
            LoginUsuario = loginUsuario;
            return this;
        }

        public CounterchargeDisputeBuilder WithDataCortedoCiclo(DateTime dataCortedoCiclo)
        {
            DataCortedoCiclo = dataCortedoCiclo;
            return this;
        }

        public CounterchargeDisputeBuilder WithComplemento(string complemento)
        {
            Complemento = complemento;
            return this;
        }

        public CounterchargeDisputeBuilder WithValorContestado(decimal? valorContestado)
        {
            ValorContestado = valorContestado;
            return this;
        }

        public CounterchargeDisputeBuilder WithCentrodeCusto(string centrodecusto)
        {
            CentrodeCusto = centrodecusto;
            return this;
        }

        public CounterchargeDisputeBuilder WithCicloContestado(string ciclocontestado)
        {
            CicloContestado = ciclocontestado;
            return this;
        }

        public CounterchargeDisputeBuilder WithLocaldeTrabalho(string localdeTrabalho)
        {
            LocaldeTrabalho = localdeTrabalho;
            return this;
        }

        public CounterchargeDisputeBuilder WithDataEmissaoBoletoRetificado(DateTime? dataEmissaoBoletoRetificado)
        {
            DataEmissaoBoletoRetificado = dataEmissaoBoletoRetificado;
            return this;
        }

        public CounterchargeDisputeBuilder WithCodigoServico(string codigoServico)
        {
            CodigoServico = codigoServico;
            return this;
        }

        public CounterchargeDisputeBuilder WithValorContestacaoItem(decimal? valorContestacaoItem)
        {
            ValorContestacaoItem = valorContestacaoItem;
            return this;
        }

        public CounterchargeDisputeBuilder WithEnderecoCobranca(string enderecoCobranca)
        {
            EnderecoCobranca = enderecoCobranca;
            return this;
        }

        public CounterchargeDisputeBuilder WithMetodoPagamento(string metodoPagamento)
        {
            MetodoPagamento = metodoPagamento;
            return this;
        }

        public CounterchargeDisputeBuilder WithActivityType(string activityType)
        {
            ActivityType = activityType;
            return this;
        }

        public CounterchargeDisputeBuilder WithStoreAcronym(string storeAcronym)
        {
            StoreAcronym = storeAcronym;
            return this;
        }
        public CounterchargeDisputeBuilder WithProviderCompanyAcronym(string providerCompanyAcronym)
        {
            ProviderCompanyAcronym = providerCompanyAcronym;
            return this;
        }
        
        public CounterchargeDisputeBuilder WithCicloNulo(bool cicloNulo)
        {
            CicloNulo = cicloNulo;
            return this;
        }

        public CounterchargeDisputeBuilder WithFinancialAccount(Domain.Config.FinancialAccount financialAccounts)
        {
            FinancialAccount = financialAccounts;
            return this;
        }

        public CounterchargeDisputeBuilder WithFinancialAccountNew(Domain.FinancialAccountsClient.FinancialAccount.FinancialAccount financialAccountsNew)
        {
            FinancialAccountNew = financialAccountsNew;
            return this;
        }

        public CounterchargeDisputeBuilder WithNumeroOrdem(string numeroOrdem)
        {
            NumeroOrdem = numeroOrdem;
            return this;
        }

        public CounterchargeDispute Build()
        {
            var counterchargeDispute = new CounterchargeDispute(TipoSubscricao, DataMovimentacao, AReceber, TipoTransacao, UF, Ciclo, ReferenciaCicloFaturamento, CodigoEmpresa,
               FlagTipoFaturamento, ValorTransacao, NumeroFatura, CustomerCode, CodigoFranquia, CNPJ, CPF, NomedaEmpresadoCliente, DataVencimento, DataCriacaoFatura,
               DataIniciodoCiclo, SaldoTotalGeral, DataFimCiclo, DataCriacaoPedido, StatusContadoCliente, InadimplenciaPremeditada, Produto, StatusPagamento,
               TipoDisputa, DataConcessaoCredito, NumeroPedido, MotivoCredito, Nota, LoginUsuario, DataCortedoCiclo, Complemento, ValorContestado,
               CentrodeCusto, CicloContestado, LocaldeTrabalho, DataEmissaoBoletoRetificado, CodigoServico, ValorContestacaoItem, EnderecoCobranca,
               MetodoPagamento, StoreAcronym, ProviderCompanyAcronym, ActivityType, NumeroOrdem, CicloNulo);

            counterchargeDispute.FinancialAccount = FinancialAccount;
            counterchargeDispute.FinancialAccountNew = FinancialAccountNew;

            return counterchargeDispute;
        }
    }
}
