using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarECM
{
    public class FineServicesFATECMHandler : FineServicesHandler
    {
        public FineServicesFATECMHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository) 
            : base(serviceReadOnlyRepository)
        { }

        protected override List<string> activities => new List<string> { "fines" };
        protected override List<string> usageAtrribute => new List<string>() { "fines" };
        protected override string subscriptionType => "promotion";
    }
}
