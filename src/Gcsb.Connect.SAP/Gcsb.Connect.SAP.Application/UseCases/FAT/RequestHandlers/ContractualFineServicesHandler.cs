using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public abstract class ContractualFineServicesHandler : Handler
    {
        protected abstract List<string> activities { get; }
        protected abstract List<string> usageAtrribute { get; }
        protected abstract string subscriptionType { get; }

        private readonly IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository;

        public ContractualFineServicesHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository)
        {
            this.serviceReadOnlyRepository = serviceReadOnlyRepository;
        }

        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Getting Contractual Fine Services - FAT");

            var invoices = request.Invoices.Select(s => s.InvoiceNumber).ToList();

            request.ContractualFineServices.AddRange(serviceReadOnlyRepository.GetServicesByActivityAndUsageAttributes(invoices, activities, usageAtrribute, subscriptionType));

            request.ContractualFineServices.ForEach(e =>
            {
                e.Invoice = request.Invoices.Where(f => f.InvoiceNumber == e.InvoiceNumber).FirstOrDefault();
            });

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
