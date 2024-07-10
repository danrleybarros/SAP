using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.AJU
{
    public class IdentificationRegister
    {
        private const string codeSystem = "FAT";
        private const string FileCodTBRA = "57";
        private const string FileCodCloudCO = "79";
        private const string FileCodIOT = "47";
        private const string divisionCode = "29";
        private const string extension = ".TXT";
        private const string sequenceFormat = "{0:0000}";
        private const string billingCycleFormat = "{0:ddyyyyMMdd}";
        private const string typeLine = "ID";        

        [Required]
        [MaxLength(2)]
        public string TypeLine { get => typeLine; }

        [Required]
        [MaxLength(30)]
        public string FileName
        {
            get
            {
                return GetFileName();
            }
        }

        [Required]
        [NotMapped]
        public int Sequence { get; private set; }

        [NotMapped]
        [Format(billingCycleFormat)]
        public DateTime BillingCycleDate { get; private set; }

        [NotMapped]
        public string GenerationYear
        {
            get
            {
                return this.DateGeneration.ToString("yy");
            }
        }

        [Required]
        [NotMapped]
        public DateTime DateGeneration { get => DateTime.UtcNow; }

        [Required]
        [MaxLength(8)]
        public string GenerationDate
        {
            get
            {
                return this.DateGeneration.ToString("ddMMyyyy");
            }
        }

        [Required]
        [MaxLength(6)]
        public string GenerationHour
        {
            get
            {
                return this.DateGeneration.ToString("HHmmss");
            }
        }

        [NotMapped]
        public StoreType StoreType { get; private set; }


        public IdentificationRegister(int sequential, DateTime billingCycleDate, StoreType storeType)
        {
            this.Sequence = sequential;
            this.BillingCycleDate = billingCycleDate;
            StoreType = storeType;
        }

        private string GetFileName()
        {
            return StoreType switch
            {
                StoreType.TBRA => $"{codeSystem}{FileCodTBRA}{GetCompany()}{divisionCode}{this.GenerationYear}{string.Format(sequenceFormat, Sequence)}{string.Format(billingCycleFormat, this.BillingCycleDate)}{extension}",
                StoreType.TLF2 => $"{codeSystem}{FileCodCloudCO}{GetCompany()}{divisionCode}{this.GenerationYear}{string.Format(sequenceFormat, Sequence)}{string.Format(billingCycleFormat, this.BillingCycleDate)}{extension}",
                _ => $"{codeSystem}{FileCodIOT}{GetCompany()}{divisionCode}{this.GenerationYear}{string.Format(sequenceFormat, Sequence)}{string.Format(billingCycleFormat, this.BillingCycleDate)}{extension}"
            };
        }

        private string GetCompany()
        {
            if (StoreType.Equals(StoreType.TLF2))
                return "TL";
            if (StoreType.Equals(StoreType.TBRA))
                return "TB";
            else _ = (StoreType.Equals(StoreType.IOTCo));
                return "TT";
        }

    }
}
