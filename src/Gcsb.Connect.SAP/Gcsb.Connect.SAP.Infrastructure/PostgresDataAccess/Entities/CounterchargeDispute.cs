using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
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
        public string TipoAtividade { get; private set; }
        public bool CicloNulo { get; private set; }

    }
}
