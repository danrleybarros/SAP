using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.JSDN.BillFeedSplit
{
    public class ServiceBuilder
    {
        public Guid Id;

        public string InvoiceNumber;

        public Guid Sequence;

        public Guid SubscriptionId;

        public string Activity;

        public string ServiceType;

        public DateTime? OrderCreationDate;

        public DateTime? PurchaseDate;

        public DateTime? ActivationDate;

        public string SubscriptionType;

        public DateTime? TermStartDate;

        public DateTime? TermEndDate;

        public string TermDuration;

        public DateTime? NextRenewalDate;

        public string ServiceCancellationDate;

        public string ServiceCode;

        public DateTime? DueDate;

        public string ServiceName;

        public string OfferName;

        public string OfferCode;

        public string SalesReferenceCode;

        public string UnitOfMeasure;

        public double? Qty;

        public double? ProRateScale;

        public double? RetailUnitPrice;

        public double? ProRatedRetailPriceUnitPrice;

        public decimal? GrossRetailPrice;

        public double? RetailPriceDiscount;

        public double? ProRatedRetailUnitDiscountedPriceAmount;

        public decimal? TotalRetailPriceDiscountAmount;

        public double? TotalRetailPrice;

        public double? TaxOnTotalRetailPrice;

        public double? GrandTotalRetailPrice;

        public string PromotionCode;

        public string PromotionDuration;

        public double? WholesaleUnitPrice;

        public double? ProRatedWholesaleUnitPrice;

        public string VendorCurrency;

        public double? GrossWholesalePrice;

        public double? WholesalePriceDiscount;

        public double? ProRatedWholesaleUnitDiscountedPriceAmount;

        public double? TotalWholesalePriceDiscountAmount;

        public double? TotalWholesalePrice;

        public double? TaxOnTotalWholesalePrice;

        public double? GrandTotalWholesalePrice;

        public string VendorName;

        public double? VendorUnitPrice;

        public double? ProRatedVendorUnitPrice;

        public double? TotalVendorPrice;

        public double? TaxOnTotalVendorPrice;

        public double? GrandTotalVendorPrice;

        public string BillingCycle;

        public string ProrateType;

        public string ProrateOnCancellation;

        public string UsageAttributes;

        public string ResourceId;

        public string ChargeType;

        public Invoice Invoice;

        public decimal? TaxRateISS;

        public decimal? TotalTaxISS;

        public decimal? TaxRateCOFINS;

        public decimal? TotalTaxCOFINS;

        public decimal? TaxRatePIS;

        public decimal? TotalTaxPIS;

        public DateTime? CycleCode;

        public DateTime? CycleReference;

        public string FinancialStatus;

        public string CommentsCredited;

        public string Receivable;

        public double? TotalRetailPriceWithTaxesWithoutDiscount;

        public string ServiceProviderCompanyName;

        public string CNPJServiceProviderCompany;

        public string StoreAcronymServiceProvider;

        public static ServiceBuilder New()
        {
            return new ServiceBuilder
            { 
                InvoiceNumber = "",
                Sequence = Guid.NewGuid(),
                SubscriptionId = Guid.NewGuid(),
                Activity = "",
                ServiceType = "",
                OrderCreationDate = DateTime.UtcNow,
                PurchaseDate = DateTime.UtcNow,
                ActivationDate = DateTime.UtcNow,
                SubscriptionType = "",
                TermStartDate = DateTime.UtcNow,
                TermEndDate = DateTime.UtcNow,
                TermDuration = "1 Year",
                NextRenewalDate = DateTime.UtcNow,
                ServiceCancellationDate = "",
                ServiceCode = "",
                DueDate = DateTime.UtcNow,
                ServiceName = "",
                OfferName = "",
                OfferCode = "",
                SalesReferenceCode = "",
                UnitOfMeasure = "",
                Qty = 15,
                ProRateScale = 20,
                RetailUnitPrice = 25,
                ProRatedRetailPriceUnitPrice = 30,
                GrossRetailPrice = 40,
                RetailPriceDiscount = 45,
                ProRatedRetailUnitDiscountedPriceAmount = 50,
                TotalRetailPriceDiscountAmount = 55,
                TotalRetailPrice = 60,
                TaxOnTotalRetailPrice = 65,
                GrandTotalRetailPrice = 70,
                PromotionCode = "",
                PromotionDuration = "",
                WholesaleUnitPrice = 85,
                ProRatedWholesaleUnitPrice = 90,
                VendorCurrency = "",
                GrossWholesalePrice = 95,
                WholesalePriceDiscount = 100,
                ProRatedWholesaleUnitDiscountedPriceAmount = 105,
                TotalWholesalePriceDiscountAmount = 110,
                TotalWholesalePrice = 120,
                TaxOnTotalWholesalePrice = 125,
                GrandTotalWholesalePrice = 130,
                VendorName = "",
                VendorUnitPrice = 135,
                ProRatedVendorUnitPrice = 140,
                TotalVendorPrice = 150,
                TaxOnTotalVendorPrice = 155,
                GrandTotalVendorPrice = 160,
                BillingCycle = "",
                ProrateType = "",
                ProrateOnCancellation = "",
                UsageAttributes = "",
                ResourceId = "",
                ChargeType = "",
                Invoice = InvoiceBuilder.New().Build(),
                TaxRateISS = 2.00m,
                TotalTaxISS = 10.29m,
                TaxRateCOFINS = 2.00m,
                TotalTaxCOFINS = 50.29m,
                TaxRatePIS = 2.00m,
                TotalTaxPIS = 100.62m,
                CycleCode = DateTime.UtcNow,
                CycleReference = DateTime.UtcNow,
                FinancialStatus = "",
                CommentsCredited = "",
                Receivable = "",
                TotalRetailPriceWithTaxesWithoutDiscount = 10,
                ServiceProviderCompanyName = "Telefônica Brasil S.A",
                CNPJServiceProviderCompany = "02.558.157/0001-62",
                StoreAcronymServiceProvider = "telerese"
            };
        }
        //TODO Not working with repository tests, always generating a guid after insert inside and outside.
        public ServiceBuilder WithInvoiceNumber(string invoiceNumber)
        {
            InvoiceNumber = invoiceNumber;
            return this;
        }

        public ServiceBuilder WithSequence(Guid sequence)
        {
            Sequence = sequence;
            return this;
        }

        public ServiceBuilder WithSubscriptionId(Guid subscriptionId)
        {
            SubscriptionId = subscriptionId;
            return this;
        }

        public ServiceBuilder WithActivity(string activity)
        {
            Activity = activity;
            return this;
        }

        public ServiceBuilder WithServiceType(string serviceType)
        {
            ServiceType = serviceType;
            return this;
        }

        public ServiceBuilder WithOrderCreationDate(DateTime? orderCreationDate)
        {
            OrderCreationDate = orderCreationDate;
            return this;
        }

        public ServiceBuilder WithPurchaseDate(DateTime? purchaseDate)
        {
            PurchaseDate = purchaseDate;
            return this;
        }

        public ServiceBuilder WithActivationDate(DateTime? activationDate)
        {
            ActivationDate = activationDate;
            return this;
        }

        public ServiceBuilder WithSubscriptionType(string subscriptionType)
        {
            SubscriptionType = subscriptionType;
            return this;
        }

        public ServiceBuilder WithTermStartDate(DateTime? termStartDate)
        {
            TermStartDate = termStartDate;
            return this;
        }

        public ServiceBuilder WithTermEndDate(DateTime? termEndDate)
        {
            TermEndDate = termEndDate;
            return this;
        }

        public ServiceBuilder WithTermDuration(string termDuration)
        {
            TermDuration = termDuration;
            return this;
        }

        public ServiceBuilder WithNextRenewalDate(DateTime? nextRenewalDate)
        {
            NextRenewalDate = nextRenewalDate;
            return this;
        }

        public ServiceBuilder WithServiceCancellationDate(string serviceCancellationDate)
        {
            ServiceCancellationDate = serviceCancellationDate;
            return this;
        }

        public ServiceBuilder WithServiceCode(string serviceCode)
        {
            ServiceCode = serviceCode;
            return this;
        }

        public ServiceBuilder WithDueDate(DateTime? dueDate)
        {
            DueDate = dueDate;
            return this;
        }

        public ServiceBuilder WithServiceName(string serviceName)
        {
            ServiceName = serviceName;
            return this;
        }

        public ServiceBuilder WithOfferName(string offerName)
        {
            OfferName = offerName;
            return this;
        }

        public ServiceBuilder WithOfferCode(string offerCode)
        {
            OfferCode = offerCode;
            return this;
        }

        public ServiceBuilder WithSalesReferenceCode(string salesReferenceCode)
        {
            SalesReferenceCode = salesReferenceCode;
            return this;
        }

        public ServiceBuilder WithUnitOfMeasure(string unitOfMeasure)
        {
            UnitOfMeasure = unitOfMeasure;
            return this;
        }

        public ServiceBuilder WithQty(double? qty)
        {
            Qty = qty;
            return this;
        }

        public ServiceBuilder WithProRateScale(double? proRateScale)
        {
            ProRateScale = proRateScale;
            return this;
        }

        public ServiceBuilder WithRetailUnitPrice(double? retailUnitPrice)
        {
            RetailUnitPrice = retailUnitPrice;
            return this;
        }

        public ServiceBuilder WithProRatedRetailPriceUnitPrice(double? proRatedRetailPriceUnitPrice)
        {
            ProRatedRetailPriceUnitPrice = proRatedRetailPriceUnitPrice;
            return this;
        }

        public ServiceBuilder WithGrossRetailPrice(decimal? grossRetailPrice)
        {
            GrossRetailPrice = grossRetailPrice;
            return this;
        }

        public ServiceBuilder WithRetailPriceDiscount(double? retailPriceDiscount)
        {
            RetailPriceDiscount = retailPriceDiscount;
            return this;
        }

        public ServiceBuilder WithProRatedRetailUnitDiscountedPriceAmount(double? proRatedRetailUnitDiscountedPriceAmount)
        {
            ProRatedRetailUnitDiscountedPriceAmount = proRatedRetailUnitDiscountedPriceAmount;
            return this;
        }

        public ServiceBuilder WithTotalRetailPriceDiscountAmount(decimal? totalRetailPriceDiscountAmount)
        {
            TotalRetailPriceDiscountAmount = totalRetailPriceDiscountAmount;
            return this;
        }

        public ServiceBuilder WithTotalRetailPrice(double? totalRetailPrice)
        {
            TotalRetailPrice = totalRetailPrice;
            return this;
        }

        public ServiceBuilder WithTaxOnTotalRetailPrice(double? taxOnTotalRetailPrice)
        {
            TaxOnTotalRetailPrice = taxOnTotalRetailPrice;
            return this;
        }

        public ServiceBuilder WithGrandTotalRetailPrice(double? grandTotalRetailPrice)
        {
            GrandTotalRetailPrice = grandTotalRetailPrice;
            return this;
        }

        public ServiceBuilder WithPromotionCode(string promotionCode)
        {
            PromotionCode = promotionCode;
            return this;
        }

        public ServiceBuilder WithPromotionDuration(string promotionDuration)
        {
            PromotionDuration = promotionDuration;
            return this;
        }

        public ServiceBuilder WithWholesaleUnitPrice(double? wholesaleUnitPrice)
        {
            WholesaleUnitPrice = wholesaleUnitPrice;
            return this;
        }

        public ServiceBuilder WithProRatedWholesaleUnitPrice(double? proRatedWholesaleUnitPrice)
        {
            ProRatedWholesaleUnitPrice = proRatedWholesaleUnitPrice;
            return this;
        }

        public ServiceBuilder WithVendorCurrency(string vendorCurrency)
        {
            VendorCurrency = vendorCurrency;
            return this;
        }

        public ServiceBuilder WithGrossWholesalePrice(double? grossWholesalePrice)
        {
            GrossWholesalePrice = grossWholesalePrice;
            return this;
        }

        public ServiceBuilder WithWholesalePriceDiscount(double? wholesalePriceDiscount)
        {
            WholesalePriceDiscount = wholesalePriceDiscount;
            return this;
        }

        public ServiceBuilder WithProRatedWholesaleUnitDiscountedPriceAmount(double? proRatedWholesaleUnitDiscountedPriceAmount)
        {
            ProRatedWholesaleUnitDiscountedPriceAmount = proRatedWholesaleUnitDiscountedPriceAmount;
            return this;
        }

        public ServiceBuilder WithTotalWholesalePriceDiscountAmount(double? totalWholesalePriceDiscountAmount)
        {
            TotalWholesalePriceDiscountAmount = totalWholesalePriceDiscountAmount;
            return this;
        }

        public ServiceBuilder WithTotalWholesalePrice(double? totalWholesalePrice)
        {
            TotalWholesalePrice = totalWholesalePrice;
            return this;
        }

        public ServiceBuilder WithTaxOnTotalWholesalePrice(double? taxOnTotalWholesalePrice)
        {
            TaxOnTotalWholesalePrice = taxOnTotalWholesalePrice;
            return this;
        }

        public ServiceBuilder WithGrandTotalWholesalePrice(double? grandTotalWholesalePrice)
        {
            GrandTotalWholesalePrice = grandTotalWholesalePrice;
            return this;
        }

        public ServiceBuilder WithVendorName(string vendorName)
        {
            VendorName = vendorName;
            return this;
        }

        public ServiceBuilder WithVendorUnitPrice(double? vendorUnitPrice)
        {
            VendorUnitPrice = vendorUnitPrice;
            return this;
        }

        public ServiceBuilder WithProRatedVendorUnitPrice(double? proRatedVendorUnitPrice)
        {
            ProRatedVendorUnitPrice = proRatedVendorUnitPrice;
            return this;
        }

        public ServiceBuilder WithTotalVendorPrice(double? totalVendorPrice)
        {
            TotalVendorPrice = totalVendorPrice;
            return this;
        }

        public ServiceBuilder WithTaxOnTotalVendorPrice(double? taxOnTotalVendorPrice)
        {
            TaxOnTotalVendorPrice = taxOnTotalVendorPrice;
            return this;
        }

        public ServiceBuilder WithGrandTotalVendorPrice(double? grandTotalVendorPrice)
        {
            GrandTotalVendorPrice = grandTotalVendorPrice;
            return this;
        }

        public ServiceBuilder WithBillingCycle(string billingCycle)
        {
            BillingCycle = billingCycle;
            return this;
        }

        public ServiceBuilder WithProrateType(string prorateType)
        {
            ProrateType = prorateType;
            return this;
        }

        public ServiceBuilder WithProrateOnCancellation(string prorateOnCancellation)
        {
            ProrateOnCancellation = prorateOnCancellation;
            return this;
        }

        public ServiceBuilder WithUsageAttributes(string usageAttributes)
        {
            UsageAttributes = usageAttributes;
            return this;
        }

        public ServiceBuilder WithResourceId(string resourceId)
        {
            ResourceId = resourceId;
            return this;
        }

        public ServiceBuilder WithChargeType(string chargeType)
        {
            ChargeType = chargeType;
            return this;
        }

        public ServiceBuilder WithTaxRateCOFINS(decimal? taxratecofins)
        {
            TaxRateCOFINS = taxratecofins;
            return this;
        }

        public ServiceBuilder WithTotalTaxCOFINS(decimal? totaltaxcofins)
        {
            TotalTaxCOFINS = totaltaxcofins;
            return this;
        }

        public ServiceBuilder WithTaxRatePIS(decimal? taxratepis)
        {
            TaxRatePIS = taxratepis;
            return this;
        }

        public ServiceBuilder WithTotalTaxPIS(decimal? totaltaxpis)
        {
            TotalTaxPIS = totaltaxpis;
            return this;
        }

        public ServiceBuilder WithTaxRateISS(decimal? taxRateISS)
        {
            TaxRateISS = taxRateISS;
            return this;
        }

        public ServiceBuilder WithCycleCode(DateTime? cyclecode)
        {
            CycleCode = cyclecode;
            return this;
        }

        public ServiceBuilder WithCycleReference(DateTime? cyclereference)
        {
            CycleReference = cyclereference;
            return this;
        }

        public ServiceBuilder WithFinancialStatus(string financialstatus)
        {
            FinancialStatus = financialstatus;
            return this;
        }

        public ServiceBuilder WithCommentsCredited(string commentscredited)
        {
            CommentsCredited = commentscredited;
            return this;
        }

        public ServiceBuilder WithReceivable(string receivable)
        {
            Receivable = receivable;
            return this;
        }

        public ServiceBuilder WithInvoice(Invoice invoice)
        {
            Invoice = invoice;
            return this;
        }

        public ServiceBuilder WithTotalRetailPriceWithTaxesWithoutDiscount(double totalRetailPriceWithTaxesWithoutDiscount)
        {
            TotalRetailPriceWithTaxesWithoutDiscount = totalRetailPriceWithTaxesWithoutDiscount;
            return this;
        }

        public ServiceBuilder WithServiceProviderCompanyNamee(string serviceprovidercompanyname)
        {
            ServiceProviderCompanyName = serviceprovidercompanyname;
            return this;
        }

        public ServiceBuilder WithCNPJServiceProviderCompany(string cnpjserviceprovidercompany)
        {
            CNPJServiceProviderCompany = cnpjserviceprovidercompany;
            return this;
        }

        public ServiceBuilder WithStoreAcronymServiceProvider(string storeacronymserviceprovider)
        {
            StoreAcronymServiceProvider = storeacronymserviceprovider;
            return this;
        }

        public ServiceInvoice Build()
        {
            return new ServiceInvoice(Guid.NewGuid(), InvoiceNumber, Sequence, SubscriptionId, Activity, ServiceType, OrderCreationDate, PurchaseDate, ActivationDate,
                SubscriptionType, TermStartDate, TermEndDate, TermDuration, NextRenewalDate, ServiceCancellationDate, ServiceCode,
                DueDate, ServiceName, OfferName, OfferCode, SalesReferenceCode, UnitOfMeasure, Qty, ProRateScale, RetailUnitPrice,
                ProRatedRetailPriceUnitPrice, GrossRetailPrice, RetailPriceDiscount, ProRatedRetailUnitDiscountedPriceAmount,
                TotalRetailPriceDiscountAmount, TotalRetailPrice, TaxOnTotalRetailPrice, GrandTotalRetailPrice, PromotionCode, PromotionDuration,
                WholesaleUnitPrice, ProRatedWholesaleUnitPrice, VendorCurrency, GrossWholesalePrice, WholesalePriceDiscount, ProRatedWholesaleUnitDiscountedPriceAmount,
                TotalWholesalePriceDiscountAmount, TotalWholesalePrice, TaxOnTotalWholesalePrice, GrandTotalWholesalePrice,
                VendorName, VendorUnitPrice, ProRatedVendorUnitPrice, TotalVendorPrice, TaxOnTotalVendorPrice,
                GrandTotalVendorPrice, BillingCycle, ProrateType, ProrateOnCancellation, UsageAttributes,
                ResourceId, ChargeType, Invoice, TaxRateISS, TotalTaxISS, TaxRateCOFINS,
                TotalTaxCOFINS, TaxRatePIS, TotalTaxPIS, CycleReference, FinancialStatus, CommentsCredited, Receivable, TotalRetailPriceWithTaxesWithoutDiscount,
                ServiceProviderCompanyName, CNPJServiceProviderCompany, StoreAcronymServiceProvider);
        }
    }
}
