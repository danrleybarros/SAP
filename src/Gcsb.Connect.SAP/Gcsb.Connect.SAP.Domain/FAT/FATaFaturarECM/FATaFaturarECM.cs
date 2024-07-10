using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Domain.FAT.FATaFaturarECM
{
    public class FATaFaturarECM : FATBase.FAT
    {
        public FATaFaturarECM(
                IdentificationRecordECM identificationRecord,
                Header header,
                List<ILaunch> launchs,
                File file)
            : base(
                  identificationRecord,
                  header,
                  launchs,
                  file
                  )
        {
        }
    }
}
