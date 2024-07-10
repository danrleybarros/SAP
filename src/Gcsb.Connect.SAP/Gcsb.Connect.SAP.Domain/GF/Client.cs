using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.GF
{
    public class Client
    {
        private const string categorycode = "CL";
        private const string countrycode = "BRA";
        private const string var05 = "Vivo Plataforma Digital";

        public const string customerDate = "{0:yyyyMMdd}";

        [Required]
        [MaxLength(16)]
        [GF("CADG_COD")]
        public string CustomerCode { get; set; }

        [Required]
        [GF("CADG_DAT_ATUA")]
        [Format(customerDate)]
        public DateTime CustomerUpdateDate { get; set; }

        [Required]
        [MaxLength(2)]
        [GF("CATG_COD")]
        public string CategoryCode { get => categorycode; }

        [Required]
        [MaxLength(3)]
        [GF("PAIS_COD")]
        public string CountryCode { get => countrycode; }

        [Required]
        [MaxLength(2)]
        [GF("UNFE_SIG")]
        public string Statefederativeunit { get; set; }

        [Required]
        [MaxLength(16)]
        [GF("CADG_COD_CGCCPF")]
        public string CustomerDocument { get; set; }

        [Required]
        [MaxLength(1)]
        [GF("CADG_TIP")]
        public string CustomerType { get; set; }

        [MaxLength(14)]
        [GF("CADG_COD_INSEST")]
        public string CustomerStateRegistration { get; set; }

        [Required]
        [MaxLength(70)]
        [GF("CADG_NOM")]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(70)]
        [GF("CADG_END")]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(12)]
        [GF("CADG_END_NUM")]
        public string CustomerAddressNumber { get; set; }

        [MaxLength(45)]
        [GF("CADG_END_COMP")]
        public string CustomerAddressCompletion { get; set; }

        [Required]
        [MaxLength(60)]
        [GF("CADG_END_BAIRRO")]
        public string CustomerNeighborhood { get; set; }

        [Required]
        [MaxLength(50)]
        [GF("CADG_END_MUNIC")]
        public string CustomerCity { get; set; }

        [Required]
        [MaxLength(8)]
        [GF("CADG_END_CEP")]
        public string CustomerZipCode { get; set; }

        [Required]
        [MaxLength(150)]
        [GF("VAR05")]
        public string Var05 { get => var05; }

        [Required]
        [MaxLength(7)]
        [GF("MIBGE_COD_MUN")]
        public string IBGECode { get; set; }

        public Client(string customercode, DateTime customerupdatedate, string statefederativeunit, string customerdocument, string customertype,
            string customerstateregistration, string customername, string customeraddress, string customeraddressnumber, string customeraddresscompletion, string customerneighborhood,
            string customercity, string customerzipcode, string ibgecode)
        {
            this.CustomerCode = customercode;
            this.CustomerUpdateDate = customerupdatedate;
            this.Statefederativeunit = statefederativeunit;
            this.CustomerDocument = customerdocument;
            this.CustomerType = customertype;
            this.CustomerStateRegistration = customerstateregistration;
            this.CustomerName = customername;
            this.CustomerAddress = customeraddress;
            this.CustomerAddressNumber = customeraddressnumber;
            this.CustomerAddressCompletion = customeraddresscompletion;
            this.CustomerNeighborhood = customerneighborhood;
            this.CustomerCity = customercity;
            this.CustomerZipCode = customerzipcode;
            this.IBGECode = ibgecode;
        }
    }
}