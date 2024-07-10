using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.BillFeed
{
    public class BillFeedRequest
    {
        public DateTime BillFromDate { get; private set; }
        public DateTime BillToDate { get; private set; }

        public BillFeedRequest(DateTime billFromDate, DateTime billToDate)
        {
            BillFromDate = billFromDate;
            BillToDate = billToDate;
        }
    }
}
