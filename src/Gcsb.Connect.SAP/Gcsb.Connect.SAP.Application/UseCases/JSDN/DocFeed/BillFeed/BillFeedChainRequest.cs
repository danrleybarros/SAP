using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.BillFeed
{
    /// <summary>
    /// Extends de DocFeed and Add Invoices propertie that is specific to BillFeed. 
    /// </summary>
    public class BillFeedChainRequest : DocFeedRequest
    {
        public List<Invoice> Invoices { get; private set; }
        public List<BillFeedDoc> BillFeedDocs { get; set; }
        public int ReturnValue { get; set; }

        public BillFeedChainRequest(DocFeedRequest request)
        {
            Base64String = request.Base64String;
            File = request.File;
            DocFeed = request.DocFeed;
            Invoices = new List<Invoice>();
            BillFeedDocs = new List<BillFeedDoc>();
            Logs = request.Logs;
            ReturnValue = 1;
        }

        public int SplitBillFeedDocs()
        {
            Invoices = GetInvoicesFromBillFeedDoc(this.BillFeedDocs);
            Services = GetServicesFromBillFeedDoc(this.BillFeedDocs);

            return Invoices.Count();
        }

        #region Methods to Split BillFeedDoc
        public List<Invoice> GetInvoicesFromBillFeedDoc(List<BillFeedDoc> billFeeds)
        {
            var cycleCode = billFeeds.FirstOrDefault(b => b.CycleCode.HasValue)?.CycleCode.Value;
            var limitBillToDate = new DateTime(cycleCode.Value.Year, cycleCode.Value.Month, 26);


            var invoices = billFeeds.GroupBy(x => new { x.InvoiceNumber, x.StoreAcronym })
                .Select(g => new
                {
                    Invoices = g.Select(s => new Invoice(
                        s.IdFile,
                        g.Key.InvoiceNumber,
                        s.Marketplace,
                        s.ResellerName,
                        s.ResellerContactName,
                        s.ResellerEmailAddress,
                        s.ResellerPhoneNumber,
                        s.OrderId,
                        g.Where(ii => ii.BillFrom.HasValue).Min(a => a.BillFrom),
                        GetInvoiceBillTo(g, limitBillToDate),
                        s.InvoiceCreationDate,
                        s.StoreCode,
                        s.MarketplaceCity,
                        s.MarketplaceState,
                        s.Premeditateddefaulter,
                        s.CustomerTransactionCurrency,
                        g.Where(ii => !string.IsNullOrEmpty(ii.PaymentMethod)).Select(a => a.PaymentMethod).FirstOrDefault(),
                        s.PaymentStatus,
                        s.RefundType,
                        s.RefundAmount,
                        s.InvoiceStatus,
                        new Customer(
                            System.Guid.NewGuid(),
                            s.CompanyName,
                            s.CustomerCode,
                            s.AccountCreationDate,
                            s.FirstName,
                            s.LastName,
                            s.CustomerEmailAddress,
                            s.CustomerPhoneNumber,
                            s.BillingStreet,
                            s.BillingNumber,
                            s.BillingComplement,
                            s.BillingNeighbourhood,
                            s.BillingCity,
                            s.BillingStateOrProvince,
                            s.BillingZIPcode,
                            s.BillingCountry,
                            s.BillingCountryCode,
                            s.BillingPhoneNumber,
                            s.MailingStreet,
                            s.MailingNumber,
                            s.MailingComplement,
                            s.MailingNeighbourhood,
                            s.MailingCity,
                            s.MailingStateOrProvince,
                            s.MailingZIPcode,
                            s.MailingCountry,
                            s.MailingCountryCode,
                            s.MailingPhoneNumber,
                            s.CustomerCPF,
                            s.CustomerCNPJ,
                            s.CustomerStateRegistration,
                            s.UserAccountStatus,
                            s.IndividualInvoice,
                            null,
                            s.CnpjMarketPlace,
                            s.CompanyNameMarketPlace,
                            s.CustomerAcronym,
                            s.Segment,
                            s.CpfUserHasMadeCredit,
                            s.ProposalNumber,
                            s.AdabasCode,
                            s.OpportunityId,
                            s.QuoteId),
                        null,
                        s.CompanyCode,
                        s.AffiliateCode,
                        s.CityServiceCode,
                        s.CityHallServiceDescription,
                        s.SpecialProcedureNumber,                        
                        s.TotalInvoicePrice,
                        s.MunicipalTaxpayerRegistration,
                        g.FirstOrDefault(b => b.CycleCode != null)?.CycleCode,
                        g.Key.StoreAcronym
                        )).ToList()
                });
            return invoices.Select(x => x.Invoices.FirstOrDefault()).ToList();
        }

        private List<ServiceInvoice> GetServicesFromBillFeedDoc(List<BillFeedDoc> billFeedDocs)
        {
            return billFeedDocs.Select(s => new ServiceInvoice(
                        System.Guid.NewGuid(),
                        s.InvoiceNumber,
                        s.Sequence,
                        s.SubscriptionId,
                        s.Activity,
                        s.ServiceType,
                        s.OrderCreationDate,
                        s.PurchaseDate,
                        s.ActivationDate,
                        s.SubscriptionType,
                        s.TermStartDate,
                        s.TermEndDate,
                        s.TermDuration,
                        s.NextRenewalDate,
                        s.ServiceCancellationDate,
                        s.ServiceCode,
                        s.DueDate,
                        s.ServiceName,
                        s.OfferName,
                        s.OfferCode,
                        s.SalesReferenceCode,
                        s.UnitOfMeasure,
                        s.Qty,
                        s.ProRateScale,
                        s.RetailUnitPrice,
                        s.ProRatedRetailPriceUnitPrice,
                        s.GrossRetailPrice,
                        s.RetailPriceDiscount,
                        s.ProRatedRetailUnitDiscountedPriceAmount,
                        s.TotalRetailPriceDiscountAmount,
                        s.TotalRetailPrice,
                        s.TaxOnTotalRetailPrice,
                        s.GrandTotalRetailPrice,
                        s.PromotionCode,
                        s.PromotionDuration,
                        s.WholesaleUnitPrice,
                        s.ProRatedWholesaleUnitPrice,
                        s.VendorCurrency,
                        s.GrossWholesalePrice,
                        s.WholesalePriceDiscount,
                        s.ProRatedWholesaleUnitDiscountedPriceAmount,
                        s.TotalWholesalePriceDiscountAmount,
                        s.TotalWholesalePrice,
                        s.TaxOnTotalWholesalePrice,
                        s.GrandTotalWholesalePrice,
                        s.VendorName,
                        s.VendorUnitPrice,
                        s.ProRatedVendorUnitPrice,
                        s.TotalVendorPrice,
                        s.TaxOnTotalVendorPrice,
                        s.GrandTotalVendorPrice,
                        s.BillingCycle,
                        s.ProrateType,
                        s.ProrateOnCancellation,
                        s.UsageAttributes,
                        s.ResourceId,
                        s.ChargeType,
                        null,
                        s.TaxRateISS,
                        s.TotalTaxISS,
                        s.TaxRateCOFINS,
                        s.TotalTaxCOFINS,
                        s.TaxRatePIS,
                        s.TotalTaxPIS,
                        s.CycleReference,
                        s.FinancialStatus,
                        s.CommentsCredited,
                        s.Receivable,
                        s.TotalRetailPriceWithTaxesWithoutDiscount,
                        s.ServiceProviderCompanyName,
                        s.CNPJServiceProviderCompany,
                        s.StoreAcronymServiceProvider
                        )).ToList();
        }

        private DateTime GetInvoiceBillTo(IGrouping<object, BillFeedDoc> g, DateTime limitDate)
        {
            var activitiesToAvoid = new List<string> { "credits", "fines", "interest", "payment credit", "contractual fine" };
            DateTime baseBillTo = g.Max(ii => ii.BillTo).Value;
            DateTime billFrom = g.Where(ii => ii.BillFrom.HasValue).Min(a => a.BillFrom).Value;

            if (g.Any(ii => !activitiesToAvoid.Contains(ii.Activity.ToLower()) && ii.BillTo.HasValue))
            {
                baseBillTo = g.Where(ii => ii.BillTo.HasValue && !activitiesToAvoid.Contains(ii.Activity.ToLower())).Max(a => a.BillTo.Value);
                billFrom = g.Where(ii => ii.BillFrom.HasValue && !activitiesToAvoid.Contains(ii.Activity.ToLower())).Min(a => a.BillFrom).Value;
            }

            return GetValidInvoiceBillTo(baseBillTo, billFrom, limitDate);
        }

        private DateTime GetValidInvoiceBillTo(DateTime billTo, DateTime billFrom, DateTime limitDate)
        {
            if (billTo > limitDate)
                return limitDate;

            if (billTo > billFrom.AddMonths(1).AddDays(-1))
                return billFrom.AddMonths(1).AddDays(-1);

            return billTo;
        }

        #endregion
    }
}
