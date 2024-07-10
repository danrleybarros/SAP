using System;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.Messaging.Messages.Log;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers
{
    public class GetInvoicesHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoicesHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(ItemsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Object request is null");
            
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Initiating processing to generate items interface"));
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Getting invoices by individual invoice = S"));
            request.Invoices = invoiceReadOnlyRepository.GetInvoicesFromIdFileReturnNF(request.IdNFFile);
            
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
