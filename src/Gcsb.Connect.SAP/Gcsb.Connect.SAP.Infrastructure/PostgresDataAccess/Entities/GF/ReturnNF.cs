using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
{
    public class ReturnNF
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid FileId { get; set; }

        [Required]
        [MaxLength(50)]
        public string InvoiceID { get; set; }

        [Required]
        [MaxLength(50)]
        public string NumeroNF { get; set; }

        [Required]
        [MaxLength(50)]
        public string SerieNF { get; set; }

        [Required]
        public DateTime DataEmissaoNF { get; set; }

        [Required]
        public decimal ValorTotalNF { get; set; }

        [Required]
        public decimal ValorTotalDescontoNF { get; set; }

        [Required]
        public string NFCancelada { get; set; }

        [Required]
        public string ChaveNF { get; set; }

        [Required]
        public string StoreAcronym { get; set; }

    }
}
