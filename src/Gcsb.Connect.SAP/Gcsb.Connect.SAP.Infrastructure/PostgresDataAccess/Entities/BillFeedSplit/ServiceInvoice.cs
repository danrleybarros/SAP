using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities.BillFeedSplit
{
    public class ServiceInvoice
    {
        [Key]
        public Guid Id { get; private set; }

        public string InvoiceNumber { get; private set; }

        public Guid Sequence { get; private set; }

        public Guid SubscriptionId { get; private set; }

        public string Activity { get; private set; }

        public string ServiceType { get; private set; }

        public DateTime? OrderCreationDate { get; private set; }

        public DateTime? PurchaseDate { get; private set; }

        public DateTime? ActivationDate { get; private set; }

        public string SubscriptionType { get; private set; }

        public DateTime? TermStartDate { get; private set; }

        public DateTime? TermEndDate { get; private set; }
        
        public string TermDuration { get; private set; }

        public DateTime? NextRenewalDate { get; private set; }

        public string ServiceCancellationDate { get; private set; }

        public string ServiceCode { get; private set; }

        public DateTime? DueDate { get; private set; }

        public string ServiceName { get; private set; }

        public string OfferName { get; private set; }

        public string OfferCode { get; private set; }

        public string SalesReferenceCode { get; private set; }

        public string UnitOfMeasure { get; private set; }

        public double? Qty { get; private set; }

        public double? ProRateScale { get; private set; }

        public double? RetailUnitPrice { get; private set; }

        public double? ProRatedRetailPriceUnitPrice { get; private set; }

        public decimal? GrossRetailPrice { get; private set; }

        public double? RetailPriceDiscount { get; private set; }

        public double? ProRatedRetailUnitDiscountedPriceAmount { get; private set; }

        public decimal? TotalRetailPriceDiscountAmount { get; private set; }

        public double? TotalRetailPrice { get; private set; }

        public double? TaxOnTotalRetailPrice { get; private set; }

        public double? GrandTotalRetailPrice { get; private set; }

        public string PromotionCode { get; private set; }

        public string PromotionDuration { get; private set; }

        public double? WholesaleUnitPrice { get; private set; }

        public double? ProRatedWholesaleUnitPrice { get; private set; }

        public string VendorCurrency { get; private set; }

        public double? GrossWholesalePrice { get; private set; }

        public double? WholesalePriceDiscount { get; private set; }

        public double? ProRatedWholesaleUnitDiscountedPriceAmount { get; private set; }

        public double? TotalWholesalePriceDiscountAmount { get; private set; }

        public double? TotalWholesalePrice { get; private set; }

        public double? TaxOnTotalWholesalePrice { get; private set; }

        public double? GrandTotalWholesalePrice { get; private set; }

        public string VendorName { get; private set; }

        public double? VendorUnitPrice { get; private set; }

        public double? ProRatedVendorUnitPrice { get; private set; }

        public double? TotalVendorPrice { get; private set; }

        public double? TaxOnTotalVendorPrice { get; private set; }

        public double? GrandTotalVendorPrice { get; private set; }

        public string BillingCycle { get; private set; }

        public string ProrateType { get; private set; }

        public string ProrateOnCancellation { get; private set; }

        public string UsageAttributes { get; private set; }

        public string ResourceId { get; private set; }

        public string ChargeType { get; private set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("InvoiceNumber")]
        public virtual Invoice Invoice { get; set; }
        
        [MaxLength(4)]
        public string AcquirerEntity { get; set; }

        [MaxLength(8)]
        public string TransactionDate { get; set; }

        public decimal? TaxRateISS { get; set; }
        
        public decimal? TotalTaxISS { get; set; }

        public decimal? TaxRateCOFINS { get; set; }

        public decimal? TotalTaxCOFINS { get; set; }

        public decimal? TaxRatePIS { get; set; }       

        public decimal? TotalTaxPIS { get; set; }

        public DateTime? CycleReference { get; set; }

        public string FinancialStatus { get; set; }

        public string CommentsCredited { get; set; }

        public string Receivable { get; set; }

        public double? TotalRetailPriceWithTaxesWithoutDiscount { get; set; }

        public string ServiceProviderCompanyName { get; private set; }

        public string CNPJServiceProviderCompany { get; private set; }

        public string StoreAcronymServiceProvider { get; private set; }
    }
}
