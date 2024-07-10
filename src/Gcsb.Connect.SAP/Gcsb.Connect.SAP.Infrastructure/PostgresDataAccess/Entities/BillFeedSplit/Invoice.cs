using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit
{
    public class Invoice
    {
        [Key]
        public string InvoiceNumber { get; private set; }

        public Guid IdFile { get; set; }

        public string Marketplace { get; private set; }

        public string ResellerName { get; private set; }

        public string ResellerContactName { get; private set; }

        public string ResellerEmailAddress { get; private set; }

        public string ResellerPhoneNumber { get; private set; }

        public string OrderId { get; private set; }

        public DateTime? BillFrom { get; private set; }

        public DateTime? BillTo { get; private set; }

        public DateTime? InvoiceCreationDate { get; private set; }

        public string StoreCode { get; private set; }

        public string MarketplaceCity { get; private set; }

        public string MarketplaceState { get; private set; }

        public string Premeditateddefaulter { get; private set; }

        public string CustomerTransactionCurrency { get; private set; }

        public string PaymentMethod { get; private set; }

        public string PaymentStatus { get; private set; }

        public string RefundType { get; private set; }

        public string RefundAmount { get; private set; }

        public string InvoiceStatus { get; private set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("IdFile")]
        public virtual File File { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual List<ServiceInvoice> Services { get; set; }

        public virtual List<PaymentCreditCard> PaymentFeedsCredit { get; set; }

        public virtual List<PaymentBoleto> PaymentFeedsBoleto { get; set; }

        [MaxLength(10)]
        public string CompanyCode { get; set; }

        [MaxLength(10)]
        public string AffiliateCode { get; set; }

        [MaxLength(10)]
        public string CityServiceCode { get; set; }

        [MaxLength(150)]
        public string CityHallServiceDescription { get; set; }

        [MaxLength(150)]
        public string SpecialProcedureNumber { get; set; }

        public decimal? TotalInvoicePrice { get; set; }

        public string MunicipalTaxpayerRegistration { get; set; }

        public DateTime? CycleCode { get; set; }

        public string StoreAcronym { get; set; }

    }
}
