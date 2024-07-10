using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany
{
    public class IdentificationRegisterCreditCardInter : IdentificationRegister
    {
        private const string sequenceFormat = "{0:0000}";

        protected override string typeLine => "ID";
        protected override string systemCode => STYpe.Equals(StoreType.TBRA) ? "ARR" : "ARRCC";
        protected override string fileCode => STYpe.Equals(StoreType.TLF2) ? "" : STYpe.Equals(StoreType.TBRA) ? "I5" : "";
        protected override string companyCode => STYpe.Equals(StoreType.TLF2) ? "TL" : STYpe.Equals(StoreType.TBRA) ? "TB" : "TT";
        protected override string divisionCode => "29";
        protected override string extension => ".TXT";

        [NotMapped]
        public StoreType STYpe { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public IdentificationRegisterCreditCardInter(int sequential, StoreType storeType)
            : base(sequential)
        {
            STYpe = storeType;
        }

        protected override string GetFileName()
            => $"{systemCode}{fileCode}{companyCode}{divisionCode}{this.GenerationYear}{string.Format(sequenceFormat, Sequence)}{extension}";
    }
}
