using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.ARR.ARRBoletoIntercompany
{
    public class IdentificationRegisterBoleto : IdentificationRegister
    {
        private const string sequenceFormat = "{0:0000}";
        protected override string typeLine => "ID";
        protected override string systemCode => "ARR";
        protected override string fileCode => storeType.Equals(StoreType.TLF2) ? "" : storeType.Equals(StoreType.IOTCo) ? "IO" : "I6";
        protected override string companyCode => storeType.Equals(StoreType.TLF2) ? "CLTL" : storeType.Equals(StoreType.IOTCo) ? "TT" : "TB";
        protected override string divisionCode => "29";
        protected override string extension => ".TXT";

        [NotMapped]
        public StoreType storeType { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public IdentificationRegisterBoleto(int sequential, StoreType storeType)
            : base(sequential)
        {
            this.storeType = storeType;
        }

        protected override string GetFileName()
            => $"{systemCode}{fileCode}{companyCode}{divisionCode}{this.GenerationYear}{string.Format(sequenceFormat, Sequence)}{extension}";
    }
}
