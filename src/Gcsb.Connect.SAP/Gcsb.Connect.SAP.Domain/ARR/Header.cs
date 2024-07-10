using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.ARR
{
    public class Header
    {
        private const string typeLine = "HH";
        private const string source = "ARR";
        private const string division = "29SP";

        [Required]
        [MaxLength(2)]
        public string TypeLine { get => typeLine; }

        [Required]
        [MaxLength(3)]
        public string Source { get => source; }

        [Required]
        [MaxLength(4)]
        public string Company { get => SType.Equals(StoreType.TLF2) ? "TLF2" : SType.Equals(StoreType.IOTCo) ? "TLF3" : "TBRA"; }

        [MaxLength(8)]
        public string InitialStartDate { get; private set; }

        [MaxLength(8)]
        public string LateEndDate { get; private set; }

        [NotMapped]
        public DateTime DatePeriod { get; private set; }

        [Required]
        [MaxLength(6)]
        public string CompetencePeriod
        {
            get
            {
                return this.DatePeriod.ToString("MMyyyy");
            }
        }

        [Required]
        [MaxLength(4)]
        public string Division { get => division; }

        [NotMapped]
        public StoreType SType { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Header(string startDate, string endDate)
        {
            this.InitialStartDate = startDate;
            this.LateEndDate = endDate;
            this.DatePeriod = DateTime.UtcNow;
        }

        public Header(StoreType storeType)
        {
            SType = storeType;
            DatePeriod = DateTime.UtcNow;
        }
    }
}
