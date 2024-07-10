using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Tests.Builders.FAT.IFAT
{
    public interface IIdentificationRecordBuilder<T>
    {
        T Build();
    }
}
