using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
{
    public class FinancialAccountDate
    {
        [Key]
        public Guid Id { get; set; }

        public Guid IdFinancialAccount { get; set; }

        [Required]
        [MaxLength(100)]
        public string ServiceCode { get; set; }

        [Required]
        [MaxLength(200)]
        public string ServiceName { get; set; }

        [Required]
        [MaxLength(15)]
        public string FaturamentoFAT { get; set; }

        [Required]
        [MaxLength(15)]
        public string FaturamentoAJU { get; set; }

        [Required]
        [MaxLength(15)]
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

        [Required]
        [MaxLength(8)]
        public string ContaContabilAjusteCompetenciaDeb { get; set; }

        [Required]
        [MaxLength(8)]
        public string ContaContabilAjusteCompetenciaCred { get; set; }

        [Required]
        [MaxLength(8)]
        public string ContaContabilEstimativaCicloDeb { get; set; }

        [Required]
        [MaxLength(8)]
        public string ContaContabilEstimativaCicloCred { get; set; }

        [MaxLength(15)]
        public string MultaQuebraContFAT { get; set; }
        [MaxLength(8)]
        public string ContaContabilMultaContDeb { get; set; }

        [MaxLength(8)]
        public string ContaContabilMultaContCred { get; set; }

        [MaxLength(8)]
        public string ContaContabilMultaContPagaDeb { get; set; }

        [MaxLength(8)]
        public string ContaContabilMultaContPagaCred { get; set; }

        [MaxLength(8)]
        public string ContaContabilMultaContNpagaDeb { get; set; }

        [MaxLength(8)]
        public string ContaContabilMultaContNpagaCred { get; set; }

        [MaxLength(8)]
        public string ContaContabilMultaEstimativaCicloDeb { get; set; }

        [MaxLength(8)]
        public string ContaContabilMultaEstimativaCicloCred { get; set; }


        public string ContaFaturaEstornoContestacao { get; set; }

        [MaxLength(8)]
        public string ContaContabilESTCredFuturoValorNUTILDeb { get; set; }

        [MaxLength(8)]
        public string ContaContabilESTCredFuturoValorNUTILCred { get; set; }

        [MaxLength(8)]
        public string ContaContabilESTCredFuturoValorUTILDeb { get; set; }

        [MaxLength(8)]
        public string ContaContabilESTCredFuturoValorUTILCred { get; set; }

        [MaxLength(8)]
        public string EstBoletoRetificadoDeb { get; set; }

        [MaxLength(8)]
        public string EstBoletoRetificadoCred { get; set; }

        public string ContaFaturaDebitoConcedido { get; set; }

        [MaxLength(8)]
        public string ContaContabilDebitoConcedidoDeb { get; set; }

        [MaxLength(8)]
        public string ContaContabilDebitoConcedidoCred { get; set; }

        public string ContaContabilProdutoNaoEmitidoPagoDeb { get; set; }

        public string ContaContabilProdutoNaoEmitidoPagoCred { get; set; }

        public string ContaContabilProdutoNaoEmitidoNaoPagoDeb { get; set; }

        public string ContaContabilProdutoNaoEmitidoNaoPagoCred { get; set; }

        public string ContaContabilRecReceitaDeb { get; set; }

        public string ContaContabilRecReceitaCred { get; set; }

        public DateTime DateIncluded { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public StoreType StoreType { get; set; }
    }
}
