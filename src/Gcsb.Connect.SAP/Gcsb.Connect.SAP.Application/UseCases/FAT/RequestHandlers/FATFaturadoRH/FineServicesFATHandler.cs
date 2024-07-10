using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH
{
    public class FineServicesFATHandler : FineServicesHandler
    {
        protected override List<string> activities => new List<string> { "fines" };
        protected override List<string> usageAtrribute => new List<string>() { "fines" };
        protected override string subscriptionType => "promotion";

        public FineServicesFATHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository) 
            : base(serviceReadOnlyRepository)
        { }
    }
}
