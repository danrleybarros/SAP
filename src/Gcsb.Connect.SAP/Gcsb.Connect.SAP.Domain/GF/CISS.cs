using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.GF
{
    public class CISS
    {
        private const string nffSeries = "@";
        private const string DateFormat = "{0:yyyyMMdd}";
        private const string monthFormat = "{0:MMyyyy}";
        private const string descriptionVar = "Vivo Plataforma Digital";        
        private const string numberFormat = "{0:00000000000000000}";
        private const string PercentualFormat = "{0:0000000}";
        private const string NFFormat = "{0:000000000000000}";        
        private const string Sequence = "{0:00000}";
        private const string pisTributeSituation = "01";
        private const string cofinsTributeSituation = "01";

        [Required]
        [MaxLength(9)]
        [GF("EMPS_COD")]
        public string CompanyCode { get; private set; }

        [Required]
        [MaxLength(9)]
        [GF("FILI_COD")]
        public string AffiliateCode { get; set; }

        [Required]
        [MaxLength(5)]
        [GF("INFSS_SERIE")]
        public string NFFSeries { get => nffSeries.PadRight(5); }

        [Required]
        [Format(NFFormat)]
        [GF("INFSS_NUM")]
        public int  NFFNumber { get; private set; }

        [Required]
        [Format(DateFormat)]
        [GF("INFSS_DTEMISS")]
        public DateTime NFFEmissionDate { get; private set; }

        [Required]
        [Format(Sequence)]
        [GF("INFSS_NUM_SEQ")]
        public int NFFSequenceItem { get; set; }

        [MaxLength(150)]
        [GF("VAR05")]
        public string DescriptionVar { get => descriptionVar.PadRight(150); }

        // GrossRetailPrice          
        [Required]
        [GF("CISS_BAS_PISCOF")]
        [NotMapped]
        public decimal GrandTotalRetailPrice { get; private set; }

        [Format(numberFormat)]
        public int GrandTotalRetailPriceInt { get => MakeValueTotal(GrandTotalRetailPrice); }       
        // --

        // TaxPis
        [Required]
        [GF("CISS_ALIQ_PIS")]
        [NotMapped]
        public decimal TaxPisPercentual { get; private set; }
        
        [Format(PercentualFormat)]
        public int TaxPisPercentualInt { get => MakeValueAliq(TaxPisPercentual); }
        // --            

        // TotalPis
        [Required]
        [GF("CISS_DEB_PIS")]
        [NotMapped]
        public decimal TaxPisTotalValue { get; private set; }

        [Format(numberFormat)]
        public int TaxPisTotalValueInt {get => MakeValueTotal(TaxPisTotalValue); }
        //

        // TaxCofins
        [Required]
        [GF("CISS_ALIQ_COF")]
        [NotMapped]
        public decimal TaxCofinsPercentual { get; private set; }
        
        [Format(PercentualFormat)]
        public int TaxCofinsPercentualInt { get => MakeValueAliq(TaxCofinsPercentual); }
        // --


        // TotalCofins
        [Required]
        [GF("CISS_DEB_COF")]
        [NotMapped]
        public decimal TaxCofinsTotalValue { get; private set; }

        [Format(numberFormat)]
        public int TaxCofinsTotalValueInt { get => MakeValueTotal(TaxCofinsTotalValue); }
        //

        [MaxLength(2)]
        [GF("CST_PIS")]
        public string PisTributeSituation { get => pisTributeSituation; }

        [MaxLength(2)]
        [GF("CST_COFINS")]
        public string CofinsTributeSituation { get => cofinsTributeSituation; }

        [NotMapped]
        [Format(monthFormat)]
        public DateTime CycleDate { get; private set; }

        [NotMapped]
        public string InvoiceNumber { get; set; }

        [NotMapped]
        public string ServiceCode { get; set; }

        public CISS(string companyCode, string affiliateCode,  int nffNumber, DateTime nffEmissionDate, int nffSequenceItem,
                      decimal grossRetailPrice, decimal taxPisPercentual, decimal taxPisTotalValue,
                      decimal taxCofinsPercentual, decimal taxCofinsTotalValue, DateTime cycleDate)
        {
            this.CompanyCode = companyCode;
            this.AffiliateCode = affiliateCode;
            this.NFFNumber = nffNumber;
            this.NFFEmissionDate = nffEmissionDate;
            this.NFFSequenceItem = nffSequenceItem;
            this.GrandTotalRetailPrice = grossRetailPrice;
            this.TaxPisPercentual = taxPisPercentual;
            this.TaxPisTotalValue = taxPisTotalValue;
            this.TaxCofinsPercentual = taxCofinsPercentual;
            this.TaxCofinsTotalValue = taxCofinsTotalValue;
            this.CycleDate = cycleDate;
        }

        public CISS(string companyCode, string affiliateCode, int nffNumber, DateTime nffEmissionDate, int nffSequenceItem,
                      decimal grandTotalRetailPrice, decimal taxPisPercentual, decimal taxPisTotalValue,
                      decimal taxCofinsPercentual, decimal taxCofinsTotalValue, DateTime cycleDate, string invoiceNumber, string serviceCode)
        {
            this.CompanyCode = companyCode;
            this.AffiliateCode = affiliateCode;
            this.NFFNumber = nffNumber;
            this.NFFEmissionDate = nffEmissionDate;
            this.NFFSequenceItem = nffSequenceItem;
            this.GrandTotalRetailPrice = grandTotalRetailPrice;
            this.TaxPisPercentual = taxPisPercentual;
            this.TaxPisTotalValue = taxPisTotalValue;
            this.TaxCofinsPercentual = taxCofinsPercentual;
            this.TaxCofinsTotalValue = taxCofinsTotalValue;
            this.CycleDate = cycleDate;
            this.InvoiceNumber = invoiceNumber;
            this.ServiceCode = serviceCode;
        }

        private int MakeValueAliq(decimal value)
            => decimal.ToInt32((value) * 10000);

        private int MakeValueTotal(decimal value)
            => decimal.ToInt32((value) * 100);

        public IList<ValidationResult> ValidateModel()
        {
            return Util.ValidateModel(this);
        }
    }
}
 