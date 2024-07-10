using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config
{
    public class FinancialAccountResult
    {
        public Guid? Id { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string FaturamentoFAT { get; set; }
        public string FaturamentoAJU { get; set; }
        public string DescontoFAT { get; set; }
        public string ContaContabilFATCred { get; set; }
        public string ContaContabilFATDeb { get; set; }
        public string ContaContabilContestacaoCred { get; set; }
        public string ContaContabilContestacaoDeb { get; set; }
        public string BoletoRetificadoDeb { get; set; }
        public string BoletoRetificadoCred { get; set; }
        public string ContaContabilIMPDEB { get; set; }
        public string ContaContabilIMPCRED { get; set; }
        public string CompensacaoAJU { get; set; }
        public string ContaFuturaAJUDeb { get; set; }
        public string ContaFuturaAJUCred { get; set; }
        public string ContaContabilAjusteCompetenciaDeb { get; set; }
        public string ContaContabilAjusteCompetenciaCred { get; set; }
        public string ContaContabilEstimativaCicloDeb { get; set; }
        public string ContaContabilEstimativaCicloCred { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public StoreType StoreType { get; set; }
        public string MultaQuebraContFAT { get; set; }
        public string ContaContabilMultaContDeb { get; set; }
        public string ContaContabilMultaContCred { get; set; }
        public string ContaContabilMultaContPagaDeb { get; set; }
        public string ContaContabilMultaContPagaCred { get; set; }
        public string ContaContabilMultaContNpagaDeb { get; set; }
        public string ContaContabilMultaContNpagaCred { get; set; }
        public string ContaContabilMultaEstimativaCicloDeb { get; set; }
        public string ContaContabilMultaEstimativaCicloCred { get; set; }
        public string ContaFaturaEstornoContestacao { get; set; }
        public string ContaContabilESTCredFuturoValorNUTILDeb { get; set; }
        public string ContaContabilESTCredFuturoValorNUTILCred { get; set; }
        public string ContaContabilESTCredFuturoValorUTILDeb { get; set; }
        public string ContaContabilESTCredFuturoValorUTILCred { get; set; }
        public string EstBoletoRetificadoDeb { get; set; }
        public string EstBoletoRetificadoCred { get; set; }
        public string ContaFaturaDebitoConcedido { get; set; }
        public string ContaContabilDebitoConcedidoDeb { get; set; }
        public string ContaContabilDebitoConcedidoCred { get; set; }
        public string ContaContabilProdutoNaoEmitidoPagoDeb { get; set; }
        public string ContaContabilProdutoNaoEmitidoPagoCred { get; set; }
        public string ContaContabilProdutoNaoEmitidoNaoPagoDeb { get; set; }
        public string ContaContabilProdutoNaoEmitidoNaoPagoCred { get; set; }
        public string ContaContabilRecReceitaDeb { get; set; }
        public string ContaContabilRecReceitaCred { get; set; }


        public FinancialAccountResult()
        { }

        public FinancialAccountResult(Domain.Config.FinancialAccount financialAccount)
        {
            this.Id = financialAccount.Id;
            this.ServiceCode = financialAccount.ServiceCode;
            this.ServiceName = financialAccount.ServiceCodeName;
            this.FaturamentoFAT = financialAccount.FaturamentoFAT;
            this.FaturamentoAJU = financialAccount.FaturamentoAJU;
            this.DescontoFAT = financialAccount.DescontoFAT;
            this.ContaContabilFATCred = financialAccount.ContaContabilFATCred;
            this.ContaContabilFATDeb = financialAccount.ContaContabilFATDeb;
            this.ContaContabilContestacaoCred = financialAccount.ContaContabilContestacaoCred;
            this.ContaContabilContestacaoDeb = financialAccount.ContaContabilContestacaoDeb;
            this.ContaContabilIMPDEB = financialAccount.ContaContabilIMPDEB;
            this.ContaContabilIMPCRED = financialAccount.ContaContabilIMPCRED;
            this.CompensacaoAJU = financialAccount.CompensacaoAJU;
            this.ContaFuturaAJUDeb = financialAccount.ContaFuturaAJUDeb;
            this.ContaFuturaAJUCred = financialAccount.ContaFuturaAJUCred;
            this.BoletoRetificadoDeb = financialAccount.BoletoRetificadoDeb;
            this.BoletoRetificadoCred = financialAccount.BoletoRetificadoCred;
            this.ContaContabilAjusteCompetenciaDeb = financialAccount.ContaContabilAjusteCompetenciaDeb;
            this.ContaContabilAjusteCompetenciaCred = financialAccount.ContaContabilAjusteCompetenciaCred;
            this.ContaContabilEstimativaCicloDeb = financialAccount.ContaContabilEstimativaCicloDeb;
            this.ContaContabilEstimativaCicloCred = financialAccount.ContaContabilEstimativaCicloCred;
            this.StoreType = financialAccount.StoreType;
            this.MultaQuebraContFAT = financialAccount.MultaQuebraContFAT;
            this.ContaContabilMultaContDeb = financialAccount.ContaContabilMultaContDeb;
            this.ContaContabilMultaContCred = financialAccount.ContaContabilMultaContCred;
            this.ContaContabilMultaContPagaDeb = financialAccount.ContaContabilMultaContNpagaDeb;
            this.ContaContabilMultaContPagaCred = financialAccount.ContaContabilMultaContPagaCred;
            this.ContaContabilMultaContNpagaDeb = financialAccount.ContaContabilMultaContNpagaDeb;
            this.ContaContabilMultaContNpagaCred = financialAccount.ContaContabilMultaContNpagaCred;
            this.ContaContabilMultaEstimativaCicloDeb = financialAccount.ContaContabilMultaEstimativaCicloDeb;
            this.ContaContabilMultaEstimativaCicloCred = financialAccount.ContaContabilMultaEstimativaCicloCred;
            this.ContaFaturaEstornoContestacao = financialAccount.ContaFaturaEstornoContestacao;
            this.ContaContabilESTCredFuturoValorNUTILDeb = financialAccount.ContaContabilESTCredFuturoValorNUTILDeb;
            this.ContaContabilESTCredFuturoValorNUTILCred = financialAccount.ContaContabilESTCredFuturoValorNUTILCred;
            this.ContaContabilESTCredFuturoValorUTILDeb = financialAccount.ContaContabilESTCredFuturoValorUTILDeb;
            this.ContaContabilESTCredFuturoValorUTILCred = financialAccount.ContaContabilESTCredFuturoValorUTILCred;
            this.EstBoletoRetificadoDeb = financialAccount.EstBoletoRetificadoDeb;
            this.EstBoletoRetificadoCred = financialAccount.EstBoletoRetificadoCred;
            this.ContaFaturaDebitoConcedido = financialAccount.ContaFaturaDebitoConcedido;
            this.ContaContabilDebitoConcedidoDeb = financialAccount.ContaContabilDebitoConcedidoDeb;
            this.ContaContabilDebitoConcedidoCred = financialAccount.ContaContabilDebitoConcedidoCred;
            this.ContaContabilProdutoNaoEmitidoPagoDeb = financialAccount.ContaContabilProdutoNaoEmitidoPagoDeb;
            this.ContaContabilProdutoNaoEmitidoPagoCred = financialAccount.ContaContabilProdutoNaoEmitidoPagoCred;
            this.ContaContabilProdutoNaoEmitidoNaoPagoDeb = financialAccount.ContaContabilProdutoNaoEmitidoNaoPagoDeb;
            this.ContaContabilProdutoNaoEmitidoNaoPagoCred = financialAccount.ContaContabilProdutoNaoEmitidoNaoPagoCred;
            this.ContaContabilRecReceitaDeb = financialAccount.ContaContabilRecReceitaDeb;
            this.ContaContabilRecReceitaCred = financialAccount.ContaContabilRecReceitaCred;
        }
    }
}
