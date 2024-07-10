using Gcsb.Connect.SAP.Domain.Attributes;
using System;

namespace Gcsb.Connect.SAP.Infrastructure.CsvConvert
{
    public class BillFeedItem
    {
        [Billfeed("Sequence")]
        public Guid Sequence { get; private set; }

        [Billfeed("Marketplace")]
        public string Marketplace { get; private set; }

        [Billfeed("ResellerName")]
        public string ResellerName { get; private set; }

        [Billfeed("ResellerContactName")]
        public string ResellerContactName { get; private set; }

        [Billfeed("ResellerEmailAddress")]
        public string ResellerEmailAddress { get; private set; }

        [Billfeed("ResellerPhoneNumber")]
        public string ResellerPhoneNumber { get; private set; }

        [Billfeed("OrderId")]
        public string OrderId { get; private set; }

        [Billfeed("SubscriptionId")]
        public Guid? SubscriptionId { get; private set; }

        [Billfeed("ActivityType")]
        public string Activity { get; private set; }

        [Billfeed("ServiceType")]
        public string ServiceType { get; private set; }

        [Billfeed("OrderCreationDate")]
        public string OrderCreationDate { get; private set; }

        [Billfeed("PurchaseDate")]
        public string PurchaseDate { get; private set; }

        [Billfeed("ActivationDate")]
        public string ActivationDate { get; private set; }

        [Billfeed("SubscriptionType")]
        public string SubscriptionType { get; private set; }

        [Billfeed("TermStartDate")]
        public string TermStartDate { get; private set; }

        [Billfeed("TermEndDate")]
        public string TermEndDate { get; private set; }

        [Billfeed("TermDuration")]
        public string TermDuration { get; private set; }

        [Billfeed("NextRenewalDate")]
        public string NextRenewalDate { get; private set; }

        [Billfeed("ServiceCancellationDate")]
        public string ServiceCancellationDate { get; private set; }

        [Billfeed("BillFrom")]
        public string BillFrom { get; private set; }

        [Billfeed("BillTo")]
        public string BillTo { get; private set; }

        [Billfeed("CompanyName")]
        public string CompanyName { get; private set; }

        [Billfeed("CustomerCode")]
        public string CustomerCode { get; private set; }

        [Billfeed("AccountCreationDate")]
        public string AccountCreationDate { get; private set; }

        [Billfeed("FirstName")]
        public string FirstName { get; private set; }

        [Billfeed("LastName")]
        public string LastName { get; private set; }

        [Billfeed("CustomerEmailAddress")]
        public string CustomerEmailAddress { get; private set; }

        [Billfeed("CustomerPhoneNumber")]
        public string CustomerPhoneNumber { get; private set; }

        [Billfeed("BillingStreet")]
        public string BillingStreet { get; private set; }

        [Billfeed("BillingNumber")]
        public string BillingNumber { get; private set; }

        [Billfeed("BillingComplement")]
        public string BillingComplement { get; private set; }

        [Billfeed("BillingNeighbourhood")]
        public string BillingNeighbourhood { get; private set; }

        [Billfeed("BillingCity")]
        public string BillingCity { get; private set; }

        [Billfeed("BillingState/Province")]
        public string BillingStateOrProvince { get; private set; }

        [Billfeed("BillingZIPcode")]
        public string BillingZIPcode { get; private set; }

        [Billfeed("BillingCountry")]
        public string BillingCountry { get; private set; }

        [Billfeed("BillingCountryCode")]
        public string BillingCountryCode { get; private set; }

        [Billfeed("BillingPhoneNumber")]
        public string BillingPhoneNumber { get; private set; }

        [Billfeed("MailingStreet")]
        public string MailingStreet { get; private set; }

        [Billfeed("MailingNumber")]
        public string MailingNumber { get; private set; }

        [Billfeed("MailingComplement")]
        public string MailingComplement { get; private set; }

        [Billfeed("MailingNeighbourhood")]
        public string MailingNeighbourhood { get; private set; }

        [Billfeed("MailingCity")]
        public string MailingCity { get; private set; }

        [Billfeed("MailingState/Province")]
        public string MailingStateOrProvince { get; private set; }

        [Billfeed("MailingZIPcode")]
        public string MailingZIPcode { get; private set; }

        [Billfeed("MailingCountry")]
        public string MailingCountry { get; private set; }

        [Billfeed("MailingCountryCode")]
        public string MailingCountryCode { get; private set; }

