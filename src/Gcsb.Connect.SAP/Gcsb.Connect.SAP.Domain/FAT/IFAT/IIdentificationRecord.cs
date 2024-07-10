using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.FAT.IFAT
{
    public interface IIdentificationRecord
    {
        string LineType { get; }
        string FileName { get; }
        DateTime GenerationDate { get; }
        int Sequence { get; }
        DateTime BillingCycleDate { get; set; }
    }
}
