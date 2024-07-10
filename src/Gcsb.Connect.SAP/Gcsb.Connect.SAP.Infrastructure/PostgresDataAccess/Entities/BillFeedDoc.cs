using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
{
    public class BillFeedDoc
    {
        public Guid Id { get; private set; }
        public Guid IdFile { get; set; }

        public Guid Sequence { get; private set; }

        public string Marketplace { get; private set; }

        public string ResellerName { get; private set; }

        public string ResellerContactName { get; private set; }

        public string ResellerEmailAddress { get; private set; }

        public string ResellerPhoneNumber { get; private set; }

        public string OrderId { get; private set; }

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

        public DateTime? BillFrom { get; private set; }

        public DateTime? BillTo { get; private set; }

        public string CompanyName { get; private set; }

        public string CustomerCode { get; private set; }

        public DateTime? AccountCreationDate { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string CustomerEmailAddress { get; private set; }

        public string CustomerPhoneNumber { get; private set; }

        public string BillingStreet { get; private set; }

        public string BillingNumber { get; private set; }

        public string BillingComplement { get; private set; }

        public string BillingNeighbourhood { get; private set; }

        public string BillingCity { get; private set; }

        public string BillingStateOrProvince { get; private set; }

        public string BillingZIPcode { get; private set; }

        public string BillingCountry { get; private set; }

        public string BillingCountryCode { get; private set; }

        public string BillingPhoneNumber { get; private set; }

        public string MailingStreet { get; private set; }

        public string MailingNumber { get; private set; }

        public string MailingComplement { get; private set; }

        public string MailingNeighbourhood { get; private set; }

        public string MailingCity { get; private set; }

        public string MailingStateOrProvince { get; private set; }

        public string MailingZIPcode { get; private set; }

        public string MailingCountry { get; private set; }

        public string MailingCountryCode { get; private set; }

        public string MailingPhoneNumber { get; private set; }

        public string CustomerCPF { get; private set; }

        public string CustomerCNPJ { get; private set; }

        public string CustomerStateRegistration { get; private set; }

        public DateTime? InvoiceCreationDate { get; private set; }

        public string ServiceCode { get; private set; }

        public DateTime? DueDate { get; private set; }

        public string StoreCode { get; private set; }

        public string MarketplaceCity { get; private set; }

        public string MarketplaceState { get; private set; }

        public string UserAccountStatus { get; private set; }

        public string Premeditateddefaulter { get; private set; }

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

        public string CustomerTransactionCurrency { get; private set; }

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

        public string PaymentMethod { get; private set; }

        public string PaymentStatus { get; private set; }

        public string RefundType { get; private set; }

        public string RefundAmount { get; private set; }

        public string InvoiceNumber { get; private set; }

        public string ResourceId { get; private set; }

        public string ChargeType { get; private set; }

        public string InvoiceStatus { get; private set; }

        [MaxLength(1)]
        public string IndividualInvoice { get; set; }

        [MaxLength(20)]
        public string MunicipalTaxpayerRegistration { get; set; }

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

        public decimal? TaxRateISS { get; set; }

        public decimal? TotalTaxISS { get; set; }

        public decimal? TaxRateCOFINS { get; set; }

        public decimal? TotalTaxCOFINS { get; set; }

        public decimal? TaxRatePIS { get; set; }

        public decimal? TotalTaxPIS { get; set; }

        public decimal? TotalInvoicePrice { get; set; }

        public string CnpjMarketPlace { get; set; }

        public string CompanyNameMarketPlace { get; set; }

        public string CustomerAcronym { get; set; }

        public string Segment { get; set; }

        public DateTime? CycleCode { get; set; }

        public DateTime? CycleReference { get; set; }

        public string FinancialStatus { get; set; }

        public string CommentsCredited { get; set; }

        public string Receivable { get; set; }

        public string CpfUserHasMadeCredit { get; set; }

        public string ProposalNumber { get; set; }

        public string AdabasCode { get; set; }

        public string OpportunityId { get; set; }

        public string QuoteId { get; set; }

        public string StoreAcronym { get; set; }

        public double? TotalRetailPriceWithTaxesWithoutDiscount { get; set; }

        public string ServiceProviderCompanyName { get; private set; }

        public string CNPJServiceProviderCompany { get; private set; }

        public string StoreAcronymServiceProvider { get; private set; }
    }
}
