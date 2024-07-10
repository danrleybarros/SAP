using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDisputeByInvoices
{
    public class CounterchargeDisputeByInvoicesRequest
    {
        public List<string> InvoicesNumber { get; private set; }
        public List<Domain.JSDN.CounterChargeDispute.CounterchargeDisputeInvoice> CounterchargeDisputes { get; set; }

        public CounterchargeDisputeByInvoicesRequest(List<string> invoicesNumber)
        {
            InvoicesNumber = invoicesNumber;
            CounterchargeDisputes = new List<Domain.JSDN.CounterChargeDispute.CounterchargeDisputeInvoice>();
        }
    }
}
