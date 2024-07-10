using System;
using TinyCsvParser.Mapping;
using System.Linq;
using Gcsb.Connect.SAP.Domain.Attributes;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Infrastructure.CsvConvert
{
    public class BillFeedItemCsvMap : CsvMapping<BillFeedItem>
    {
        public string[] HeaderLine { get; set; }

        public BillFeedItemCsvMap(string[] headerline) : base()
        {
            this.HeaderLine = headerline;

            MapProperty(GetIndexOff(x => x.Sequence), x => x.Sequence);
            MapProperty(GetIndexOff(x => x.Marketplace), x => x.Marketplace);
            MapProperty(GetIndexOff(x => x.ResellerName), x => x.ResellerName);
            MapProperty(GetIndexOff(x => x.ResellerContactName), x => x.ResellerContactName);
            MapProperty(GetIndexOff(x => x.ResellerEmailAddress), x => x.ResellerEmailAddress);
            MapProperty(GetIndexOff(x => x.ResellerPhoneNumber), x => x.ResellerPhoneNumber);
            MapProperty(GetIndexOff(x => x.OrderId), x => x.OrderId);
            MapProperty(GetIndexOff(x => x.SubscriptionId), x => x.SubscriptionId);
            MapProperty(GetIndexOff(x => x.Activity), x => x.Activity);
            MapProperty(GetIndexOff(x => x.ServiceType), x => x.ServiceType);
            MapProperty(GetIndexOff(x => x.OrderCreationDate), x => x.OrderCreationDate);
            MapProperty(GetIndexOff(x => x.PurchaseDate), x => x.PurchaseDate);
            MapProperty(GetIndexOff(x => x.ActivationDate), x => x.ActivationDate);
            MapProperty(GetIndexOff(x => x.SubscriptionType), x => x.SubscriptionType);
            MapProperty(GetIndexOff(x => x.TermStartDate), x => x.TermStartDate);
            MapProperty(GetIndexOff(x => x.TermEndDate), x => x.TermEndDate);
            MapProperty(GetIndexOff(x => x.TermDuration), x => x.TermDuration);
            MapProperty(GetIndexOff(x => x.NextRenewalDate), x => x.NextRenewalDate);
            MapProperty(GetIndexOff(x => x.ServiceCancellationDate), x => x.ServiceCancellationDate);
            MapProperty(GetIndexOff(x => x.BillFrom), x => x.BillFrom);
            MapProperty(GetIndexOff(x => x.BillTo), x => x.BillTo);
            MapProperty(GetIndexOff(x => x.CompanyName), x => x.CompanyName);
            MapProperty(GetIndexOff(x => x.CustomerCode), x => x.CustomerCode);
            MapProperty(GetIndexOff(x => x.AccountCreationDate), x => x.AccountCreationDate);
            MapProperty(GetIndexOff(x => x.FirstName), x => x.FirstName);
            MapProperty(GetIndexOff(x => x.LastName), x => x.LastName);
            MapProperty(GetIndexOff(x => x.CustomerEmailAddress), x => x.CustomerEmailAddress);
            MapProperty(GetIndexOff(x => x.CustomerPhoneNumber), x => x.CustomerPhoneNumber);
            MapProperty(GetIndexOff(x => x.BillingStreet), x => x.BillingStreet);
            MapProperty(GetIndexOff(x => x.BillingNumber), x => x.BillingNumber);
            MapProperty(GetIndexOff(x => x.BillingComplement), x => x.BillingComplement);
            MapProperty(GetIndexOff(x => x.BillingNeighbourhood), x => x.BillingNeighbourhood);
            MapProperty(GetIndexOff(x => x.BillingCity), x => x.BillingCity);
            MapProperty(GetIndexOff(x => x.BillingStateOrProvince), x => x.BillingStateOrProvince);
            MapProperty(GetIndexOff(x => x.BillingZIPcode), x => x.BillingZIPcode);
            MapProperty(GetIndexOff(x => x.BillingCountry), x => x.BillingCountry);
            MapProperty(GetIndexOff(x => x.BillingCountryCode), x => x.BillingCountryCode);
            MapProperty(GetIndexOff(x => x.BillingPhoneNumber), x => x.BillingPhoneNumber);
            MapProperty(GetIndexOff(x => x.MailingStreet), x => x.MailingStreet);
            MapProperty(GetIndexOff(x => x.MailingNumber), x => x.MailingNumber);
            MapProperty(GetIndexOff(x => x.MailingComplement), x => x.MailingComplement);
            MapProperty(GetIndexOff(x => x.MailingNeighbourhood), x => x.MailingNeighbourhood);
            MapProperty(GetIndexOff(x => x.MailingCity), x => x.MailingCity);
            MapProperty(GetIndexOff(x => x.MailingStateOrProvince), x => x.MailingStateOrProvince);
            MapProperty(GetIndexOff(x => x.MailingZIPcode), x => x.MailingZIPcode);
            MapProperty(GetIndexOff(x => x.MailingCountry), x => x.MailingCountry);
            MapProperty(GetIndexOff(x => x.MailingCountryCode), x => x.MailingCountryCode);
            MapProperty(GetIndexOff(x => x.MailingPhoneNumber), x => x.MailingPhoneNumber);
            MapProperty(GetIndexOff(x => x.ServiceName), x => x.ServiceName);
            MapProperty(GetIndexOff(x => x.OfferName), x => x.OfferName);
            MapProperty(GetIndexOff(x => x.OfferCode), x => x.OfferCode);
            MapProperty(GetIndexOff(x => x.SalesReferenceCode), x => x.SalesReferenceCode);
            MapProperty(GetIndexOff(x => x.UnitOfMeasure), x => x.UnitOfMeasure);
            MapProperty(GetIndexOff(x => x.Qty), x => x.Qty);
            MapProperty(GetIndexOff(x => x.ProRateScale), x => x.ProRateScale);
            MapProperty(GetIndexOff(x => x.RetailUnitPrice), x => x.RetailUnitPrice);
            MapProperty(GetIndexOff(x => x.ProRatedRetailPriceUnitPrice), x => x.ProRatedRetailPriceUnitPrice);
            MapProperty(GetIndexOff(x => x.GrossRetailPrice), x => x.GrossRetailPrice);
            MapProperty(GetIndexOff(x => x.RetailPriceDiscount), x => x.RetailPriceDiscount);
            MapProperty(GetIndexOff(x => x.ProRatedRetailUnitDiscountedPriceAmount), x => x.ProRatedRetailUnitDiscountedPriceAmount);
            MapProperty(GetIndexOff(x => x.TotalRetailPriceDiscountAmount), x => x.TotalRetailPriceDiscountAmount);
            MapProperty(GetIndexOff(x => x.TotalRetailPrice), x => x.TotalRetailPrice);
            MapProperty(GetIndexOff(x => x.TaxOnTotalRetailPrice), x => x.TaxOnTotalRetailPrice);
            MapProperty(GetIndexOff(x => x.GrandTotalRetailPrice), x => x.GrandTotalRetailPrice);
            MapProperty(GetIndexOff(x => x.PromotionCode), x => x.PromotionCode);
            MapProperty(GetIndexOff(x => x.PromotionDuration), x => x.PromotionDuration);
            MapProperty(GetIndexOff(x => x.WholesaleUnitPrice), x => x.WholesaleUnitPrice);
            MapProperty(GetIndexOff(x => x.ProRatedWholesaleUnitPrice), x => x.ProRatedWholesaleUnitPrice);
            MapProperty(GetIndexOff(x => x.CustomerTransactionCurrency), x => x.CustomerTransactionCurrency);
            MapProperty(GetIndexOff(x => x.VendorCurrency), x => x.VendorCurrency);
            MapProperty(GetIndexOff(x => x.GrossWholesalePrice), x => x.GrossWholesalePrice);
            MapProperty(GetIndexOff(x => x.WholesalePriceDiscount), x => x.WholesalePriceDiscount);
            MapProperty(GetIndexOff(x => x.ProRatedWholesaleUnitDiscountedPriceAmount), x => x.ProRatedWholesaleUnitDiscountedPriceAmount);
            MapProperty(GetIndexOff(x => x.TotalWholesalePriceDiscountAmount), x => x.TotalWholesalePriceDiscountAmount);
            MapProperty(GetIndexOff(x => x.TotalWholesalePrice), x => x.TotalWholesalePrice);
            MapProperty(GetIndexOff(x => x.TaxOnTotalWholesalePrice), x => x.TaxOnTotalWholesalePrice);
            MapProperty(GetIndexOff(x => x.GrandTotalWholesalePrice), x => x.GrandTotalWholesalePrice);
            MapProperty(GetIndexOff(x => x.VendorName), x => x.VendorName);
            MapProperty(GetIndexOff(x => x.VendorUnitPrice), x => x.VendorUnitPrice);
            MapProperty(GetIndexOff(x => x.ProRatedVendorUnitPrice), x => x.ProRatedVendorUnitPrice);
            MapProperty(GetIndexOff(x => x.TotalVendorPrice), x => x.TotalVendorPrice);
            MapProperty(GetIndexOff(x => x.TaxOnTotalVendorPrice), x => x.TaxOnTotalVendorPrice);
            MapProperty(GetIndexOff(x => x.GrandTotalVendorPrice), x => x.GrandTotalVendorPrice);
            MapProperty(GetIndexOff(x => x.BillingCycle), x => x.BillingCycle);
            MapProperty(GetIndexOff(x => x.ProrateType), x => x.ProrateType);
            MapProperty(GetIndexOff(x => x.ProrateOnCancellation), x => x.ProrateOnCancellation);
            MapProperty(GetIndexOff(x => x.UsageAttributes), x => x.UsageAttributes);
            MapProperty(GetIndexOff(x => x.PaymentMethod), x => x.PaymentMethod);
            MapProperty(GetIndexOff(x => x.PaymentStatus), x => x.PaymentStatus);
            MapProperty(GetIndexOff(x => x.RefundType), x => x.RefundType);
            MapProperty(GetIndexOff(x => x.RefundAmount), x => x.RefundAmount);
            MapProperty(GetIndexOff(x => x.InvoiceNumber), x => x.InvoiceNumber);
            MapProperty(GetIndexOff(x => x.ResourceId), x => x.ResourceId);
            MapProperty(GetIndexOff(x => x.ChargeType), x => x.ChargeType);
            MapProperty(GetIndexOff(x => x.InvoiceStatus), x => x.InvoiceStatus);
            MapProperty(GetIndexOff(x => x.CustomerCPF), x => x.CustomerCPF);
            MapProperty(GetIndexOff(x => x.CustomerCNPJ), x => x.CustomerCNPJ);
            MapProperty(GetIndexOff(x => x.CustomerStateRegistration), x => x.CustomerStateRegistration);
            MapProperty(GetIndexOff(x => x.InvoiceCreationDate), x => x.InvoiceCreationDate);
            MapProperty(GetIndexOff(x => x.ServiceCode), x => x.ServiceCode);
            MapProperty(GetIndexOff(x => x.DueDate), x => x.DueDate);
            MapProperty(GetIndexOff(x => x.StoreCode), x => x.StoreCode);
            MapProperty(GetIndexOff(x => x.MarketplaceCity), x => x.MarketplaceCity);
            MapProperty(GetIndexOff(x => x.MarketplaceState), x => x.MarketplaceState);
            MapProperty(GetIndexOff(x => x.UserAccountStatus), x => x.UserAccountStatus);
            MapProperty(GetIndexOff(x => x.Premeditateddefaulter), x => x.Premeditateddefaulter);
            MapProperty(GetIndexOff(x => x.IndividualInvoice), x => x.IndividualInvoice);
            MapProperty(GetIndexOff(x => x.TaxRateISS), x => x.TaxRateISS);
            MapProperty(GetIndexOff(x => x.TotalTaxISS), x => x.TotalTaxISS);
            MapProperty(GetIndexOff(x => x.TaxRateCOFINS), x => x.TaxRateCOFINS);
            MapProperty(GetIndexOff(x => x.TotalTaxCOFINS), x => x.TotalTaxCOFINS);
            MapProperty(GetIndexOff(x => x.TaxRatePIS), x => x.TaxRatePIS);
            MapProperty(GetIndexOff(x => x.TotalTaxPIS), x => x.TotalTaxPIS);
            MapProperty(GetIndexOff(x => x.TotalInvoicePrice), x => x.TotalInvoicePrice);
            MapProperty(GetIndexOff(x => x.CustomerAcronym), x => x.CustomerAcronym);
            MapProperty(GetIndexOff(x => x.Segment), x => x.Segment);
            MapProperty(GetIndexOff(x => x.CycleCode), x => x.CycleCode);
            MapProperty(GetIndexOff(x => x.CycleReference), x => x.CycleReference);
            MapProperty(GetIndexOff(x => x.FinancialStatus), x => x.FinancialStatus);
            MapProperty(GetIndexOff(x => x.CommentsCredited), x => x.CommentsCredited);
            MapProperty(GetIndexOff(x => x.Receivable), x => x.Receivable);
            MapProperty(GetIndexOff(x => x.CpfUserHasMadeCredit), x => x.CpfUserHasMadeCredit);
            MapProperty(GetIndexOff(x => x.ProposalNumber), x => x.ProposalNumber);
            MapProperty(GetIndexOff(x => x.AdabasCode), x => x.AdabasCode);
            MapProperty(GetIndexOff(x => x.OpportunityId), x => x.OpportunityId);
            MapProperty(GetIndexOff(x => x.QuoteId), x => x.QuoteId);
            MapProperty(GetIndexOff(x => x.StoreAcronym), x => x.StoreAcronym);
            MapProperty(GetIndexOff(x => x.TotalRetailPriceWithTaxesWithoutDiscount), x => x.TotalRetailPriceWithTaxesWithoutDiscount);
            MapProperty(GetIndexOff(x => x.AffiliateCode), x => x.AffiliateCode);            
            MapProperty(GetIndexOff(x => x.ServiceProviderCompanyName), x => x.ServiceProviderCompanyName);
            MapProperty(GetIndexOff(x => x.CNPJServiceProviderCompany), x => x.CNPJServiceProviderCompany);
            MapProperty(GetIndexOff(x => x.StoreAcronymServiceProvider), x => x.StoreAcronymServiceProvider);
        }

        private int GetIndexOff<T>(Expression<Func<BillFeedItem, T>> item)
        {
            var attrName = (item.Body as MemberExpression).Member.GetCustomAttributes(false).Select(s => ((BillfeedAttribute)s).NameColumn).FirstOrDefault();
            return Array.IndexOf(this.HeaderLine, attrName.ToLower());
        }
    }
}
