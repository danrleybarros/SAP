using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetDetailServiceByInvoice.RequestHandlers
{
    public class GetServiceInvoiceHandler : Handler
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository;

        public GetServiceInvoiceHandler(IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository)
        {
            this.serviceInvoiceReadOnlyRepository = serviceInvoiceReadOnlyRepository;
        }

        public override void ProcessRequest(GetDetailServiceByInvoiceRequest request)
        {
            request.ServiceInvoices = serviceInvoiceReadOnlyRepository.GetServices(w => request.InvoicesNumber.Contains(w.InvoiceNumber));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
