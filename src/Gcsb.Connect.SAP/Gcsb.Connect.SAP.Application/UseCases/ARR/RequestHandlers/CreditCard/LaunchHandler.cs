using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCard
{
    public class LaunchHandler : Handler<ARRCreditCard>, ILaunchHandler<ARRCreditCard>
    {
        public override void ProcessRequest(IARRRequest<ARRCreditCard> request)
        {            
            request.AddProcessingLog("Start processing ARR - LaunchHandler");

            var stores = request.Services.Select(s => s.Invoice.StoreAcronym).Distinct().ToList();

            request.Lines = new Dictionary<StoreType, List<LaunchItem>>();

            stores.ForEach(store =>
            {
                var storeType = Domain.Util.ToEnum<StoreType>(store);
                var invoices = request.Services.Where(w => w.Invoice.StoreAcronym.Equals(store)).Select(s => s.Invoice.InvoiceNumber).Distinct().ToList();
                var payments = request.paymentCreditCards.Where(w => invoices.Contains(w.InvoiceNumberJsdn)).ToList();
                var paymentReports = request.PaymentReports.Where(w => invoices.Contains(w.InvoiceNumber) && w.StoreAcronym == store).ToList();
                                
                var AccountingEntriesArrecadacao = request.AccountsARR.Where(w => w.Store == storeType && w.ValidAccount == true).ToList();
                
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

                var launchs = paymentsAccounts.Where(w => w.HaveIntercompany == false)
                .GroupBy(g => new { g.StoreAcronym, g.AccountingEntryType })
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

                launchs.AddRange(paymentsAccounts.Where(w => w.HaveIntercompany == true)
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
                .ToList());

                request.Lines.Add(storeType, launchs);                
            });
         
            sucessor?.ProcessRequest(request);
        }
    }
}
