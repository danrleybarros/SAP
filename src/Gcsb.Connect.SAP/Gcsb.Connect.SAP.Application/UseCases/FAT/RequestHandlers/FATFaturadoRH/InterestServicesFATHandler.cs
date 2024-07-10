using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH
{
    public class InterestServicesFATHandler : InterestServicesHandler
    {
        protected override List<string> activities => new List<string> { "interest" };
        protected override List<string> usageAtrribute => new List<string> { "interest" };
        protected override string subscriptionType => "promotion";

        public InterestServicesFATHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository)
            : base(serviceReadOnlyRepository)
        { }
    }
}
