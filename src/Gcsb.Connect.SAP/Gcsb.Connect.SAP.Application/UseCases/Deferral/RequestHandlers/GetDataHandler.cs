using System;
using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.SAP.Application.Boundaries.Deferral;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Deferral;
using Gcsb.Connect.SAP.Domain.Deferral;
using Gcsb.Connect.SAP.Domain.JSDN;

namespace Gcsb.Connect.SAP.Application.UseCases.Deferral.RequestHandlers
{
    public class GetDataHandler : Handler
    {
        private readonly IDatamartService datamartService;
        private readonly IBillFeedReadOnlyRepository billFeedReadOnlyRepository;
        private readonly IDeferralOfferReadOnlyRepository deferralOfferReadOnlyRepository;

        public GetDataHandler(IDatamartService datamartService, IBillFeedReadOnlyRepository billFeedReadOnlyRepository, IDeferralOfferReadOnlyRepository deferralOfferReadOnlyRepository)
        {
            this.datamartService = datamartService;
            this.billFeedReadOnlyRepository = billFeedReadOnlyRepository;
            this.deferralOfferReadOnlyRepository = deferralOfferReadOnlyRepository;
        }

        public override void ProcessRequest(DeferralRequest request)
        {
            request.AddProcessingLog("Getting data from deferral offers");

            var configDeferralOffers = datamartService.GetAllDeferralOffers();

            if (configDeferralOffers.Any())
            {
                var recurringDeferralOffers = deferralOfferReadOnlyRepository.Get(d => d.DeferralStatus == DeferralStatus.InProgress);

                var listOfferCode = configDeferralOffers.Select(s => s.OfferCode).Distinct().ToList();

                var billFeeds = billFeedReadOnlyRepository.GetBillFeed(b => listOfferCode.Contains(b.OfferCode) && b.IdFile.Equals(request.IdBillfeed));
                var billCycleDate = billFeedReadOnlyRepository.GetCycleByBillFeedId(request.IdBillfeed);

                FillProvisionRecurringDeferralOffersInvoiceNumber(recurringDeferralOffers.Where(d=> d.IsProvisioned).ToList(), billFeeds);

                var provisionDeferralInvoiceNumbers = recurringDeferralOffers.Where(o => o.IsProvisioned)
                                                                             .Select(p => p.InvoiceNumber)
                                                                             .ToList();

                var newDeferralOffers = billFeeds.Where(b => !provisionDeferralInvoiceNumbers.Contains(b.InvoiceNumber))
                    .Join(configDeferralOffers, b => b.OfferCode, o => o.OfferCode, (billfeed, configOffer) => new { billfeed, configOffer })
                    .GroupBy(g => new { g.billfeed.CustomerCode, g.billfeed.InvoiceNumber, g.billfeed.OfferCode })
                    .Select(s => CreateDeferralOffer(s.FirstOrDefault()?.configOffer, s.Sum(b => b.billfeed.GrandTotalRetailPrice ?? 0), billFeed: s.FirstOrDefault()?.billfeed)).ToList();


                request.DeferralOffers.AddRange(newDeferralOffers);
                request.DeferralOffers.AddRange(recurringDeferralOffers);

                if (billCycleDate?.BillFrom != null && billCycleDate?.BillTo != null)
                {
                    var ordersJsdn = datamartService.GetOrderByCycle(billCycleDate.BillFrom, billCycleDate.BillTo);
                    var notOrdersBillFeed = ordersJsdn.Where(w => !billFeeds.Any(s => s.OrderId == w.OrderId)).ToList();
                    var newProvisionDeferralOffers = notOrdersBillFeed
                        .Join(configDeferralOffers, b => b.OfferCode, o => o.OfferCode, (order, configOffer) => new { order, configOffer })
                        .GroupBy(g => new { g.order.CustomerCode, g.order.OfferCode, g.order.OrderId })
                        .Select(s => CreateDeferralOffer(s.FirstOrDefault().configOffer, s.Sum(m=> m.order.TotalOrderPrice), orderJsdn: s.FirstOrDefault().order)).ToList();

                    request.DeferralOffers.AddRange(newProvisionDeferralOffers);
                }
                else
                    request.AddProcessingLog($"There weren't valid data filters to execute provision 'BillFrom': {billCycleDate?.BillFrom} 'BillTo': {billCycleDate?.BillTo}");

                sucessor?.ProcessRequest(request);
            }
            else
                request.AddProcessingLog("There weren't offers configured on Plataform for deferral");

        }

        private void FillProvisionRecurringDeferralOffersInvoiceNumber(List<DeferralOffer> provisionDeferralOffers, List<BillFeedDoc> billFeeds)
        {
            provisionDeferralOffers.ForEach(p =>
            {
                var provisionBillfeedLine = billFeeds.Where(b => b.OrderId == p.OrderNumber &&
                                                                 b.CustomerCode == p.CustomerCode &&
                                                                 b.OfferCode == p.OfferCode).FirstOrDefault();

                if (provisionBillfeedLine != null)
                {
                    p.SetInvoiceNumber(provisionBillfeedLine.InvoiceNumber);
                }
            });
        }

        private DeferralOffer CreateDeferralOffer(ConfigDeferralOffer configDeferralOffer, double totalService, BillFeedDoc billFeed = null, Order orderJsdn = null)
        {     
            return new DeferralOffer(
                Guid.NewGuid(),
                billFeed?.CycleCode?.ToString() ?? orderJsdn.OrderDate.ToString(),
                billFeed?.ServiceCode ?? orderJsdn.ServiceCode,
                billFeed?.OfferCode ?? orderJsdn.OfferCode,
                billFeed?.CustomerCode ?? orderJsdn.CustomerCode ,
                billFeed?.OrderId ?? orderJsdn.OrderId ,
                billFeed?.StoreAcronymServiceProvider ?? orderJsdn?.StoreAcronymServiceProvider ?? orderJsdn.StoreAcronym ,            
                billFeed?.InvoiceNumber ?? string.Empty,
                billFeed?.StoreAcronym ?? orderJsdn.StoreAcronym ,
                billFeed?.BillingStateOrProvince ?? orderJsdn.BillingStateOrProvince,
                billFeed?.PaymentMethod ?? orderJsdn.PaymentMethod,
                billFeed?.ServiceType ?? orderJsdn.ServiceType,
                totalService,
                configDeferralOffer.NumberOfInstallments,
                DateTime.UtcNow,
                billFeed?.PurchaseDate ?? orderJsdn.OrderDate,
                DateTime.UtcNow,
                billFeed?.TotalRetailPriceDiscountAmount.GetValueOrDefault() > 0 ? true : false,
                billFeed is null ? true : false,
                DeferralStatus.New,
                int.Parse(configDeferralOffer.ContractPeriod.Split(" ")[0]),
                billFeed?.IdFile);
        }
    }
}

