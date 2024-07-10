using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using Gcsb.Connect.SAP.Tests.Builders.FAT.IFAT;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Tests.Builders.FAT.FATBase
{
    public abstract class IdentificationRecordBuilder
    {
        public string FileName;
        public DateTime GenerationDate;
        public DateTime BillingCycleDate;

        public abstract IdentificationRecordBuilder New();
        ////{
        ////    return new IdentificationRecordBuilder
        ////    {
        ////        GenerationDate = new DateTime(2019, 03, 13, 23, 51, 13), //13/03/2019 23:51:13
        ////        BillingCycleDate = new DateTime(2019, 03, 31, 23, 51, 13) //31/03/2019 23:51:13
        ////    };
        ////}

        public IdentificationRecordBuilder WithFileName(string filename)
        {
            FileName = filename;
            return this;
        }

        public IdentificationRecordBuilder WithGenerationDate(DateTime generationdate)
        {
            GenerationDate = generationdate;
            return this;
        }

        public IdentificationRecordBuilder WithBillingCycleDate(DateTime billingcycledate)
        {
            BillingCycleDate = billingcycledate;
            return this;
        }

        public abstract IdentificationRecord Build();
        //{
            
        //}
    }
}
