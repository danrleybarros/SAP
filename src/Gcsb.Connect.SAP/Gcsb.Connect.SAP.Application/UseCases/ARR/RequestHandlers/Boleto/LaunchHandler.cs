using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.ARR.Boleto;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.Boleto
{
    public class LaunchHandler : Handler<ARRBoleto>, ILaunchHandler<ARRBoleto>
    {
        public override void ProcessRequest(IARRRequest<ARRBoleto> request)
        {
            var stores = request.Services.Select(s => s.Invoice.StoreAcronym).Distinct().ToList();

            request.AddProcessingLog("Start processing ARR Boleto - LaunchHandler");
            request.Lines = new Dictionary<StoreType, List<LaunchItem>>();

            stores.ForEach(store =>
            {
                var storeType = Domain.Util.ToEnum<StoreType>(store);
                var invoices = request.Services.Where(w => w.Invoice.StoreAcronym.Equals(store)).Select(s => s.Invoice.InvoiceNumber).Distinct().ToList();
                var payments = request.paymentBoletos.Where(w => invoices.Contains(w.InvoiceNumberJsdn)).ToList();
                var paymentReports = request.PaymentReports.Where(w => invoices.Contains(w.InvoiceNumber) && w.StoreAcronym == store).ToList();

                var accountsARR = request.AccountsARR.Where(w => w.Store == storeType && w.HaveIntercompany == true && w.ValidAccount == true).ToList();
                var AccountingEntriesArrecadacao = request.AccountingEntriesArrecadacao.Where(w => w.Store == storeType && w.HaveIntercompany == false).ToList();

                var paymentsAccounts = paymentReports
                    .Join(accountsARR,
                        p => new { invoiceNumber = p.InvoiceNumber, serviceCode = p.ServiceCode, storeAcronym = Domain.Util.ToEnum<StoreType>(p.StoreAcronym), providerCompanyAcronym = Domain.Util.ToEnum<StoreType>(p.ProviderCompanyAcronym) },
                        a => new { invoiceNumber = a.InvoiceNumber, serviceCode = a.ServiceCode, storeAcronym = a.Store, providerCompanyAcronym = a.Provider }, (p, a) => new { p, a })
                    .Select(s => new {
                        s.a.InvoiceNumber,
                        s.p.StoreAcronym,
                        s.p.ProviderCompanyAcronym,
                        BankCode = string.IsNullOrEmpty(s.p.BankCode) ? payments.Where(w => w.InvoiceNumberJsdn == s.p.InvoiceNumber).Select(s => s.CodigoBanco.ToString()).FirstOrDefault() : s.p.BankCode,
                        s.p.PaymentDate,
                        s.p.PaymentValue,
                        s.a.ArrecadacaoARR,
                        s.a.AccountingEntryType,
                        s.a.AccountingAccount                        
                    }).ToList();

                /*Sim Imtercompany*/
                var ARRBoleto = payments
                    .GroupBy(g => g.CodigoBanco)
                    .SelectMany(sm => AccountingEntriesArrecadacao, (pay, account) => new { pay, account })
                    .Select(s => new 
                    {
                        launchDate = s.pay.FirstOrDefault().DateProcessing,
                        financialAccount = s.account.ArrecadacaoARR,
                        launchValue = s.pay.Sum(sum => sum.ValorRecebido),
                        type = $"BCO{s.pay.Key.ToString().PadLeft(3, '0')}",                        
                        accountingEntry = s.account.AccountingEntryType,
                        accountingAccount = s.account.AccountingAccount
                    }).ToList();

                /*Com Imtercompany*/
                ARRBoleto.AddRange(paymentsAccounts
                    .GroupBy(g => new { g.ProviderCompanyAcronym, g.BankCode, g.AccountingEntryType })
                    .Select(s => new
                    {
                        launchDate = s.FirstOrDefault().PaymentDate,
                        financialAccount = s.FirstOrDefault().ArrecadacaoARR,
                        launchValue = s.Sum(sum => sum.PaymentValue),
                        type = $"BCO{s.Key.BankCode.PadLeft(3, '0')}",
                        accountingEntry = s.Key.AccountingEntryType,
                        accountingAccount = s.FirstOrDefault().AccountingAccount
                    }).ToList());

                var launchs = ARRBoleto
                    .Select((s, index) => new LaunchItem(
                        index + 1,
                        s.launchDate,
                        s.financialAccount,
                        s.launchValue,
                        "",
                        s.type,
                        "",
                        s.accountingEntry,
                        s.accountingAccount))
                    .ToList();

                var launchCount = launchs.Count;

                request.Criticals.ForEach(c =>
                {
                    c.LineNumber = ++launchCount;
                });

                launchs.AddRange(request.Criticals);

                request.Lines.Add(storeType, launchs);
            });

            sucessor?.ProcessRequest(request);
        }
    }
}
