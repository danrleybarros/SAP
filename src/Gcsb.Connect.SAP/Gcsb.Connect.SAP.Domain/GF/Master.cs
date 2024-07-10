using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.GF
{
    public class Master
    {
        private const string tdoc_cod = "NFS";
        private const string infss_serie = "@";
        private const string catg_cod = "CL";
        private const string var05 = "Vivo Plataforma Digital";
        private const string cadg_cod = "GW";
        private const string fileName = "GW_MASTER_CC_";
        private const string monthFormat = "{0:MMyyyy}";
        private const string dateFormat = "{0:yyyyMMdd}";
        private const string numberFormat = "{0:00000000000000000}";
        private const string infssNumFormat = "{0:000000000000000}";
        private const decimal totalRetailPriceDiscount = 0.00m;
        private const int mnfssTipPag = 0;
        private const string chaveNF = "";
        private const string affiliateCode = "1";

        [Required]
        [MaxLength(9)]
        [GF("EMPS_COD")]
        public string CompanyCode { get; private set; }

        [Required]
        [MaxLength(9)]
        [GF("FILI_COD")]
        public string AffiliateCode { get => affiliateCode; }

        [Required]
        [MaxLength(3)]
        [GF("TDOC_COD")]
        public string Nfs { get => tdoc_cod; }

        [Required]
        [MaxLength(5)]
        [GF("MNFSS_SERIE")]
        public string InfssSerie { get => infss_serie; }

        [Required]
        [GF("MNFSS_NUM")]
        [Format(infssNumFormat)]
        public int NumberNotaFiscal { get; private set; }

        [Required]
        [GF("MNFSS_DTEMISS")]
        [Format(dateFormat)]
        public DateTime IssueDate { get; private set; }

        [Required]
        [MaxLength(2)]
        [GF("CATG_COD")]
        public string CatgCod { get => catg_cod; }

        [Required]
        [MaxLengthTruncate(16)]
        [GF("CADG_COD")]
        public string CadgCod
        {
            get
            { return _CadgCod; }
            set
            {
                string retorno = "";
                if (value != null && value.Length > 2)
                {
                    string ini = value.Substring(0, 2);
                    string fim = value.Substring(2, value.Length - 2);
                    retorno = ini + fim.PadLeft(16 - ini.Length, '0');
                }
                _CadgCod = retorno;
            }
        }
        private string _CadgCod { get; set; }

        [Required]
        [GF("MNFSS_VAL_TOT")]
        [NotMapped]
        public decimal TotalInvoicePrice { get; private set; }

        [Format(numberFormat)]
        public int TotalInvoicePriceInt { get => MakeValue(this.TotalInvoicePrice); }

        [Required]
        [GF("MNFSS_VAL_DESC")]
        [NotMapped]
        public decimal TotalRetailPriceDiscount { get => totalRetailPriceDiscount; }

        [Format(numberFormat)]
        public int TotalRetailPriceDiscountInt { get => MakeValue(this.TotalRetailPriceDiscount); }

        [Required]
        [MaxLength(1)]
        [GF("MNFSS_IND_CANC")]
        public string CancelNF { get; private set; }

        [Required]
        [MaxLength(150)]
        [GF("VAR05")]
        public string Var05 { get => var05; }

        [Required]
        [GF("MNFSS_VL_BC_ISSQN")]
        [NotMapped]
        public double GrandTotalRetailPrice { get; set; }

        [Format(numberFormat)]
        public int GrandTotalRetailPriceInt { get => MakeValue(this.GrandTotalRetailPrice); }

        [MaxLength(60)]
        [GF("MNFSS_CHV_NFSE")]
        public string ChaveNF { get => chaveNF; }

        [Required]
        [GF("MNFSS_DAT_SERV")]
        [Format(dateFormat)]
        public DateTime CycleFatDate { get; set; }

        [NotMapped]
        public string FileName { get => SetFileName(); }

        [Required]
        [GF("MNFSS_TIP_PAG")]
        public int MnfssTipPag { get => mnfssTipPag; }

        public Master(string companyCode, int numberNotaFiscal, DateTime issueDate, string cadgCod, decimal totalInvoicePrice, string cancelNF,
            double grandTotalRetailPrice, DateTime cycleFatDate)
        {
            this.CompanyCode = companyCode;            
            this.NumberNotaFiscal = numberNotaFiscal;
            this.IssueDate = issueDate;
            this.CadgCod = $"{cadg_cod}{cadgCod}";
            this.TotalInvoicePrice = totalInvoicePrice;
            this.CancelNF = cancelNF;
            this.GrandTotalRetailPrice = grandTotalRetailPrice;
            this.CycleFatDate = cycleFatDate;
        }

        private string SetFileName()
            => $"{fileName}{string.Format(monthFormat, "")}.TXT";

        private int MakeValue(decimal value)
            => decimal.ToInt32((value) * 100);

        private int MakeValue(double value)
        {
            var result = (decimal)((value) * 100);

            return decimal.ToInt32(result);
        }
    }
}