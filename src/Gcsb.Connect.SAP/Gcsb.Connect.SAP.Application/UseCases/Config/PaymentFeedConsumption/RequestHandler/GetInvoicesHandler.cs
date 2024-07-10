using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeedConsumption.RequestHandler
{
    public class GetInvoicesHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;
        private readonly IBillFeedReadOnlyRepository billFeedReadOnlyRepository;

        public GetInvoicesHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository, IBillFeedReadOnlyRepository billFeedReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
            this.billFeedReadOnlyRepository = billFeedReadOnlyRepository;
        }

        public override void ProcessRequest(PaymentfeedConsumptionRequest request)
        {
            var invoicesNumber = new List<string>();

            invoicesNumber.AddRange(request.PaymentsBoleto.Select(s => s.InvoiceNumberJsdn).ToList());
            invoicesNumber.AddRange(request.PaymentsCredit.Select(s => s.InvoiceNumberJsdn).ToList());

            if (invoicesNumber.Count > 0)
                request.Invoices.AddRange(invoiceReadOnlyRepository.GetInvoices(s => invoicesNumber.Distinct().Contains(s.InvoiceNumber)));

            foreach (var invoice in request.Invoices)
            {
                if (invoice.CycleCode == null)
                {
                    invoice.CycleCode = billFeedReadOnlyRepository.GetBillFeed(w => w.IdFile == invoice.IdFile && w.CycleCode != null).FirstOrDefault().CycleCode;
                }
            } 

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
