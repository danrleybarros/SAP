using Gcsb.Connect.Messaging.Messages.File.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.JSDN
{
    public class PaymentBoleto : PaymentFeedDoc
    {
        private const string ciclofaturamento = "01";

        [Required]
        public int Item { get; private set; }

        public int? NSA { get; private set; }

        public string CicloFaturamento { get => ciclofaturamento; }

        [Required]
        [StringLength(2, MinimumLength =2)]
        public string UF { get; private set; }

        [Required]
        [Range(1,999)]
        public int CodigoBanco { get; private set; }

        [MaxLength(20)]
        public string NomeBanco { get; private set; }

        [MaxLength(20)]
        public string CodigoConvenio { get; private set; }

        [Required]
        public DateTime DataVencimento { get; private set; }

        [Required]
        [StringLength(48, MinimumLength = 48)]
        public string CodigoBarras { get; private set; }

        [Range(0.0, Double.MaxValue)]
        public decimal ValorRecebido { get; private set; }

        public PaymentBoleto(Guid IdFile, string entityId, decimal? transactionAmount, string dateTimeSIA, string dateTimePayment, DateTime? transactionDate, string invoiceNumberJsdn,
                int item, int? nsa, string uf, int codigoBanco, string nomeBanco, string codigoConvenio, DateTime dataVencimento, string codigoBarras, decimal valorRecebido, DateTime dateProcessing
            )
            : base(Guid.NewGuid(), IdFile, invoiceNumberJsdn, transactionAmount, dateTimeSIA, dateTimePayment, transactionDate, entityId, TypePaymentMethod.Boleto,dateProcessing)
        {
            this.Item = item;
            this.NSA = nsa;
            this.UF = uf;
            this.CodigoBanco = codigoBanco;
            this.NomeBanco = nomeBanco;
            this.CodigoConvenio = codigoConvenio;
            this.DataVencimento = dataVencimento;
            this.CodigoBarras = codigoBarras;
            this.ValorRecebido = valorRecebido;
        }
    }
}
