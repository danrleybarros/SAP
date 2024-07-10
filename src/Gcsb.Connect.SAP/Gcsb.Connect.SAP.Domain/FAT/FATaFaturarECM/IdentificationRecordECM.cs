using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.FAT.FATaFaturarECM
{
    public class IdentificationRecordECM : FATBase.IdentificationRecord
    {
        protected override string FileCodTBRA => "58";
        protected override string FileCodCloudCO => "80";
        protected override string FileCodIOT => "48";

        protected override StoreType Type => StoreType;

        [NotMapped]
        public StoreType StoreType { get; private set; }

        public IdentificationRecordECM(DateTime generationdate, DateTime billingCycleDate, StoreType storeType)
            : base(generationdate, billingCycleDate)
        {
            StoreType = storeType;
        }

        public IdentificationRecordECM(int sequence, DateTime billingCycleDate, StoreType storeType)
            : base(sequence, billingCycleDate)
        {
            StoreType = storeType;
        }
    }
}
