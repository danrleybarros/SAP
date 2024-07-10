using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.FAT.FATFaturado
{
    public class IdentificationRecordFaturado : FATBase.IdentificationRecord
    {
        protected override string FileCodTBRA => "55";
        protected override string FileCodCloudCO => "77";
        protected override string FileCodIOT => "45";

        protected override StoreType Type => StoreType;
        

        [NotMapped]
        public StoreType StoreType { get; private set; }

        public IdentificationRecordFaturado(DateTime generationdate, DateTime billingCycleDate)
            : base(generationdate, billingCycleDate)
        { }

        public IdentificationRecordFaturado(int sequence, DateTime billingCycleDate, StoreType storeType)
            : base(sequence, billingCycleDate)
        {
            StoreType = storeType;
        }
    }
}
