using Gcsb.Connect.SAP.Domain.Config;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit
{
    public class ServiceInvoice
    {
        public Guid Id { get; private set; }
        public string InvoiceNumber { get; private set; }
        public Guid Sequence { get; private set; }
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

        public Invoice Invoice { get; set; }

        public FinancialAccount Account { get; set; }

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

        public ServiceInvoice(Guid id, string invoiceNumber, Guid sequence, Guid? subscriptionId, string activity, string serviceType, DateTime? orderCreationDate,
            DateTime? purchaseDate, DateTime? activationDate, string subscriptionType, DateTime? termStartDate, DateTime? termEndDate, string termDuration,
            DateTime? nextRenewalDate, string serviceCancellationDate, string serviceCode, DateTime? dueDate, string serviceName, string offerName,
            string offerCode, string salesReferenceCode, string unitOfMeasure, double? qty, double? proRateScale, double? retailUnitPrice,
            double? proRatedRetailPriceUnitPrice, decimal? grossRetailPrice, double? retailPriceDiscount, double? proRatedRetailUnitDiscountedPriceAmount,
            decimal? totalRetailPriceDiscountAmount, double? totalRetailPrice, double? taxOnTotalRetailPrice, double? grandTotalRetailPrice,
            string promotionCode, string promotionDuration, double? wholesaleUnitPrice, double? proRatedWholesaleUnitPrice, string vendorCurrency,
            double? grossWholesalePrice, double? wholesalePriceDiscount, double? proRatedWholesaleUnitDiscountedPriceAmount,
            double? totalWholesalePriceDiscountAmount, double? totalWholesalePrice, double? taxOnTotalWholesalePrice, double? grandTotalWholesalePrice,
            string vendorName, double? vendorUnitPrice, double? proRatedVendorUnitPrice, double? totalVendorPrice, double? taxOnTotalVendorPrice,
            double? grandTotalVendorPrice, string billingCycle, string prorateType, string prorateOnCancellation, string usageAttributes,
            string resourceId, string chargeType, Invoice invoice, decimal? taxrateiss, decimal? totaltaxiss,
            decimal? taxratecofins, decimal? totaltaxcofins, decimal? taxratepis,
            decimal? totaltaxpis, DateTime? cyclereference, string financialstatus,
            string commentscredited, string receivable, double? totalRetailPriceWithTaxesWithoutDiscount,
            string serviceprovidercompanyname, string cnpjserviceprovidercompany, string storeacronymserviceprovider)
        {
            Id = id;
            InvoiceNumber = invoiceNumber;
            Sequence = sequence;
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
            ServiceCode = serviceCode;
            DueDate = dueDate;
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
            ResourceId = resourceId;
            ChargeType = chargeType;
            Invoice = invoice;
            TaxRateISS = taxrateiss;            
            TotalTaxISS = totaltaxiss;
            TaxRateCOFINS = taxratecofins;            
            TotalTaxCOFINS = totaltaxcofins;
            TaxRatePIS = taxratepis;
            TotalTaxPIS = totaltaxpis;
            CycleReference = cyclereference;
            FinancialStatus = financialstatus;
            CommentsCredited = commentscredited;
            Receivable = receivable;
            TotalRetailPriceWithTaxesWithoutDiscount = totalRetailPriceWithTaxesWithoutDiscount;
            ServiceProviderCompanyName = serviceprovidercompanyname;
            CNPJServiceProviderCompany = cnpjserviceprovidercompany;
            StoreAcronymServiceProvider = storeacronymserviceprovider;
        }
    }
}
