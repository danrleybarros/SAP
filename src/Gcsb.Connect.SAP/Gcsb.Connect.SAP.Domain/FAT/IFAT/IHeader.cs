using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Domain.FAT.IFAT
{
    public interface IHeader
    {
        string LineType{ get; }
        string Origin { get; }
        string Company { get; }
        string Division{ get; }
    }
}
