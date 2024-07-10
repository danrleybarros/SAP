using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Domain.FAT.FATFaturado
{
    public class FATFaturado : FATBase.FAT
    {
        public FATFaturado(
                IdentificationRecordFaturado identificationrecord,
                Header header,
                List<ILaunch> launchs,
                File file)
            : base(
                  identificationrecord,
                  header,
                  launchs,
                  file
                  )
        { }
    }
}
