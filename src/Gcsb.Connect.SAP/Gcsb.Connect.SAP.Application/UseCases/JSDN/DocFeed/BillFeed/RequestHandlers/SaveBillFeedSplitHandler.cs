using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.BillFeed.RequestHandlers
{
    public class SaveBillFeedSplitHandler : Handler<BillFeedChainRequest>
    {
        private readonly IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository;
        private readonly IServiceInvoiceWriteOnlyRepository serviceInvoiceWriteOnlyRepository;     

        public SaveBillFeedSplitHandler(IInvoiceWriteOnlyRepository invoiceWriteOnlyRepository, IServiceInvoiceWriteOnlyRepository serviceInvoiceWriteOnlyRepository)
        {
            this.invoiceWriteOnlyRepository = invoiceWriteOnlyRepository;
            this.serviceInvoiceWriteOnlyRepository = serviceInvoiceWriteOnlyRepository;           
        }

        public override void ProcessRequest(BillFeedChainRequest request)
        {
            request.AddProcessingLog("BillFeed Ingest", "Saving BillFeed Split (Invoices, customers and services)", request.File.Id);

            invoiceWriteOnlyRepository.Add(request.Invoices);
            serviceInvoiceWriteOnlyRepository.Add(request.Services);

            sucessor?.ProcessRequest(request);
        }
    }
}
