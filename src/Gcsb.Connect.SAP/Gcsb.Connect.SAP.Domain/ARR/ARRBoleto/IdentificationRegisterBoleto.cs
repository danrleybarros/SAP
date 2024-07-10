using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.ARR.Boleto
{
    public class IdentificationRegisterBoleto : IdentificationRegister
    {
        private const string sequenceFormat = "{0:0000}";
        protected override string typeLine => "ID";
        protected override string systemCode => "ARR";
        protected override string fileCode => STYpe.Equals(StoreType.TLF2) ? "" : "56";
        protected override string companyCode => STYpe.Equals(StoreType.TLF2) ? "CLTL" : "TB";
        protected override string divisionCode => "29";
        protected override string extension => ".TXT";

        [NotMapped]
        public StoreType STYpe { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public IdentificationRegisterBoleto(int sequential, StoreType storeType) 
            : base(sequential)
        {
            STYpe = storeType;
        }

        protected override string GetFileName()
            => $"{systemCode}{fileCode}{companyCode}{divisionCode}{this.GenerationYear}{string.Format(sequenceFormat, Sequence)}{extension}";
    }
}
