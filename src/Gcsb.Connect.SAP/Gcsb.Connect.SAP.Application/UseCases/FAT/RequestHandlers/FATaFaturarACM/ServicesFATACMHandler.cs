using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarACM
{
    public class ServicesFATACMHandler : ServicesHandler
    {
        protected override List<string> activities => new List<string> { "credits", "arrear", "fines", "interest", "payment credit", "contractual fine" };
        protected override string subscriptionType => string.Empty;
        protected override List<string> usageAtrribute => new List<string>();

        public ServicesFATACMHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository)
            : base(serviceReadOnlyRepository)
        { }
    }
}
