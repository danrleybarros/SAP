using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.Messaging.Messages.Log;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Master.RequestHandlers
{
    public class GetInvoicesHandler : Handler<MasterRequest>, IGetInvoicesHandler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoicesHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(MasterRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Initiating processing to generate items interface"));
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Getting invoices by individual invoice = S"));

            request.Invoices = invoiceReadOnlyRepository.GetInvoicesFromIdFileReturnNF(request.IdNFFile).ToList();

            if (request.Invoices.Count == 0)
            {
                request.Logs.Add(Log.CreateProcessingLog(request.Service, "Not Found any Invoice registers - Master"));
                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}