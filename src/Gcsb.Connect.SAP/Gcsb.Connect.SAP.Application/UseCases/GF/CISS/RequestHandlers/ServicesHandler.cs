using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System;
using System.Linq;
using Gcsb.Connect.SAP.Domain.JSDN;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.CISS.RequestHandlers
{
    public class ServicesHandler : Handler
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository;

        public ServicesHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository)
        {
            this.serviceReadOnlyRepository = serviceReadOnlyRepository;
        }

        public override void ProcessRequest(CISSRequest request)
        {
            request.AddProcessingLog("Consulting Services - CISS");
            if ((request?.Invoices?.Count ?? 0) == 0)
                throw new ArgumentException("Invoices information not found");

            List<ServiceFilter> servicesFilter = new List<ServiceFilter>();

            servicesFilter = serviceReadOnlyRepository.GetServices(request.Invoices.Select(s => s.InvoiceNumber).ToList());
                  
            request.Services = servicesFilter;

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}