using System;

namespace Gcsb.Connect.SAP.Application.Boundaries.Deferral
{
    public record BillFeedCycleDate
    {
        public DateTime BillFrom { get; set; }
        public DateTime BillTo { get; set; }
    }
}
