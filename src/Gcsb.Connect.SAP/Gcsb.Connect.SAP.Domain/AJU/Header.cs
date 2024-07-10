using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.AJU
{
    public class Header
    {
        private const string typeLine = "HH";
        private const string origin = "FAT";   
        private const string division = "29SP";

        [Required]
        [MaxLength(2)]
        public string TypeLine { get => typeLine; }

        [Required]
        [MaxLength(3)]
        public string Origin { get => origin; }

        [Required]
        [MaxLength(4)]
        public string Company { get => Type switch { StoreType.IOTCo => "TLF3", _ => Type.ToString() }; }

        [Required]
        [MaxLength(4)]
        public string Division { get => division; }
               
        [NotMapped]
        public StoreType Type { get; private set; }

        public Header(StoreType storeType)
        {
            Type = storeType;
        }
    }
}
