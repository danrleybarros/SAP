using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public abstract class ServicesHandler : Handler
    {
        protected abstract List<string> activities { get; }
        protected abstract List<string> usageAtrribute { get; }
        protected abstract string subscriptionType { get; }

        private readonly IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository;

        public ServicesHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository)
        {
            this.serviceReadOnlyRepository = serviceReadOnlyRepository;
        }

        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Consulting Services - FAT");
            request.Services = new List<Domain.JSDN.ServiceFilter>();

            var states = request.Invoices.Select(p => p.Customer.BillingStateOrProvince).Distinct().ToList();
            var invoices = request.Invoices.Where(s => states.Contains(s.Customer.BillingStateOrProvince)).Select(s => s.InvoiceNumber).ToList();
            var services = serviceReadOnlyRepository.GetServicesWithoutActivity(invoices, activities, subscriptionType);

            services.ForEach(e =>
            {
                e.Invoice = request.Invoices.Where(f => f.InvoiceNumber == e.InvoiceNumber).FirstOrDefault();
                e.TotalDiscount = e.GetLaunchAmount(true, true);
            });

            request.Services.AddRange(services);

            sucessor?.ProcessRequest(request);
        }
    }
}
