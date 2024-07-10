using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Domain.FAT.FATaFaturarACM
{
    public class FATaFaturarACM : FATBase.FAT
    {
        public FATaFaturarACM(IdentificationRecordACM identificationrecord, Header header, List<ILaunch> launchs, File file)
            : base(identificationrecord, header, launchs, file)
        { }
    }
}
