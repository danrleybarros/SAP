using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.GF
{
    public class Items
    {
        private const string tdoc_cod = "NFS";
        private const string infss_serie = "@";
        private const string catg_cod = "CL";
        private const string ccus_cod = "29TR018233";
        private const string infss_cst_iss = "00";
        private const string tp_loc = "13";
        private const string var05 = "Vivo Plataforma Digital";
        private const string monthFormat = "{0:MMyyyy}";
        private const string dateFormat = "{0:yyyyMMdd}";
        private const string numberFormat = "{0:00000000000000000}";
        private const string sequenceFormat = "{0:00000}";
        private const string infssNumFormat = "{0:000000000000000}";
        private const string serviceName = "Processamento,armaz. ou hosped. de dados, textos, imagens, videos, paginas eletronicas, apps e sist. de info., entre outros formatos e congeneres";
        private const string serviceCode = "1.03";
        private const decimal totalRetailPriceDiscount = 0.00m;
        private const string cslcCodLst = "1.03";
        private const string pconCodConta = "41431077";

        [Required]
        [MaxLength(9)]
        [GF("EMPS_COD")]
        public string CompanyCode { get; private set; }

        [Required]
        [MaxLength(9)]
        [GF("FILI_COD")]
        public string AffiliateCode { get; private set; }

        [Required]
        [MaxLength(3)]
        [GF("TDOC_COD")]
        public string Nfs { get => tdoc_cod; }

        [Required]
        [MaxLength(5)]
        [GF("INFSS_SERIE")]
        public string InfssSerie { get => infss_serie; }

        [GF("INFSS_NUM")]
        [Format(infssNumFormat)]
        public int NumberNotaFiscal { get; private set; }

        [Required]
        [GF("INFSS_DTEMISS")]
        [Format(dateFormat)]
        public DateTime IssueDate { get; private set; }

        [Required]
        [MaxLength(2)]
        [GF("CATG_COD")]
        public string CatgCod { get => catg_cod; }

        [NotMapped]
        public string _cadgCod;

        [Required]
        [MaxLength(16)]
        [GF("CADG_COD")]
        public string CadgCod { get => "GW" + _cadgCod.PadLeft(14, '0'); set => _cadgCod = value; }

        [MaxLength(28)]
        [GF("PCON_COD_CONTA")]
        public string AccountingAccount { get; private set; }

        [Required]
        [MaxLength(28)]
        [GF("CCUS_COD")]
        public string CostCenter { get => ccus_cod; }

        [Required]
        [MaxLength(60)]
        [GF("SERV_COD")]
        public string ServiceCode { get => serviceCode; }

        [Required]
        [MaxLength(150)]
        [GF("INFSS_DSC_COMPL")]
        public string ServiceName { get => serviceName; }

        [Required]
        [GF("INFSS_VAL_SERV")]
        [NotMapped]
        public double RetailUnitPrice { get; private set; }

        [Format(numberFormat)]
        public int RetailtUnitPriceInt { get => MakeValue(this.RetailUnitPrice); }

        [Required]
        [GF("INFSS_VAL_DESC")]
        [NotMapped]
        public decimal TotalRetailPriceDiscount { get => totalRetailPriceDiscount; }

        [Format(numberFormat)]
        public int TotalRetailPriceDiscountInt { get => MakeValue(this.TotalRetailPriceDiscount); }

        [Required]
        [MaxLength(2)]
        [GF("INFSS_CTS_ISS")]
        public string FullyTaxed { get => infss_cst_iss; }

        [Required]
        [GF("INFSS_ALIQ_ISS")]
        [NotMapped]
        public decimal PercentualISS { get; private set; }

        [Format(numberFormat)]
        public int PercentualISSInt { get => MakeValue(this.PercentualISS); }

        [Required]
        [GF("INFSS_BASE_ISS")]
        [NotMapped]
        public double GrandTotalRetailPrice { get; private set; }

        [Format(numberFormat)]
        public int GrandTotalRetailPriceInt { get => MakeValue(this.GrandTotalRetailPrice); }

        [Required]
        [GF("INFSS_VAL_ISS")]
        [NotMapped]
        public decimal TotalTaxISSCode { get; private set; }

        [Format(numberFormat)]
        public int TotalTaxTaxCodeInt { get => MakeValue(this.TotalTaxISSCode); }

        [Required]
        [GF("INFSS_VAL_TOTDOC")]
        [NotMapped]
        public decimal TotalInvoicePrice { get; private set; }

        [Format(numberFormat)]
        public int TotalInvoicePriceInt { get => MakeValue(TotalInvoicePrice); }

        [Required]
        [GF("INFSS_NUM_SEQ")]
        [Format(sequenceFormat)]
        public int SequentialNumberNote { get; private set; }

        [Required] 
        [MaxLength(2)]
        [GF("TP_LOC")]
        public string TpLoc { get => tp_loc; }

        [Required]
        [GF("LOCALIDADE")]
        [MaxLength(7)]
        public string IbgeCod { get; private set; }

        [Required]
        [MaxLength(150)]
        [GF("VAR05")]
        public string Var05 { get => var05; }

        [NotMapped]
        [Format(monthFormat)]
        public DateTime CycleFatDate { get; private set; }

        [Required]
        [MaxLength(5)]
        [GF("CSLC_COD_LST")]
        public string CslcCodLst { get => cslcCodLst; }

        [Required]
        [MaxLength(28)]
        [GF("PCON_COD_CONTA")]
        public string PconCodConta { get => pconCodConta; }

        public Items(string companyCode, string affiliateCode, int numberNotaFiscal, DateTime issueDate, string cadgCod, string accountingAccount, double retailUnitPrice, decimal percentualISS,
                     double grandTotalRetailPrice, decimal totalTaxISS, decimal totalInvoicePrice, int sequentialNumberNote, string ibgeCod, DateTime cycleFatDate)
        {
            this.CompanyCode = companyCode;
            this.AffiliateCode = affiliateCode;
            this.NumberNotaFiscal = numberNotaFiscal;
            this.IssueDate = issueDate;
            this.CadgCod = cadgCod;
            this.AccountingAccount = accountingAccount;
            this.RetailUnitPrice = retailUnitPrice;
            this.PercentualISS = percentualISS;
            this.GrandTotalRetailPrice = grandTotalRetailPrice;
            this.TotalTaxISSCode = totalTaxISS;
            this.TotalInvoicePrice = totalInvoicePrice;
            this.SequentialNumberNote = sequentialNumberNote;
            this.IbgeCod = ibgeCod;
            this.CycleFatDate = cycleFatDate;
        }

        private int MakeValue(decimal value)
            => decimal.ToInt32((value) * 100);

        private int MakeValue(double value)
        {
            var result = (decimal)((value) * 100);

            return decimal.ToInt32(result);
        }
    }
}