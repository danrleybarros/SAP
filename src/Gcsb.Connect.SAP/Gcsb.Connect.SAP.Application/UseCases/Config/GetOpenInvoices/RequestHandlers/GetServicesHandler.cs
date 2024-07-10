using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices.RequestHandlers
{
    public class GetServicesHandler : Handler<GetOpenInvoicesRequest>
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository;

        public GetServicesHandler(IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository)
        {
            this.serviceInvoiceReadOnlyRepository = serviceInvoiceReadOnlyRepository;
        }

        public override void ProcessRequest(GetOpenInvoicesRequest request)
        {
            var invoices = request.Invoices.Select(s => s.InvoiceNumber).ToList();

            request.Services = serviceInvoiceReadOnlyRepository.GetServices(w => invoices.Contains(w.InvoiceNumber));

            sucessor?.ProcessRequest(request);
        }
    }
}