        [Billfeed("MailingPhoneNumber")]
        public string MailingPhoneNumber { get; private set; }

        [Billfeed("CustomerCPF")]
        public string CustomerCPF { get; private set; }

        [Billfeed("CustomerCNPJ")]
        public string CustomerCNPJ { get; private set; }

        [Billfeed("CustomerStateRegistration")]
        public string CustomerStateRegistration { get; private set; }

        [Billfeed("InvoiceCreationDate")]
        public string InvoiceCreationDate { get; private set; }

        [Billfeed("ServiceCode")]
        public string ServiceCode { get; private set; }

        [Billfeed("DueDate")]
        public string DueDate { get; private set; }

        [Billfeed("StoreCode")]
        public string StoreCode { get; private set; }

        [Billfeed("MarketplaceCity")]
        public string MarketplaceCity { get; private set; }

        [Billfeed("MarketplaceState")]
        public string MarketplaceState { get; private set; }

        [Billfeed("UserAccountStatus")]
        public string UserAccountStatus { get; private set; }

        [Billfeed("Premeditateddefaulter")]
        public string Premeditateddefaulter { get; private set; }

        [Billfeed("ServiceName")]
        public string ServiceName { get; private set; }

        [Billfeed("OfferName")]
        public string OfferName { get; private set; }

        [Billfeed("OfferCode")]
        public string OfferCode { get; private set; }

        [Billfeed("SalesReferenceCode")]
        public string SalesReferenceCode { get; private set; }

        [Billfeed("UnitOfMeasure")]
        public string UnitOfMeasure { get; private set; }

        [Billfeed("Qty")]
        public double? Qty { get; private set; }

        [Billfeed("Pro-rateScale")]
        public double? ProRateScale { get; private set; }

        [Billfeed("RetailUnitPrice")]
        public double? RetailUnitPrice { get; private set; }

        [Billfeed("Pro-ratedRetailPriceUnitPrice")]
        public double? ProRatedRetailPriceUnitPrice { get; private set; }

        [Billfeed("GrossRetailPrice")]
        public decimal? GrossRetailPrice { get; private set; }

        [Billfeed("RetailPriceDiscount(%)")]
        public double? RetailPriceDiscount { get; private set; }

        [Billfeed("Pro-RatedRetailUnitDiscountedPrice(Amount)")]
        public double? ProRatedRetailUnitDiscountedPriceAmount { get; private set; }

        [Billfeed("TotalRetailPriceDiscount(Amount)")]
        public decimal? TotalRetailPriceDiscountAmount { get; private set; }

        [Billfeed("TotalRetailPrice")]
        public double? TotalRetailPrice { get; private set; }

        [Billfeed("TaxOnTotalRetailPrice")]
        public double? TaxOnTotalRetailPrice { get; private set; }

        [Billfeed("GrandTotal:RetailPrice")]
        public double? GrandTotalRetailPrice { get; private set; }

        [Billfeed("PromotionCode")]
        public string PromotionCode { get; private set; }

        [Billfeed("PromotionDuration")]
        public string PromotionDuration { get; private set; }

        [Billfeed("WholesaleUnitPrice")]
        public double? WholesaleUnitPrice { get; private set; }

        [Billfeed("Pro-ratedWholesaleUnitPrice")]
        public double? ProRatedWholesaleUnitPrice { get; private set; }

        [Billfeed("CustomerTransactionCurrency")]
        public string CustomerTransactionCurrency { get; private set; }

        [Billfeed("VendorCurrency")]
        public string VendorCurrency { get; private set; }

        [Billfeed("GrossWholesalePrice")]
        public double? GrossWholesalePrice { get; private set; }

        [Billfeed("WholesalePriceDiscount(%)")]
        public double? WholesalePriceDiscount { get; private set; }

        [Billfeed("Pro-RatedWholesaleUnitDiscountedPrice(Amount)")]
        public double? ProRatedWholesaleUnitDiscountedPriceAmount { get; private set; }

        [Billfeed("TotalWholesalePriceDiscount(Amount)")]
        public double? TotalWholesalePriceDiscountAmount { get; private set; }

        [Billfeed("TotalWholesalePrice")]
        public double? TotalWholesalePrice { get; private set; }

        [Billfeed("TaxOnTotalWholesalePrice")]
        public double? TaxOnTotalWholesalePrice { get; private set; }

