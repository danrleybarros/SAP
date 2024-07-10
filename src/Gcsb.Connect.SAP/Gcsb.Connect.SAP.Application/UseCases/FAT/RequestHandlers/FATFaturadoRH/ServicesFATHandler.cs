using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH
{
    public class ServicesFATHandler : ServicesHandler
    {
        protected override List<string> activities => new List<string> { "credits", "fines", "interest", "payment credit", "contractual fine" };
        protected override List<string> usageAtrribute => new List<string> { "fines", "interest" };
        protected override string subscriptionType => "promotion";

        public ServicesFATHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository)
            : base(serviceReadOnlyRepository)
        { }
    }
}
