using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.RequestHandlers
{
    public class GetCounterchargeDisputeByCycleHandler : Handler
    {
        private readonly IJsdnRepository jsdnRepository;

        public GetCounterchargeDisputeByCycleHandler(IJsdnRepository jsdnRepository)
        {
            this.jsdnRepository = jsdnRepository;
        }

        public override void ProcessRequest(FATRequest request)
        {
            request.AddProcessingLog("Get CounterchargeDispute by invoices");

            var invoicesNumber = new List<string>();
            invoicesNumber.AddRange(request.FineServices.Select(s => s.Invoice.InvoiceNumber).ToList());
            invoicesNumber.AddRange(request.InterestServices.Select(s => s.Invoice.InvoiceNumber).ToList());

            if (invoicesNumber.Count > 0)
            {
                var dateTo = request.BillingCycleDate.AddMonths(1).AddDays(-1);
                request.CounterchargeDisputes.AddRange(jsdnRepository.GetCounterChargeDisputeByCycle(request.BillingCycleDate, dateTo));
            }
            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
