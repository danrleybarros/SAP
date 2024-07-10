using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers.FATaFaturarECM
{
    public class CounterchargeChargebackServicesFATHandler : CounterchargeChargebackServicesHandler
    {
        protected override List<string> activities => new List<string> { "Countercharge Chargeback" };
        protected override List<string> usageAtrribute => new List<string> { "Countercharge Chargeback" };
        protected override string subscriptionType => "";

        public CounterchargeChargebackServicesFATHandler(IServiceInvoiceReadOnlyRepository serviceReadOnlyRepository)
            : base(serviceReadOnlyRepository)
        { }
    }
}