        [Billfeed("GrandTotal:WholesalePrice")]
        public double? GrandTotalWholesalePrice { get; private set; }

        [Billfeed("VendorName")]
        public string VendorName { get; private set; }

        [Billfeed("VendorUnitPrice")]
        public double? VendorUnitPrice { get; private set; }

        [Billfeed("Pro-ratedVendorUnitPrice")]
        public double? ProRatedVendorUnitPrice { get; private set; }

        [Billfeed("TotalVendorPrice")]
        public double? TotalVendorPrice { get; private set; }

        [Billfeed("TaxOnTotalVendorPrice")]
        public double? TaxOnTotalVendorPrice { get; private set; }

        [Billfeed("GrandTotal:VendorPrice")]
        public double? GrandTotalVendorPrice { get; private set; }

        [Billfeed("BillingCycle")]
        public string BillingCycle { get; private set; }

        [Billfeed("ProrateType")]
        public string ProrateType { get; private set; }

        [Billfeed("ProrateOnCancellation")]
        public string ProrateOnCancellation { get; private set; }

        [Billfeed("UsageAttributes")]
        public string UsageAttributes { get; private set; }

        [Billfeed("PaymentMethod")]
        public string PaymentMethod { get; private set; }

        [Billfeed("PaymentStatus")]
        public string PaymentStatus { get; private set; }

        [Billfeed("RefundType")]
        public string RefundType { get; private set; }

        [Billfeed("RefundAmount")]
        public string RefundAmount { get; private set; }

        [Billfeed("InvoiceNumber")]
        public string InvoiceNumber { get; private set; }

        [Billfeed("ResourceId")]
        public string ResourceId { get; private set; }

        [Billfeed("ChargeType")]
        public string ChargeType { get; private set; }

        [Billfeed("InvoiceStatus")]
        public string InvoiceStatus { get; private set; }

        [Billfeed("IndividualInvoice")]
        public string IndividualInvoice { get; private set; }

        [Billfeed("TaxRate-ISS")]
        public decimal? TaxRateISS { get; private set; }

        [Billfeed("TotalTax-ISS")]
        public decimal? TotalTaxISS { get; private set; }

        [Billfeed("TaxRate-COFINS")]
        public decimal? TaxRateCOFINS { get; private set; }

        [Billfeed("TotalTax-COFINS")]
        public decimal? TotalTaxCOFINS { get; private set; }

        [Billfeed("TaxRate-PIS")]
        public decimal? TaxRatePIS { get; private set; }

        [Billfeed("TotalTax-PIS")]
        public decimal? TotalTaxPIS { get; private set; }

        [Billfeed("TotalInvoicePrice")]
        public decimal? TotalInvoicePrice { get; private set; }

        [Billfeed("CustomerAcronym")]
        public string CustomerAcronym { get; private set; }

        [Billfeed("Segment")]
        public string Segment { get; private set; }

        [Billfeed("CycleCode")]
        public string CycleCode { get; private set; }

        [Billfeed("CycleReference")]
        public string CycleReference { get; private set; }

        [Billfeed("FinancialStatus")]
        public string FinancialStatus { get; private set; }

        [Billfeed("CommentsCredited")]
        public string CommentsCredited { get; private set; }

        [Billfeed("Receivable")]
        public string Receivable { get; private set; }

        [Billfeed("UserCPFhasmadethecredit")]
        public string CpfUserHasMadeCredit { get; private set; }

        [Billfeed("ProposalNumber")]
        public string ProposalNumber { get; private set; }

        [Billfeed("AdabasCode")]
        public string AdabasCode { get; private set; }

        [Billfeed("OpportunityId")]
        public string OpportunityId { get; private set; }

        [Billfeed("QuoteId")]
        public string QuoteId { get; private set; }

        [Billfeed("StoreAcronym")]
        public string StoreAcronym { get; private set; }

        [Billfeed("TotalRetailPriceWithTaxesWithoutDiscount")]
        public double? TotalRetailPriceWithTaxesWithoutDiscount { get; private set; }

        [Billfeed("AffiliateCode")]
        public string AffiliateCode { get; private set; }

        [Billfeed("ServiceProviderCompanyName")]
        public string ServiceProviderCompanyName { get; private set; }

        [Billfeed("CNPJServiceProviderCompany")]
        public string CNPJServiceProviderCompany { get; private set; }

        [Billfeed("StoreAcronymServiceProvider")]
        public string StoreAcronymServiceProvider { get; private set; }
    }
}
