using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.FAT.FATBase
{
    public class Header : IHeader
    {
        private const string linetype = "HH";
        private const string origin = "FAT";
        private const string division = "29SP";

        [Required]
        [MaxLength(2)]
        public string LineType { get => linetype; }

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
