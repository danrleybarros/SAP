using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.RequestHandlers
{
    public class GetInvoiceCycleHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoiceCycleHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(CounterchargeDisputeRequest request)
        {
            request.AddProcessingLog("Getting cycle of invoices where the field is null on datamart");

            var invoiceNumbers = request.CounterchargeDisputesAdjustment.Where(a => a.CicloNulo).Select(a => a.NumeroFatura).ToList();
            invoiceNumbers.AddRange(request.CounterchargeDisputesBilling.Where(b => b.CicloNulo).Select(b => b.NumeroFatura).ToList());

            var invoices = invoiceReadOnlyRepository.GetInvoices(i => i.CycleCode != null && invoiceNumbers.Distinct().Contains(i.InvoiceNumber));

            invoices.ForEach(invoice =>
            {
                request.CounterchargeDisputesAdjustment.Where(a => a.CicloNulo && a.NumeroFatura == invoice.InvoiceNumber).ToList()
                    .ForEach(a => a.SetCycle(invoice.CycleCode.Value));

                request.CounterchargeDisputesBilling.Where(b => b.CicloNulo && b.NumeroFatura == invoice.InvoiceNumber).ToList()
                    .ForEach(b => b.SetCycle(invoice.CycleCode.Value));
            });

            sucessor?.ProcessRequest(request);
        }
    }
}
