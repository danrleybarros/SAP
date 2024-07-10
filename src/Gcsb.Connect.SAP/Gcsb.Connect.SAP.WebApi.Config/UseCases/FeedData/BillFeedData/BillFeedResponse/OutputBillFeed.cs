using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.BillFeedData.BillFeedResponse
{
    public class OutputBillFeed
    {
        public string Marketplace { get; private set; }

        public string ResellerName { get; private set; }

        public string ResellerContactName { get; private set; }

        public string ResellerEmailAddress { get; private set; }

        public string ResellerPhoneNumber { get; private set; }

        public string OrderId { get; private set; }

        public Guid? SubscriptionId { get; private set; }

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

        public string IndividualInvoice { get; private set; }

        public string MunicipalTaxpayerRegistration { get; private set; }

        public string CompanyCode { get; private set; }

        public string AffiliateCode { get; private set; }

        public string CityServiceCode { get; private set; }

        public string CityHallServiceDescription { get; private set; }

        public string SpecialProcedureNumber { get; private set; }

        public decimal? TaxRateISS { get; private set; }

        public decimal? TotalTaxISS { get; private set; }

        public decimal? TaxRateCOFINS { get; private set; }

        public decimal? TotalTaxCOFINS { get; private set; }

        public decimal? TaxRatePIS { get; private set; }

        public decimal? TotalTaxPIS { get; private set; }

        public decimal? TotalInvoicePrice { get; private set; }

        public string CnpjMarketPlace { get; private set; }

        public string CompanyNameMarketPlace { get; private set; }

        public string CustomerAcronym { get; private set; }

        public string Segment { get; private set; }

        public DateTime? CycleCode { get; private set; }

        public DateTime? CycleReference { get; private set; }

        public string FinancialStatus { get; private set; }

        public string CommentsCredited { get; private set; }

        public string Receivable { get; private set; }

        public double? TotalRetailPriceWithTaxesWithoutDiscount { get; private set; }

        public string StoreAcronym { get; private set; }

        public string CNPJServiceProviderCompany { get; private set; }

        public string ServiceProviderCompanyName { get; private set; }

        public string StoreAcronymServiceProvider { get; private set; }

        public OutputBillFeed(string marketplace, string resellerName, string resellerContactName, string resellerEmailAddress, string resellerPhoneNumber, string orderId, Guid? subscriptionId,
            string activity, string serviceType, DateTime? orderCreationDate, DateTime? purchaseDate, DateTime? activationDate, string subscriptionType, DateTime? termStartDate, DateTime? termEndDate,
            string termDuration, DateTime? nextRenewalDate, string serviceCancellationDate, DateTime? billFrom, DateTime? billTo, string companyName, string customerCode, DateTime? accountCreationDate,
            string firstName, string lastName, string customerEmailAddress, string customerPhoneNumber, string billingStreet, string billingNumber, string billingComplement, string billingNeighbourhood,
            string billingCity, string billingStateOrProvince, string billingZIPcode, string billingCountry, string billingCountryCode, string billingPhoneNumber, string mailingStreet, string mailingNumber,
            string mailingComplement, string mailingNeighbourhood, string mailingCity, string mailingStateOrProvince, string mailingZIPcode, string mailingCountry, string mailingCountryCode,
            string mailingPhoneNumber, string customerCPF, string customerCNPJ, string customerStateRegistration, DateTime? invoiceCreationDate, string serviceCode, DateTime? dueDate, string storeCode,
            string marketplaceCity, string marketplaceState, string userAccountStatus, string premeditateddefaulter, string serviceName, string offerName, string offerCode, string salesReferenceCode,
            string unitOfMeasure, double? qty, double? proRateScale, double? retailUnitPrice, double? proRatedRetailPriceUnitPrice, decimal? grossRetailPrice, double? retailPriceDiscount,
            double? proRatedRetailUnitDiscountedPriceAmount, decimal? totalRetailPriceDiscountAmount, double? totalRetailPrice, double? taxOnTotalRetailPrice, double? grandTotalRetailPrice,
            string promotionCode, string promotionDuration, double? wholesaleUnitPrice, double? proRatedWholesaleUnitPrice, string customerTransactionCurrency, string vendorCurrency,
            double? grossWholesalePrice, double? wholesalePriceDiscount, double? proRatedWholesaleUnitDiscountedPriceAmount, double? totalWholesalePriceDiscountAmount, double? totalWholesalePrice,
            double? taxOnTotalWholesalePrice, double? grandTotalWholesalePrice, string vendorName, double? vendorUnitPrice, double? proRatedVendorUnitPrice, double? totalVendorPrice,
            double? taxOnTotalVendorPrice, double? grandTotalVendorPrice, string billingCycle, string prorateType, string prorateOnCancellation, string usageAttributes, string paymentMethod,
            string paymentStatus, string refundType, string refundAmount, string invoiceNumber, string resourceId, string chargeType, string invoiceStatus, string individualInvoice,
            string municipalTaxpayerRegistration, string companyCode, string affiliateCode, string cityServiceCode, string cityHallServiceDescription, string specialProcedureNumber, decimal? taxRateISS,
            decimal? totalTaxISS, decimal? taxRateCOFINS, decimal? totalTaxCOFINS, decimal? taxRatePIS, decimal? totalTaxPIS, decimal? totalInvoicePrice, string cnpjMarketPlace, string companyNameMarketPlace,
            string customerAcronym, string segment, DateTime? cycleCode, DateTime? cycleReference, string financialStatus, string commentsCredited, string receivable, 
            double? totalRetailPriceWithTaxesWithoutDiscount, string storeAcronym,
            string cnpjServiceProviderCompany , string serviceProviderCompanyName, string storeAcronymServiceProvider)
        {
            Marketplace = marketplace;
            ResellerName = resellerName;
            ResellerContactName = resellerContactName;
            ResellerEmailAddress = resellerEmailAddress;
            ResellerPhoneNumber = resellerPhoneNumber;
            OrderId = orderId;
            SubscriptionId = subscriptionId;
            Activity = activity;
            ServiceType = serviceType;
            OrderCreationDate = orderCreationDate;
            PurchaseDate = purchaseDate;
            ActivationDate = activationDate;
            SubscriptionType = subscriptionType;
            TermStartDate = termStartDate;
            TermEndDate = termEndDate;
            TermDuration = termDuration;
            NextRenewalDate = nextRenewalDate;
            ServiceCancellationDate = serviceCancellationDate;
            BillFrom = billFrom;
            BillTo = billTo;
            CompanyName = companyName;
            CustomerCode = customerCode;
            AccountCreationDate = accountCreationDate;
            FirstName = firstName;
            LastName = lastName;
            CustomerEmailAddress = customerEmailAddress;
            CustomerPhoneNumber = customerPhoneNumber;
            BillingStreet = billingStreet;
            BillingNumber = billingNumber;
            BillingComplement = billingComplement;
            BillingNeighbourhood = billingNeighbourhood;
            BillingCity = billingCity;
            BillingStateOrProvince = billingStateOrProvince;
            BillingZIPcode = billingZIPcode;
            BillingCountry = billingCountry;
            BillingCountryCode = billingCountryCode;
            BillingPhoneNumber = billingPhoneNumber;
            MailingStreet = mailingStreet;
            MailingNumber = mailingNumber;
            MailingComplement = mailingComplement;
            MailingNeighbourhood = mailingNeighbourhood;
            MailingCity = mailingCity;
            MailingStateOrProvince = mailingStateOrProvince;
            MailingZIPcode = mailingZIPcode;
            MailingCountry = mailingCountry;
            MailingCountryCode = mailingCountryCode;
            MailingPhoneNumber = mailingPhoneNumber;
            CustomerCPF = customerCPF;
            CustomerCNPJ = customerCNPJ;
            CustomerStateRegistration = customerStateRegistration;
            InvoiceCreationDate = invoiceCreationDate;
            ServiceCode = serviceCode;
            DueDate = dueDate;
            StoreCode = storeCode;
            MarketplaceCity = marketplaceCity;
            MarketplaceState = marketplaceState;
            UserAccountStatus = userAccountStatus;
            Premeditateddefaulter = premeditateddefaulter;
            ServiceName = serviceName;
            OfferName = offerName;
            OfferCode = offerCode;
            SalesReferenceCode = salesReferenceCode;
            UnitOfMeasure = unitOfMeasure;
            Qty = qty;
            ProRateScale = proRateScale;
            RetailUnitPrice = retailUnitPrice;
            ProRatedRetailPriceUnitPrice = proRatedRetailPriceUnitPrice;
            GrossRetailPrice = grossRetailPrice;
            RetailPriceDiscount = retailPriceDiscount;
            ProRatedRetailUnitDiscountedPriceAmount = proRatedRetailUnitDiscountedPriceAmount;
            TotalRetailPriceDiscountAmount = totalRetailPriceDiscountAmount;
            TotalRetailPrice = totalRetailPrice;
            TaxOnTotalRetailPrice = taxOnTotalRetailPrice;
            GrandTotalRetailPrice = grandTotalRetailPrice;
            PromotionCode = promotionCode;
            PromotionDuration = promotionDuration;
            WholesaleUnitPrice = wholesaleUnitPrice;
            ProRatedWholesaleUnitPrice = proRatedWholesaleUnitPrice;
            CustomerTransactionCurrency = customerTransactionCurrency;
            VendorCurrency = vendorCurrency;
            GrossWholesalePrice = grossWholesalePrice;
            WholesalePriceDiscount = wholesalePriceDiscount;
            ProRatedWholesaleUnitDiscountedPriceAmount = proRatedWholesaleUnitDiscountedPriceAmount;
            TotalWholesalePriceDiscountAmount = totalWholesalePriceDiscountAmount;
            TotalWholesalePrice = totalWholesalePrice;
            TaxOnTotalWholesalePrice = taxOnTotalWholesalePrice;
            GrandTotalWholesalePrice = grandTotalWholesalePrice;
            VendorName = vendorName;
            VendorUnitPrice = vendorUnitPrice;
            ProRatedVendorUnitPrice = proRatedVendorUnitPrice;
            TotalVendorPrice = totalVendorPrice;
            TaxOnTotalVendorPrice = taxOnTotalVendorPrice;
            GrandTotalVendorPrice = grandTotalVendorPrice;
            BillingCycle = billingCycle;
            ProrateType = prorateType;
            ProrateOnCancellation = prorateOnCancellation;
            UsageAttributes = usageAttributes;
            PaymentMethod = paymentMethod;
            PaymentStatus = paymentStatus;
            RefundType = refundType;
            RefundAmount = refundAmount;
            InvoiceNumber = invoiceNumber;
            ResourceId = resourceId;
            ChargeType = chargeType;
            InvoiceStatus = invoiceStatus;
            IndividualInvoice = individualInvoice;
            MunicipalTaxpayerRegistration = municipalTaxpayerRegistration;
            CompanyCode = companyCode;
            AffiliateCode = affiliateCode;
            CityServiceCode = cityServiceCode;
            CityHallServiceDescription = cityHallServiceDescription;
            SpecialProcedureNumber = specialProcedureNumber;
            TaxRateISS = taxRateISS;
            TotalTaxISS = totalTaxISS;
            TaxRateCOFINS = taxRateCOFINS;
            TotalTaxCOFINS = totalTaxCOFINS;
            TaxRatePIS = taxRatePIS;
            TotalTaxPIS = totalTaxPIS;
            TotalInvoicePrice = totalInvoicePrice;
            CnpjMarketPlace = cnpjMarketPlace;
            CompanyNameMarketPlace = companyNameMarketPlace;
            CustomerAcronym = customerAcronym;
            Segment = segment;
            CycleCode = cycleCode;
            CycleReference = cycleReference;
            FinancialStatus = financialStatus;
            CommentsCredited = commentsCredited;
            Receivable = receivable;
            TotalRetailPriceWithTaxesWithoutDiscount = totalRetailPriceWithTaxesWithoutDiscount;
            StoreAcronym = storeAcronym;
            CNPJServiceProviderCompany = cnpjServiceProviderCompany;
            ServiceProviderCompanyName = serviceProviderCompanyName;
            StoreAcronymServiceProvider = storeAcronymServiceProvider;
        }
    }
}
