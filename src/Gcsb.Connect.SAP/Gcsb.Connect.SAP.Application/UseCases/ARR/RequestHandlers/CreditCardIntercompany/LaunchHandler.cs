using Gcsb.Connect.Pkg.Datamart.Domain.EndUser;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCardIntercompany
{
    public class LaunchHandler : Handler<ARRCreditCardInter>, ILaunchHandler<ARRCreditCardInter>
    {
        public override void ProcessRequest(IARRRequest<ARRCreditCardInter> request)
        {
            request.AddProcessingLog("Start processing ARR Intercompany - LaunchHandler");

            var providerStores = request.Services.Where(s => s.ProviderCompanyAcronym != s.Invoice.StoreAcronym).Select(s => s.ProviderCompanyAcronym).Distinct().ToList();

            request.Lines = new Dictionary<StoreType, List<LaunchItem>>();

            providerStores.ForEach(provider =>
            {
                var providerType = Domain.Util.ToEnum<StoreType>(provider);
                var invoices = request.Services.Where(w => w.ProviderCompanyAcronym == provider).Select(s => s.Invoice.InvoiceNumber).Distinct().ToList();
                var payments = request.paymentCreditCards.Where(w => invoices.Contains(w.InvoiceNumberJsdn)).ToList();
                var paymentReports = request.PaymentReports.Where(w => invoices.Contains(w.InvoiceNumber) && w.ProviderCompanyAcronym == provider).ToList();

                var AccountingEntriesArrecadacao = request.AccountsARR.Where(w => w.Provider == providerType && w.ValidAccount == true).ToList();

                var paymentsAccounts = paymentReports
                .Join(AccountingEntriesArrecadacao,
                    p => new { invoiceNumber = p.InvoiceNumber, serviceCode = p.ServiceCode, storeAcronym = Domain.Util.ToEnum<StoreType>(p.StoreAcronym) },
                    a => new { invoiceNumber = a.InvoiceNumber, serviceCode = a.ServiceCode, storeAcronym = a.Store }, (p, a) => new { p, a })
                .Select(s => new {
                    s.p.InvoiceNumber,
                    s.p.StoreAcronym,
                    s.p.ProviderCompanyAcronym,
                    s.p.PaymentDate,
                    s.p.PaymentValue,
                    s.a.ArrecadacaoARR,
                    s.a.AccountingEntryType,
                    s.a.AccountingAccount,
                    s.a.HaveIntercompany
                }).ToList();

                var launchs = paymentsAccounts
                .GroupBy(g => new { g.ProviderCompanyAcronym, g.AccountingEntryType })
                .Select((s, index) => new LaunchItem(
                    index + 1,
                    s.FirstOrDefault().PaymentDate,
                    s.FirstOrDefault().ArrecadacaoARR,
                    s.Sum(sum => sum.PaymentValue),
                    "",
                    "GP",
                    "",
                    s.Key.AccountingEntryType,
                    s.FirstOrDefault().AccountingAccount))
                .ToList();
                
                request.Lines.Add(providerType, launchs);
            });

            sucessor?.ProcessRequest(request);
        }
    }
}
