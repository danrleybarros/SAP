using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATFaturadoRH
{
    public class ContractualServicesFATHandler : ContractualFineServicesHandler
    {
        protected override List<string> activities => new List<string> { "contractual fine" };
        protected override List<string> usageAtrribute => new List<string>() { "contractual fine" };
        protected override string subscriptionType => "promotion";

        public ContractualServicesFATHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository)
            : base(serviceReadOnlyRepository)
        { }
    }
}
