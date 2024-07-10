using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using System.Collections.Generic;
using Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Domain.FAT.IFAT
{
    public interface IFAT
    {
        List<ILaunch> Launchs { get; set; }
        File File { get; set; }
        IIdentificationRecord IdentificationRecord { get; set; }
        Header Header { get; set; }
        Footer Footer { get; set; }
    }
}
