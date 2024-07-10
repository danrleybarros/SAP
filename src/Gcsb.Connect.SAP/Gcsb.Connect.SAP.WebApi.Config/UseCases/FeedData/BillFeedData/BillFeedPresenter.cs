using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.BillFeedData.BillFeedResponse;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.BillFeedData
{
    public class BillFeedPresenter : IOutputPort<List<BillFeedDoc>>
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);

        public void Standard(List<BillFeedDoc> billFeedDocs)
        {
            var listOutput = new List<OutputBillFeed>();

            billFeedDocs.ForEach(bill =>
            {
                listOutput.Add(new OutputBillFeed(bill.Marketplace, bill.ResellerName, bill.ResellerContactName, bill.ResellerEmailAddress, bill.ResellerPhoneNumber, bill.OrderId, bill.SubscriptionId,
                    bill.Activity, bill.ServiceType, bill.OrderCreationDate, bill.PurchaseDate, bill.ActivationDate, bill.SubscriptionType, bill.TermStartDate, bill.TermEndDate, bill.TermDuration,
                    bill.NextRenewalDate, bill.ServiceCancellationDate, bill.BillFrom, bill.BillTo, bill.CompanyName, bill.CustomerCode, bill.AccountCreationDate, bill.FirstName, bill.LastName,
                    bill.CustomerEmailAddress, bill.CustomerPhoneNumber, bill.BillingStreet, bill.BillingNumber, bill.BillingComplement, bill.BillingNeighbourhood, bill.BillingCity, bill.BillingStateOrProvince,
                    bill.BillingZIPcode, bill.BillingCountry, bill.BillingCountryCode, bill.BillingPhoneNumber, bill.MailingStreet, bill.MailingNumber, bill.MailingComplement, bill.MailingNeighbourhood,
                    bill.MailingCity, bill.MailingStateOrProvince, bill.MailingZIPcode, bill.MailingCountry, bill.MailingCountryCode, bill.MailingPhoneNumber, bill.CustomerCPF, bill.CustomerCNPJ,
                    bill.CustomerStateRegistration, bill.InvoiceCreationDate, bill.ServiceCode, bill.DueDate, bill.StoreCode, bill.MarketplaceCity, bill.MarketplaceState, bill.UserAccountStatus,
                    bill.Premeditateddefaulter, bill.ServiceName, bill.OfferName, bill.OfferCode, bill.SalesReferenceCode, bill.UnitOfMeasure, bill.Qty, bill.ProRateScale, bill.RetailUnitPrice,
                    bill.ProRatedRetailPriceUnitPrice, bill.GrossRetailPrice, bill.RetailPriceDiscount, bill.ProRatedRetailUnitDiscountedPriceAmount, bill.TotalRetailPriceDiscountAmount, bill.TotalRetailPrice,
                    bill.TaxOnTotalRetailPrice, bill.GrandTotalRetailPrice, bill.PromotionCode, bill.PromotionDuration, bill.WholesaleUnitPrice, bill.ProRatedWholesaleUnitPrice, bill.CustomerTransactionCurrency,
                    bill.VendorCurrency, bill.GrossWholesalePrice, bill.WholesalePriceDiscount, bill.ProRatedWholesaleUnitDiscountedPriceAmount, bill.TotalWholesalePriceDiscountAmount, bill.TotalWholesalePrice,
                    bill.TaxOnTotalWholesalePrice, bill.GrandTotalWholesalePrice, bill.VendorName, bill.VendorUnitPrice, bill.ProRatedVendorUnitPrice, bill.TotalVendorPrice,
                    bill.TaxOnTotalVendorPrice, bill.GrandTotalVendorPrice, bill.BillingCycle, bill.ProrateType, bill.ProrateOnCancellation, bill.UsageAttributes, bill.PaymentMethod,
                    bill.PaymentStatus, bill.RefundType, bill.RefundAmount, bill.InvoiceNumber, bill.ResourceId, bill.ChargeType, bill.InvoiceStatus, bill.IndividualInvoice,
                    bill.MunicipalTaxpayerRegistration, bill.CompanyCode, bill.AffiliateCode, bill.CityServiceCode, bill.CityHallServiceDescription, bill.SpecialProcedureNumber, bill.TaxRateISS,
                    bill.TotalTaxISS, bill.TaxRateCOFINS, bill.TotalTaxCOFINS, bill.TaxRatePIS, bill.TotalTaxPIS, bill.TotalInvoicePrice, bill.CnpjMarketPlace, bill.CompanyNameMarketPlace,
                    bill.CustomerAcronym, bill.Segment, bill.CycleCode, bill.CycleReference, bill.FinancialStatus, bill.CommentsCredited, bill.Receivable, bill.TotalRetailPriceWithTaxesWithoutDiscount, 
                    bill.StoreAcronym, bill.CNPJServiceProviderCompany, bill.ServiceProviderCompanyName, bill.StoreAcronymServiceProvider ));
            });

            ViewModel = new OkObjectResult(listOutput);
        }
    }
}
