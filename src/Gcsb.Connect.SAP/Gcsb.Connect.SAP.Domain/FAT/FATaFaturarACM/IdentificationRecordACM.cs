using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.FAT.FATaFaturarACM
{
    public class IdentificationRecordACM : FATBase.IdentificationRecord
    {
        protected override string FileCodTBRA => "56";
        protected override string FileCodCloudCO => "78";
        protected override string FileCodIOT => "46";
        protected override StoreType Type => StoreType;

        [NotMapped]
        public StoreType StoreType { get; private set; }

        public IdentificationRecordACM(DateTime generationdate, DateTime billingCycleDate)
            : base(generationdate, billingCycleDate)
        { }

        public IdentificationRecordACM(int sequence, DateTime billingCycleDate, StoreType storeType)
            : base(sequence, billingCycleDate)
        {
            StoreType = storeType;
        }
    }
}
