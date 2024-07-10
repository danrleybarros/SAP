using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FinancialAccount.GetById
{
    public sealed class FinancialAccountGebyIdResponse
    {      
        public Guid Id { get; set; }        
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
        public string ContaContabilIMPCRED { get; set; }
        public string ContaContabilIMPDEB { get; set; }
        public string CompensacaoAJU { get; set; }
        public string ContaFuturaAJUDeb { get; set; }
        public string ContaFuturaAJUCred { get; set; }
        public string ContaContabilAjusteCompetenciaDeb { get; set; }
        public string ContaContabilAjusteCompetenciaCred { get; set; }
        public string ContaContabilEstimativaCicloDeb { get; set; }
        public string ContaContabilEstimativaCicloCred { get; set; }
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

        //public string ContaFaturaEstornoContestacao { get; set; }
        //public string ContaContabilESTCredFuturoValorNUTILDeb { get; set; }
        //public string ContaContabilESTCredFuturoValorNUTILCred { get; set; }
        //public string ContaContabilESTCredFuturoValorUTILDeb { get; set; }
        //public string ContaContabilESTCredFuturoValorUTILCred { get; set; }
        //public string EstBoletoRetificadoDeb { get; set; }
        //public string EstBoletoRetificadoCred { get; set; }
        //public string ContaFaturaDebitoConcedido { get; set; }
        //public string ContaContabilDebitoConcedidoDeb { get; set; }
        //public string ContaContabilDebitoConcedidoCred { get; set; }



        public FinancialAccountGebyIdResponse(Guid id, string serviceCode, string serviceName, string faturamentoFAT, string faturamentoAJU,
            string descontoFAT, string contaContabilFATCred, string contaContabilFATDeb, string contaContabilContestacaoCred,
            string contaContabilContestacaoDeb, string boletoRetificadoDeb, string boletoRetificadoCred, string contaContabilIMPCred, string contaContabilIMPDeb, string compensacaoAJU,
            string contaFuturaAJUDeb, string contaFuturaAJUCred, string contaContabilAjusteCompetenciaDeb, string contaContabilAjusteCompetenciaCred, string contaContabilEstimativaCicloDeb,
            string contaContabilEstimativaCicloCred, string multaQuebraContFAT, string contaContabilMultaContDeb, string contaContabilMultaContCred, string contaContabilMultaContPagaDeb,
            string contaContabilMultaContPagaCred, string contaContabilMultaContNpagaDeb, string contaContabilMultaContNpagaCred, string contaContabilMultaEstimativaCicloDeb,
            string contaContabilMultaEstimativaCicloCred,
            string contaFaturaEstornoContestacao, string contaContabilESTCredFuturoValorNUTILDeb, string contaContabilESTCredFuturoValorNUTILCred, string contaContabilESTCredFuturoValorUTILDeb,
            string contaContabilESTCredFuturoValorUTILCred, string estBoletoRetificadoDeb, string estBoletoRetificadoCred, string contaFaturaDebitoConcedido, string contaContabilDebitoConcedidoDeb,
            string contaContabilDebitoConcedidoCred, string contaContabilProdutoNaoEmitidoPagoDeb, string contaContabilProdutoNaoEmitidoPagoCred, string contaContabilProdutoNaoEmitidoNaoPagoDeb, string contaContabilProdutoNaoEmitidoNaoPagoCred, string contaContabilRecReceitaDeb, string contaContabilRecReceitaCred)
        {
            Id = id;
            ServiceCode = serviceCode;
            ServiceName = serviceName;
            FaturamentoFAT = faturamentoFAT;
            FaturamentoAJU = faturamentoAJU;
            DescontoFAT = descontoFAT;
            ContaContabilFATCred = contaContabilFATCred;
            ContaContabilFATDeb = contaContabilFATDeb;
            ContaContabilContestacaoCred = contaContabilContestacaoCred;
            ContaContabilContestacaoDeb = contaContabilContestacaoDeb;
            BoletoRetificadoDeb = boletoRetificadoDeb;
            BoletoRetificadoCred = boletoRetificadoCred;
            ContaContabilIMPCRED = contaContabilIMPCred;
            ContaContabilIMPDEB = contaContabilIMPDeb;
            CompensacaoAJU = compensacaoAJU;
            ContaFuturaAJUDeb = contaFuturaAJUDeb;
            ContaFuturaAJUCred = contaFuturaAJUCred;
            ContaContabilAjusteCompetenciaDeb = contaContabilAjusteCompetenciaDeb;
            ContaContabilAjusteCompetenciaCred = contaContabilAjusteCompetenciaCred;
            ContaContabilEstimativaCicloDeb = contaContabilEstimativaCicloDeb;
            ContaContabilEstimativaCicloCred = contaContabilEstimativaCicloCred;
            MultaQuebraContFAT = multaQuebraContFAT;
            ContaContabilMultaContDeb = contaContabilMultaContDeb;
            ContaContabilMultaContCred = contaContabilMultaContCred;
            ContaContabilMultaContPagaDeb = contaContabilMultaContPagaDeb;
            ContaContabilMultaContPagaCred = contaContabilMultaContPagaCred;
            ContaContabilMultaContNpagaDeb = contaContabilMultaContNpagaDeb;
            ContaContabilMultaContNpagaCred = contaContabilMultaContNpagaCred;
            ContaContabilMultaEstimativaCicloDeb = contaContabilMultaEstimativaCicloDeb;
            ContaContabilMultaEstimativaCicloCred = contaContabilMultaEstimativaCicloCred;
            ContaFaturaEstornoContestacao = contaFaturaEstornoContestacao;
            ContaContabilESTCredFuturoValorNUTILDeb = contaContabilESTCredFuturoValorNUTILDeb;
            ContaContabilESTCredFuturoValorNUTILCred = contaContabilESTCredFuturoValorNUTILCred;
            ContaContabilESTCredFuturoValorUTILDeb = contaContabilESTCredFuturoValorUTILDeb;
            ContaContabilESTCredFuturoValorUTILCred = contaContabilESTCredFuturoValorUTILCred;
            EstBoletoRetificadoDeb = estBoletoRetificadoDeb;
            EstBoletoRetificadoCred = estBoletoRetificadoCred;
            ContaFaturaDebitoConcedido = contaFaturaDebitoConcedido;
            ContaContabilDebitoConcedidoDeb = contaContabilDebitoConcedidoDeb;
            ContaContabilDebitoConcedidoCred = contaContabilDebitoConcedidoCred;
            ContaContabilProdutoNaoEmitidoPagoDeb = contaContabilProdutoNaoEmitidoPagoDeb;
            ContaContabilProdutoNaoEmitidoPagoCred = contaContabilProdutoNaoEmitidoPagoCred;
            ContaContabilProdutoNaoEmitidoNaoPagoDeb = contaContabilProdutoNaoEmitidoNaoPagoDeb;
            ContaContabilProdutoNaoEmitidoNaoPagoCred = contaContabilProdutoNaoEmitidoNaoPagoCred;
            ContaContabilRecReceitaDeb = contaContabilRecReceitaDeb;
            ContaContabilRecReceitaCred = contaContabilRecReceitaCred;
        }
    }

}
