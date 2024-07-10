using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Deferral;
using Gcsb.Connect.SAP.Application.Repositories.StatusActivationServices;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.DeferralHistoryBuilder;
using Gcsb.Connect.SAP.Domain.Deferral;
using Gcsb.Connect.SAP.Domain.JSDN;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH
{
    public class SaveDeferralHistoryHandler : Handler
    {
        private readonly IBillFeedReadOnlyRepository billFeedReadOnlyRepository;
        private readonly IDeferralHistoryRepository deferralHistoryRepository;
        public DateTime expirationDate;

        public SaveDeferralHistoryHandler(IBillFeedReadOnlyRepository billFeedReadOnlyRepository, IDeferralHistoryRepository deferralHistoryRepository)
        {
            this.billFeedReadOnlyRepository = billFeedReadOnlyRepository;
            this.deferralHistoryRepository = deferralHistoryRepository;           
        }

        public override void ProcessRequest(FATRequest request)
        {
            if (request.HasDeferral)
            {
                var deferralHistories = new List<DeferralHistory>();

                var invoiceNumbers = request.DeferralOffers.Select(o => o.InvoiceNumber).Distinct();
                var offerCodes = request.DeferralOffers.Select(o => o.OfferCode).Distinct();
                var customers = request.DeferralOffers.Select(o => o.CustomerCode).Distinct();
                var billfeedIds = request.DeferralOffers.Where(w => !w.IsProvisioned).Select(o => o.BillfeedFileId.Value).Distinct().ToList();

                billfeedIds.ForEach(billfeedId =>
                {
                    var billFeed = billFeedReadOnlyRepository.GetBillFeed(s => s.IdFile == billfeedId
                                                        && invoiceNumbers.Contains(s.InvoiceNumber)
                                                        && offerCodes.Contains(s.OfferCode)
                                                        && customers.Contains(s.CustomerCode));

                    deferralHistories.AddRange(
                        request.DeferralOffers.Join(billFeed, s => new { s.InvoiceNumber, s.ServiceCode, s.CustomerCode }, s => new { s.InvoiceNumber, s.ServiceCode, s.CustomerCode }, (deferralOffer, billfeed) => new { deferralOffer, billfeed })
                                      .GroupBy(g => new { g.billfeed.CustomerCode, g.billfeed.ServiceCode, g.billfeed.InvoiceNumber, g.billfeed.OrderId })
                                      .Select(s => CreateDeferralHistory(s.FirstOrDefault().deferralOffer,
                                                                         s.Sum(m => m.billfeed.GrandTotalRetailPrice ?? 0),
                                                                         s.Sum(m => m.billfeed.TotalRetailPrice ?? 0),
                                                                         request,
                                                                         s.FirstOrDefault().billfeed)).ToList());

                });

                deferralHistories.AddRange(
                    request.DeferralOffers.Where(w => w.IsProvisioned)
                                          .Select(o => CreateDeferralHistory(o,
                                                                             o.TotalBalance,
                                                                             0,
                                                                             request)).ToList());
              

                deferralHistoryRepository.Add(deferralHistories);
            }

            sucessor?.ProcessRequest(request);
        }

        public DeferralHistory CreateDeferralHistory(DeferralOffer deferralOffer, double grandTotalRetailPrice, double totalRetailPrice, FATRequest request, BillFeedDoc billFeed = null)
            => DeferralHistoryBuilder
                                .New()
                                .WithShortTerm(deferralOffer.NumberOfInstallments <= 12)
                                .WithIsProvision(deferralOffer.IsProvisioned)
                                .WithIsNFEmitted(deferralOffer.IsNFEmitted)
                                .WithIsActiveService(deferralOffer.IsActive)
                                .WithBillTo(billFeed?.BillTo)
                                .WithOrderId(deferralOffer.OrderNumber)
                                .WithOrderCreationDate(billFeed?.OrderCreationDate, deferralOffer.PurchaseDate)
                                .WithCompanyName(billFeed?.CompanyName)
                                .WithInvoiceNumber(deferralOffer.InvoiceNumber)
                                .WithServiceName(billFeed?.ServiceName)
                                .WithServiceCode(deferralOffer.ServiceCode)
                                .WithGrandTotalRetailPrice(grandTotalRetailPrice)
                                .WithTotalRetailPrice(totalRetailPrice)
                                .WithAccountingAccountBillingCredit(deferralOffer, request.AccountingAccounts)
                                .WithAccountingAccountBillingDebit(deferralOffer, request.AccountingAccounts)
                                .WithReceivable(billFeed?.Receivable)
                                .WithPaymentMethod(deferralOffer.PaymentMethod)
                                .WithInternalOrder(deferralOffer.BillingStateOrProvince, deferralOffer.StoreAcronym)
                                .WithActivationDate(billFeed?.ActivationDate.Value)
                                .WithServiceType(deferralOffer.ServiceType)
                                .WithProductStatus(deferralOffer.IsActive)
                                .WithExpirationDate(deferralOffer.ExpirationDate)
                                .WithFinancialAccount(deferralOffer, request.DeferralFinancialAccounts)
                                .WithDeferralAmount(deferralOffer.TotalBalance)
                                .WithNumberOfInstallments(deferralOffer.NumberOfInstallments)
                                .WithDeferralCycleCut(billFeed?.BillTo)
                                .WithDeferralDescriptionInstallment(deferralOffer.GetDescriptionInstallment())
                                .WithTotalShortBalance(deferralOffer.InstallmentAmount)
                                .WithAccountingAccountShortTermCreditTotal(deferralOffer, request.DeferralFinancialAccounts)
                                .WithAccountingAccountShortTermDebitTotal(deferralOffer, request.DeferralFinancialAccounts)
                                .WithTotalLongBalance(deferralOffer.InstallmentAmount)
                                .WithAccountingAccountLongTermCreditTotal(deferralOffer, request.DeferralFinancialAccounts)
                                .WithAccountingAccountLongTermDebitTotal(deferralOffer, request.DeferralFinancialAccounts)
                                .WithTransferShortBalanceToLongBalance(deferralOffer.GetTotalLongBalance())
                                .WithAccountingAccountLongTermCreditInstallment(deferralOffer, request.DeferralFinancialAccounts)
                                .WithAccountingAccountLongTermDebitInstallment(deferralOffer, request.DeferralFinancialAccounts)
                                .WithDeferralAmountProvision(deferralOffer.TotalBalance)
                                .WithDeferralAmountShortTermTotal(deferralOffer.TotalShortBalance)
                                .WithAccountingAccountShortTermDeferralCreditInstallment(deferralOffer, request.DeferralFinancialAccounts)
                                .WithAccountingAccountShortTermDeferralDebitInstallment(deferralOffer, request.DeferralFinancialAccounts)
                                .WithDeferralAmountLowProvisionShortTerm(deferralOffer.TotalShortBalance)
                                .WithAccountingAccountShortTermLowProvisionCredit(deferralOffer, request.DeferralFinancialAccounts)
                                .WithAccountingAccountShortTermLowProvisionDebit(deferralOffer, request.DeferralFinancialAccounts)
                                .WithDeferralAmountProvisionLongTerm(deferralOffer.TotalLongBalance)
                                .WithAccountingAccountLongTermProvisionCredit(deferralOffer, request.DeferralFinancialAccounts)
                                .WithAccountingAccountLongTermProvisionDebit(deferralOffer, request.DeferralFinancialAccounts)
                                .WithDeferralAmountLowProvisionLongTerm(deferralOffer.TotalLongBalance)
                                .WithAccountingAccountLongTermLowProvisionCredit(deferralOffer, request.DeferralFinancialAccounts)
                                .WithAccountingAccountLongTermLowProvisionDebit(deferralOffer, request.DeferralFinancialAccounts)
                                .WithContractDeadline(deferralOffer.ContractPeriod)
                                .WithDateStartedContract(billFeed?.TermStartDate)
                                .WithStoreAcronymServiceProvider(deferralOffer.ProviderStoreAcronym)
                                .WithCnpjServiceProviderCompany(billFeed?.CNPJServiceProviderCompany)
                                .WithDeferralType(deferralOffer.DeferralType)
                                .WithInclusionDate(DateTime.UtcNow)
                                .WithUf(deferralOffer.BillingStateOrProvince)
                                .Build();
    }
}
