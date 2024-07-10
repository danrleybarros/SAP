using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public abstract class InterestServicesHandler : Handler
    {
        protected abstract List<string> activities { get; }
        protected abstract List<string> usageAtrribute { get; }
        protected abstract string subscriptionType { get; }

        private readonly IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository;

        protected InterestServicesHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository)
        {
            this.serviceReadOnlyRepository = serviceReadOnlyRepository;
        }

        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Getting Interest Services - FAT");

            var invoices = request.Invoices.Select(s => s.InvoiceNumber).ToList();

            request.InterestServices.AddRange(serviceReadOnlyRepository.GetServicesByActivityAndUsageAttributes(invoices, activities, usageAtrribute, subscriptionType));

            request.InterestServices.ForEach(e =>
            {
                e.Invoice = request.Invoices.Where(f => f.InvoiceNumber == e.InvoiceNumber).FirstOrDefault();
            });

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
