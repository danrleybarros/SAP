using Gcsb.Connect.Messaging.Messages.File.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.JSDN
{
    /// <summary>
    /// This file contains the properties from PaymentFeed
    /// </summary>
    public class PaymentFeedDoc : IDoc
    {
        public Guid Id { get; private set; }

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

        [Required]
        public TypePaymentMethod PaymentMethod { get; private set; }
        
        public DateTime DateProcessing { get; private set; }


        protected PaymentFeedDoc()
        {

        }

        public PaymentFeedDoc(Guid id, Guid idFile, string invoiceNumberJsdn, decimal? transactionAmount, string dateTimeSIA, string dateTimePayment, DateTime? transactionDate, string entityId, TypePaymentMethod paymentMethod, DateTime dateProcessing)
        {
            this.Id = id;
            this.IdFile = idFile;
            this.InvoiceNumberJsdn = invoiceNumberJsdn;
            this.TransactionAmount = transactionAmount;
            this.DateTimeSIA = dateTimeSIA;
            this.DateTimePayment = dateTimePayment;
            this.TransactionDate = transactionDate;
            this.EntityId = entityId;
            this.PaymentMethod = paymentMethod;
            this.DateProcessing = dateProcessing;
        }
    }
}
