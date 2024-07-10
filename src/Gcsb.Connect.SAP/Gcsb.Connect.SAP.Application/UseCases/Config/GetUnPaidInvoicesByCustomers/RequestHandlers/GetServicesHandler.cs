using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetUnPaidInvoicesByCustomers.RequestHandlers
{
    public class GetServicesHandler : Handler<GetUnPaidInvoicesByCustomersRequest>
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository;

        public GetServicesHandler(IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnlyRepository)
        {
            this.serviceInvoiceReadOnlyRepository = serviceInvoiceReadOnlyRepository;
        }

        public override void ProcessRequest(GetUnPaidInvoicesByCustomersRequest request)
        {
            var invoices = request.Invoices.Select(s => s.InvoiceNumber).ToList();
            var ignoreActivities = new List<string>() { "credits", "arrear", "fines", "interest", "payment credit", "contractual fine" };

            request.Services = serviceInvoiceReadOnlyRepository.GetServices(w => invoices.Contains(w.InvoiceNumber) && !ignoreActivities.Contains(w.Activity.ToLower()));

            sucessor?.ProcessRequest(request);
        }
    }
}
