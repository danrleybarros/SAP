using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomersConsumption.RequestHandlers
{
    public class GetCreditInvoicesHandler : Handler
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository;

        public GetCreditInvoicesHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository)
        {
            this.serviceReadOnlyRepository = serviceReadOnlyRepository;
        }

        public override void ProcessRequest(CustomersConsumptionRequest request)
        {
            var servicesWithCredit = serviceReadOnlyRepository.GetServicesWithActivity(request.InvoicesNumbers, "Credits");

            if (servicesWithCredit.Count > 0)
            {
                servicesWithCredit
                    .Select(s => new { s.Invoice.InvoiceNumber, s.GrandTotalRetailPrice })
                    .GroupBy(g => g.InvoiceNumber)
                    .Select(i => new KeyValuePair<string, decimal>
                    ( 
                        i.Key,
                        (decimal)i.Sum(s => s.GrandTotalRetailPrice.Value)
                    ))
                    .ToList()
                    .ForEach(e =>
                    {
                        request.InvoicesCredit.Add(e.Key, e.Value);
                    });
            }

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
