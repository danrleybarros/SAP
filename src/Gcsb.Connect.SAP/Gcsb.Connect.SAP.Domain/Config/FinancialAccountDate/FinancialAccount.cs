using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.Config.FinancialAccountDate
{
    public class FinancialAccount
    {
        private readonly Guid guid;
        private readonly DateTime utcNow;
        private readonly bool v;

        public Guid Id { get; private set; }
        public Guid IdFinancialAccount { get; set; }

        [Required]
        [MaxLength(15)]
        public string ServiceCode { get; private set; }

        [Required]
        [MaxLength(50)]
        public string ServiceName { get; private set; }

        [Required]
        [MaxLength(15)]
        public string FaturamentoFAT { get; private set; }

        [Required]
        [MaxLength(15)]
        public string FaturamentoAJU { get; private set; }

        [Required]
        [MaxLength(15)]
        public string DescontoFAT { get; private set; }

        public DateTime? DateIncluded { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public bool IsDeleted { get; set; }

        public string ContaContabilFATCred { get; private set; }

        public string ContaContabilFATDeb { get; private set; }

        public string ContaContabilContestacaoCred { get; private set; }

        public string ContaContabilContestacaoDeb { get; private set; }

        public string BoletoRetificadoDeb { get; private set; }

        public string BoletoRetificadoCred { get; private set; }

        public string ContaContabilIMPDEB { get; private set; }

        public string ContaContabilIMPCRED { get; private set; }

        public string CompensacaoAJU { get; set; }

        public string ContaFuturaAJUDeb { get; set; }

        public string ContaFuturaAJUCred { get; set; }

        [Required]
        [MaxLength(8)]
        public string ContaContabilAjusteCompetenciaDeb { get; private set; }

        [Required]
        [MaxLength(8)]
        public string ContaContabilAjusteCompetenciaCred { get; private set; }

        [Required]
        [MaxLength(8)]
        public string ContaContabilEstimativaCicloDeb { get; private set; }

        [Required]
        [MaxLength(8)]
        public string ContaContabilEstimativaCicloCred { get; private set; }

        [Required]
        public StoreType StoreType { get; private set; }

        [MaxLength(15)]
        public string MultaQuebraContFAT { get; private set; }

        [MaxLength(8)]
        public string ContaContabilMultaContDeb { get; private set; }

        [MaxLength(8)]
        public string ContaContabilMultaContCred { get; private set; }

        [MaxLength(8)]
        public string ContaContabilMultaContPagaDeb { get; private set; }

        [MaxLength(8)]
        public string ContaContabilMultaContPagaCred { get; private set; }

        [MaxLength(8)]
        public string ContaContabilMultaContNpagaDeb { get; private set; }

        [MaxLength(8)]
        public string ContaContabilMultaContNpagaCred { get; private set; }

        [MaxLength(8)]
        public string ContaContabilMultaEstimativaCicloDeb { get; private set; }

        [MaxLength(8)]
        public string ContaContabilMultaEstimativaCicloCred { get; private set; }

        [MaxLength(15)]
        public string ContaFaturaEstornoContestacao { get; private set; }

        [MaxLength(8)]
        public string ContaContabilESTCredFuturoValorNUTILDeb { get; private set; }

        [MaxLength(8)]
        public string ContaContabilESTCredFuturoValorNUTILCred { get; private set; }

        [MaxLength(8)]
        public string ContaContabilESTCredFuturoValorUTILDeb { get; private set; }

        [MaxLength(8)]
        public string ContaContabilESTCredFuturoValorUTILCred { get; private set; }

        [MaxLength(8)]
        public string EstBoletoRetificadoDeb { get; private set; }

        [MaxLength(8)]
        public string EstBoletoRetificadoCred { get; private set; }

        [MaxLength(15)]
        public string ContaFaturaDebitoConcedido { get; private set; }

        [MaxLength(8)]
        public string ContaContabilDebitoConcedidoDeb { get; private set; }
        public string ContaContabilProdutoNaoEmitidoPagoDeb { get; private set; }

        [MaxLength(8)]
        public string ContaContabilDebitoConcedidoCred { get; private set; }
        public string ContaContabilProdutoNaoEmitidoPagoCred { get; private set; }

        public string ContaContabilProdutoNaoEmitidoNaoPagoDeb { get; private set; }

        public string ContaContabilProdutoNaoEmitidoNaoPagoCred { get; private set; }

        public string ContaContabilRecReceitaDeb { get; private set; }

        public string ContaContabilRecReceitaCred { get; private set; }

        public FinancialAccount(
            Guid id, string serviceCode, string serviceName,
            string faturamentoFAT,
            string faturamentoAJU,
            string descontoFAT,
            string contaContabilFATCred,
            string contaContabilFATDeb,
            string contaContabilContestacaoCred,
            string contaContabilContestacaoDeb,
            string boletoRetificadoDeb,
            string boletoRetificadoCred,
            string contaContabilIMPDEB,
            string contaContabilIMPCRED,
            string compensacaoAJU,
            string contaFuturaAJUDeb,
            string contaFuturaAJUCred,
            string contaContabilAjusteCompetenciaDeb,
            string contaContabilAjusteCompetenciaCred,
            string contaContabilEstimativaCicloDeb,
            string contaContabilEstimativaCicloCred,
            string multaQuebraContFAT,
            string contaContabilMultaContDeb,
            string contaContabilMultaContCred,
            string contaContabilMultaContPagaDeb,
            string contaContabilMultaContPagaCred,
            string contaContabilMultaContNpagaDeb,
            string contaContabilMultaContNpagaCred,
            string contaContabilMultaEstimativaCicloDeb,
            string contaContabilMultaEstimativaCicloCred,
            string contaFaturaEstornoContestacao,
            string contaContabilESTCredFuturoValorNUTILDeb,
            string contaContabilESTCredFuturoValorNUTILCred,
            string contaContabilESTCredFuturoValorUTILDeb,
            string contaContabilESTCredFuturoValorUTILCred,
            string estBoletoRetificadoDeb,
            string estBoletoRetificadoCred,
            string contaFaturaDebitoConcedido,
            string contaContabilDebitoConcedidoDeb,
            string contaContabilDebitoConcedidoCred,
            string contaContabilProdutoNaoEmitidoPagoDeb,
            string contaContabilProdutoNaoEmitidoPagoCred,
            string contaContabilProdutoNaoEmitidoNaoPagoDeb,
            string contaContabilProdutoNaoEmitidoNaoPagoCred,
            string contaContabilRecReceitaDeb,
            string contaContabilRecReceitaCred,
            DateTime? dateIncluded, DateTime lastUpdateDate, bool isDeleted,
            StoreType storeType)
        {
            Id = id;
            ServiceCode = serviceCode;
            ServiceName = serviceName;
            FaturamentoFAT = faturamentoFAT;
            FaturamentoAJU = faturamentoAJU;
            DescontoFAT = descontoFAT;
            DateIncluded = dateIncluded;
            LastUpdateDate = lastUpdateDate;
            IsDeleted = isDeleted;
            StoreType = storeType;
            this.ContaContabilFATCred = contaContabilFATCred;
            this.ContaContabilFATDeb = contaContabilFATDeb;
            this.ContaContabilContestacaoCred = contaContabilContestacaoCred;
            this.ContaContabilContestacaoDeb = contaContabilContestacaoDeb;
            this.BoletoRetificadoDeb = boletoRetificadoDeb;
            this.BoletoRetificadoCred = boletoRetificadoCred;
            this.ContaContabilIMPDEB = contaContabilIMPDEB;
            this.ContaContabilIMPCRED = contaContabilIMPCRED;
            this.CompensacaoAJU = compensacaoAJU;
            this.ContaFuturaAJUDeb = contaFuturaAJUDeb;
            this.ContaFuturaAJUCred = contaFuturaAJUCred;
            this.ContaContabilAjusteCompetenciaDeb = contaContabilAjusteCompetenciaDeb;
            this.ContaContabilAjusteCompetenciaCred = contaContabilAjusteCompetenciaCred;
            this.ContaContabilEstimativaCicloDeb = contaContabilEstimativaCicloDeb;
            this.ContaContabilEstimativaCicloCred = contaContabilEstimativaCicloCred;
            this.MultaQuebraContFAT = multaQuebraContFAT;
            this.ContaContabilMultaContDeb = contaContabilMultaContDeb;
            this.ContaContabilMultaContCred = contaContabilMultaContCred;
            this.ContaContabilMultaContPagaDeb = contaContabilMultaContPagaDeb;
            this.ContaContabilMultaContPagaCred = contaContabilMultaContPagaCred;
            this.ContaContabilMultaContNpagaDeb = contaContabilMultaContNpagaDeb;
            this.ContaContabilMultaContNpagaCred = contaContabilMultaContNpagaCred;
            this.ContaContabilMultaEstimativaCicloDeb = contaContabilMultaEstimativaCicloDeb;
            this.ContaContabilMultaEstimativaCicloCred = contaContabilMultaEstimativaCicloCred;
            this.ContaFaturaEstornoContestacao = contaFaturaEstornoContestacao;
            this.ContaContabilESTCredFuturoValorNUTILDeb = contaContabilESTCredFuturoValorNUTILDeb;
            this.ContaContabilESTCredFuturoValorNUTILCred = contaContabilESTCredFuturoValorNUTILCred;
            this.ContaContabilESTCredFuturoValorUTILDeb = contaContabilESTCredFuturoValorUTILDeb;
            this.ContaContabilESTCredFuturoValorUTILCred = contaContabilESTCredFuturoValorUTILCred;
            this.EstBoletoRetificadoDeb = estBoletoRetificadoDeb;
            this.EstBoletoRetificadoCred = estBoletoRetificadoCred;
            this.ContaFaturaDebitoConcedido = contaFaturaDebitoConcedido;
            this.ContaContabilDebitoConcedidoDeb = contaContabilDebitoConcedidoDeb;
            this.ContaContabilDebitoConcedidoCred = contaContabilDebitoConcedidoCred;
            this.ContaContabilProdutoNaoEmitidoPagoDeb = contaContabilProdutoNaoEmitidoPagoDeb;
            this.ContaContabilProdutoNaoEmitidoPagoCred = contaContabilProdutoNaoEmitidoPagoCred;
            this.ContaContabilProdutoNaoEmitidoNaoPagoDeb = contaContabilProdutoNaoEmitidoNaoPagoDeb;
            this.ContaContabilProdutoNaoEmitidoNaoPagoCred = contaContabilProdutoNaoEmitidoNaoPagoCred;
            this.ContaContabilRecReceitaDeb = contaContabilRecReceitaDeb;
            this.ContaContabilRecReceitaCred = contaContabilRecReceitaCred;
        }

        public FinancialAccount(Guid guid, string serviceCode, string serviceName, string faturamentoFAT, string faturamentoAJU, string descontoFAT, string contaContabilFATCred,
            string contaContabilFATDeb, string contaContabilContestacaoCred, string contaContabilContestacaoDeb, string boletoRetificadoDeb, string boletoRetificadoCred,
            string contaContabilIMPDEB, string contaContabilIMPCRED, string compensacaoAJU, string contaFuturaAJUDeb, string contaFuturaAJUCred, string contaContabilAjusteCompetenciaDeb,
            string contaContabilAjusteCompetenciaCred, string contaContabilEstimativaCicloDeb, string contaContabilEstimativaCicloCred,
            string multaQuebraContFAT, string contaContabilMultaContDeb,
            string contaContabilMultaContCred, string contaContabilMultaContPagaDeb, string contaContabilMultaContPagaCred, string contaContabilMultaContNpagaDeb,
            string contaContabilMultaContNpagaCred, string contaContabilMultaEstimativaCicloDeb, string contaContabilMultaEstimativaCicloCred,
            string contaFaturaEstornoContestacao, string contaContabilESTCredFuturoValorNUTILDeb, string contaContabilESTCredFuturoValorNUTILCred, string contaContabilESTCredFuturoValorUTILDeb,
            string contaContabilESTCredFuturoValorUTILCred, string estBoletoRetificadoDeb, string estBoletoRetificadoCred, string contaFaturaDebitoConcedido, string contaContabilDebitoConcedidoDeb,
            string contaContabilDebitoConcedidoCred,
            DateTime utcNow, bool v)
        {
            this.guid = guid;
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
            ContaContabilIMPDEB = contaContabilIMPDEB;
            ContaContabilIMPCRED = contaContabilIMPCRED;
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
            this.utcNow = utcNow;
            this.v = v;
        }
    }
}
