using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDispute
{
    public class CounterchargeDisputeRequest
    {
        public DateTime DateFrom { get; private set; }
        public DateTime DateTo { get; private set; }
        public List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute> CounterchargeDisputes { get; set; }

        public CounterchargeDisputeRequest(DateTime dateFrom, DateTime dateTo)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
            CounterchargeDisputes = new List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute>();
        }
    }
}
