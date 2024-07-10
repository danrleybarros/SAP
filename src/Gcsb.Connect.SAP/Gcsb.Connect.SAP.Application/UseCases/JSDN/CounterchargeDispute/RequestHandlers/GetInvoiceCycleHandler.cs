using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDispute.RequestHandlers
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
            var invoiceNumbers = request.CounterchargeDisputes.Where(a => a.CicloNulo).Select(a => a.NumeroFatura).ToList();
            var invoices = invoiceReadOnlyRepository.GetInvoices(i => i.CycleCode != null && invoiceNumbers.Distinct().Contains(i.InvoiceNumber));

            invoices.ForEach(invoice =>
            {
                request.CounterchargeDisputes.Where(d => d.CicloNulo && d.NumeroFatura == invoice.InvoiceNumber).ToList()
                    .ForEach(d => d.SetCycle(invoice.CycleCode.Value));
            });

            sucessor?.ProcessRequest(request);
        }
    }
}
