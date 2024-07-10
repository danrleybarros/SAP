using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.FAT.IFAT
{
    public interface IFooter
    {
        string LineType { get; }
        int TotalReleases { get; }
        decimal TotalReleasesValue { get; }
    }
}
