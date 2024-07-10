using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarECM
{
    public class InterestServicesFATECMHandler : InterestServicesHandler
    {
        public InterestServicesFATECMHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository) 
            : base(serviceReadOnlyRepository)
        { }

        protected override List<string> activities => new List<string> { "interest" };
        protected override List<string> usageAtrribute => new List<string>() { "interest" };
        protected override string subscriptionType => "promotion";
    }
}
