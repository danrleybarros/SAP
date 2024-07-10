using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.ARR.ARRBoletoIntercompany;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.BoletoIntercompany
{
    public class LaunchHandler : Handler<ARRBoletoInter>, ILaunchHandler<ARRBoletoInter>
    {
        public override void ProcessRequest(IARRRequest<ARRBoletoInter> request)
        {
            var providerStores = request.Services.Where(s => s.ProviderCompanyAcronym != s.Invoice.StoreAcronym).Select(s => s.ProviderCompanyAcronym).Distinct().ToList();

            request.AddProcessingLog("Start processing ARR Boleto Intercompany - LaunchHandler");
            request.Lines = new Dictionary<StoreType, List<LaunchItem>>();

            providerStores.ForEach(provider =>
            {
                var providerType = Domain.Util.ToEnum<StoreType>(provider);
                var invoices = request.Services.Where(w => w.ProviderCompanyAcronym == provider).Select(s => s.Invoice.InvoiceNumber).Distinct().ToList();
                var payments = request.paymentBoletos.Where(w => invoices.Contains(w.InvoiceNumberJsdn)).ToList();
                var paymentReports = request.PaymentReports.Where(w => invoices.Contains(w.InvoiceNumber) && w.ProviderCompanyAcronym == provider).ToList();

                var AccountingEntriesArrecadacao = request.AccountsARR.Where(w => w.Provider == providerType && w.ValidAccount == true).ToList();

                var paymentsAccounts = paymentReports
                .Join(AccountingEntriesArrecadacao,
                    p => new { invoiceNumber = p.InvoiceNumber, serviceCode = p.ServiceCode, storeAcronym = Domain.Util.ToEnum<StoreType>(p.StoreAcronym), providerCompanyAcronym = Domain.Util.ToEnum<StoreType>(p.ProviderCompanyAcronym) },
                    a => new { invoiceNumber = a.InvoiceNumber, serviceCode = a.ServiceCode, storeAcronym = a.Store, providerCompanyAcronym = a.Provider }, (p, a) => new { p, a })
                .Select(s => new {   
                    s.a.InvoiceNumber,
                    s.p.ProviderCompanyAcronym,
                    BankCode = string.IsNullOrEmpty(s.p.BankCode) ? payments.Where(w => w.InvoiceNumberJsdn == s.p.InvoiceNumber).Select(s => s.CodigoBanco.ToString()).FirstOrDefault() : s.p.BankCode,
                    s.p.PaymentDate,
                    s.p.PaymentValue,
                    s.a.ArrecadacaoARR,
                    s.a.AccountingEntryType,
                    s.a.AccountingAccount
                }).ToList();

                var launchs = paymentsAccounts
                .GroupBy(g => new { g.ProviderCompanyAcronym, g.BankCode, g.AccountingEntryType })
                .Select((s, index) => new LaunchItem(
                    index + 1,
                    s.FirstOrDefault().PaymentDate,
                    s.FirstOrDefault().ArrecadacaoARR,
                    s.Sum(sum => sum.PaymentValue),
                    "",
                    $"BCO{s.Key.BankCode.ToString().PadLeft(3, '0')}",
                    "",
                    s.Key.AccountingEntryType,
                    s.FirstOrDefault().AccountingAccount))
                .ToList();

                var launchCount = launchs.Count;

                request.Lines.Add(providerType, launchs);
            });

            sucessor?.ProcessRequest(request);
        }
    }
}
