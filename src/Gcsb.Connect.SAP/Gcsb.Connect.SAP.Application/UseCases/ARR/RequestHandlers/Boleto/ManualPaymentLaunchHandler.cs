using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.Pay;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.ARR.Boleto;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.Boleto
{
    public class ManualPaymentLaunchHandler : Handler<ARRBoleto>, IManualPaymentLaunchHandler<ARRBoleto>
    {
        private readonly IServicePay servicePay;
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public ManualPaymentLaunchHandler(IServicePay servicePay,
            IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.servicePay = servicePay;
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(IARRRequest<ARRBoleto> request)
        {
            request.AddProcessingLog("Consulting Manual Payment in PAY - ARR Boleto");

            var invoiceNumbers = request.paymentBoletos.Select(s => s.InvoiceNumberJsdn).Distinct().ToList();
            var paidInvoices = servicePay.GetInvoicePayment(invoiceNumbers);

            var invoices = invoiceReadOnlyRepository.GetInvoices(i => invoiceNumbers.Contains(i.InvoiceNumber));
            var stores = invoices.Select(i => i.StoreAcronym).Distinct().ToList();

            stores.ForEach(store =>
            {
                var storeInvoices = invoices.Where(i => i.StoreAcronym.Equals(store)).Select(s => s.InvoiceNumber).Distinct().ToList();
                var storeType = Domain.Util.ToEnum<StoreType>(store);
                var lineCount = request.Lines.FirstOrDefault(l => l.Key.Equals(storeType)).Value?.Count ?? 0;

                var paidInvoicesByLoja = paidInvoices.Where(f => f.Credit > 0 && storeInvoices.Contains(f.InvoiceNumber)).ToList();

                if (paidInvoicesByLoja.Count > 0 && paidInvoicesByLoja.Any())
                {
                    var accountingAccounts = request.AccountingUnassignedEntriesArrecadacao.Where(a => a.Store.Equals(storeType)).ToList();
                    var paymentBoletosByLoja = request.paymentBoletos.Where(f => storeInvoices.Contains(f.InvoiceNumberJsdn)).ToList();

                    var manualPaymentLaunchItems = paidInvoicesByLoja
                        .GroupJoin(paymentBoletosByLoja, pay => pay.InvoiceNumber, payment => payment.InvoiceNumberJsdn, (pay, payment) => new
                        {
                            CodigoBanco = payment.Select(s => s.CodigoBanco).FirstOrDefault(),
                            DateProcessing = payment.Select(s => s.DateProcessing).FirstOrDefault(),
                            Credit = pay.Credit
                        }).GroupBy(g => new { g.CodigoBanco })
                        .Select(t => new
                        {
                            DateProcesssing = t.Select(m => m.DateProcessing).First(),
                            CodigoBanco = t.Key.CodigoBanco.ToString().PadLeft(3, '0'),
                            Credit = t.Sum(m => m.Credit)
                        })
                        .SelectMany(m => accountingAccounts, (ser, ae) => new { ser, ae })
                        .Select((l) => new LaunchItem(
                            ++lineCount,
                            l.ser.DateProcesssing,
                            l.ae.ArrecadacaoARR,
                            l.ser.Credit,
                            "",
                            $"BCO{l.ser.CodigoBanco}",
                            "",
                            l.ae.AccountingEntryType,
                            l.ae.AccountingAccount))
                        .ToList();

                    request.AddLaunchs(storeType, manualPaymentLaunchItems);
                }
            });

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
