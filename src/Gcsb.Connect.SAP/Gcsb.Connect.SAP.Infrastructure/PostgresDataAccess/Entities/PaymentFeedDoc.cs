using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
{
    public class PaymentFeedDoc
    {
        [Key]
        public Guid Id { get; set; }

        public Guid IdFile { get; set; }

        public string InvoiceNumberJsdn { get; set; }

        [Range(0.0, Double.MaxValue)]
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Credit Card:
        /// Local time and date payment platform SIA (yyMMddHHmmss)
        /// Boleto:
        /// Invoice Release Date
        /// </summary>
        public string DateTimeSIA { get; set; }

        /// <summary>
        /// Credit card:
        /// Local time and Date of Payment Network or bank(yyMMddHHmmss).
        /// Boleto:
        /// Payment date received on Invoice API
        /// </summary>
        public string DateTimePayment { get; set; }

        /// <summary>
        /// Credit Card:
        /// Date Time transaction
        /// Boleto:
        /// Processing date received in Invoice API
        /// </summary>
        public DateTime? TransactionDate { get; set; }

        /// <summary>
        /// Boleto: Customer Id
        /// </summary>
        [Required]
        [MaxLength(11)]
        public string EntityId { get; set; }

        public virtual Invoice Invoice { get; set; }

        [Required]
        public TypePaymentMethod PaymentMethod { get; set; }

        [Required]
        public DateTime DateProcessing { get; set; }
    }
}
