using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.FAT.FATBase
{
    public abstract class IdentificationRecord : IIdentificationRecord
    {
        private const string linetype = "ID";
        private const string billingCycleFormat = "{0:ddyyyyMMdd}";
        private const string generationDateFormat = "{0:ddMMyyyyHHmmss}";
        private const string generationDateYearFormat = "{0:yy}";
        private const string sequenceFormat = "{0:0000}";
        private const string divisionNumber = "29";

        protected abstract string FileCodTBRA { get; }
        protected abstract string FileCodCloudCO { get; }
        protected abstract string FileCodIOT { get; }

        protected abstract StoreType Type { get; }

        [Required]
        [MaxLength(2)]
        public string LineType { get => linetype; }

        [Required]
        [MaxLength(30)]
        public string FileName => GetFileName();

        [Required]
        [Format(generationDateFormat)]
        public DateTime GenerationDate { get; private set; }

        [NotMapped]
        public int Sequence { get; private set; }

        [NotMapped]
        [Format(billingCycleFormat)]
        public DateTime BillingCycleDate { get; set; }

        public IdentificationRecord(DateTime generationdate, DateTime billingCycleDate)
        {
            this.GenerationDate = generationdate;
            this.BillingCycleDate = billingCycleDate;
        }

        public IdentificationRecord(int sequence, DateTime billingCycleDate)
        {
            this.Sequence = sequence;
            this.GenerationDate = DateTime.UtcNow;
            this.BillingCycleDate = billingCycleDate;
        }

        private string GetFileName()
        {
            return Type switch
            {
                StoreType.TBRA => $"FAT{FileCodTBRA}{GetCompany(Type)}{divisionNumber}{string.Format(generationDateYearFormat, GenerationDate)}{string.Format(sequenceFormat, Sequence)}{string.Format(billingCycleFormat, BillingCycleDate)}.TXT",
                StoreType.TLF2 => $"FAT{FileCodCloudCO}{GetCompany(Type)}{divisionNumber}{string.Format(generationDateYearFormat, GenerationDate)}{string.Format(sequenceFormat, Sequence)}{string.Format(billingCycleFormat, BillingCycleDate)}.TXT",
                StoreType.IOTCo => $"FAT{FileCodIOT}{GetCompany(Type)}{divisionNumber}{string.Format(generationDateYearFormat, GenerationDate)}{string.Format(sequenceFormat, Sequence)}{string.Format(billingCycleFormat, BillingCycleDate)}.TXT",
                _ => $"FAT{FileCodTBRA}{GetCompany(Type)}{divisionNumber}{string.Format(generationDateYearFormat, GenerationDate)}{string.Format(sequenceFormat, Sequence)}{string.Format(billingCycleFormat, BillingCycleDate)}.TXT",
            };
        }

        private string GetCompany(StoreType type) => type switch
        {
            StoreType.TLF2 => "TL",
            StoreType.TBRA => "TB",
            StoreType.IOTCo => "TT",
            _ => "",
        };

    }
}
