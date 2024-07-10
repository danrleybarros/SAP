using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook.RequestHandlers
{
    public class GetInvoiceHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;

        public GetInvoiceHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
        }

        public override void ProcessRequest(AxiliaryBookRequest request)
        {          
            request.AddProcessingLog("Consulting Invoices on database");

            request.Invoices = invoiceReadOnlyRepository.GetInvoicesFromIdFileReturnNF(request.IdFileReturnNF);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
