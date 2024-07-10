using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
{
    public class PaymentBoleto : PaymentFeedDoc
    {
        [Required]
        public int Item { get; set; }

        public int? NSA { get; set; }

        [Required]
        public string CicloFaturamento { get; set; }

        [Required]
        public string UF { get; set; }

        [Required]
        public int CodigoBanco { get; set; }

        public string NomeBanco { get; set; }

        public string CodigoConvenio { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        [Required]
        public string CodigoBarras { get; set; }

        [Required]
        public decimal ValorRecebido { get; set; }
    }
}
