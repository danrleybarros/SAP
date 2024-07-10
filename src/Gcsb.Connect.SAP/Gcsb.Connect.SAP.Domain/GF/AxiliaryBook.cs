using Gcsb.Connect.SAP.Domain.AttributeValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.GF
{
    public class AxiliaryBook
    {
        private string dcliNumArq;
        private string customerCode;
        private const string InitialCustomerCode = "GW";
        private const string catgCod = "CL";
        private const string dateFormat = "{0:yyyyMMdd}";
        private const string topeCod = "Fatura";
        private const string tdocCod = "NFS";
        private const string sequence = "{0:000000000000000}";
        private const string dcliIndLancto = "D";
        private const string monthFormat = "{0:MMyyyy}";
        private const string dayFormat = "{0:dd}";

        [Required]
        [MaxLength(9)]
        [GF("EMPS_COD")]
        public string CompanyCode { get; private set; }

        [Required]
        [MaxLength(9)]
        [GF("FILI_COD")]
        public string AffiliateCode { get; private set; }

        [Required]
        [MaxLength(16)]
        [GF("CADG_COD")]
        public string CustomerCode { get => ValidateCustomerCode(customerCode); set => customerCode = value; }

        [Required]
        [MaxLength(2)]
        [GF("CATG_COD")]
        public string CatgCod { get => catgCod; }

        [Required]
        [ValidateDate]
        [Format(dateFormat)]
        public DateTime DateInvoiceClosing { get; private set; }

        [Required]
        [MaxLength(6)]
        [GF("TOPE_COD")]
        public string TypeOperation { get => topeCod; }

        [Required]
        [MaxLength(3)]
        [GF("TDOC_COD")]
        public string TdocCod { get => tdocCod; }

        [Required]
        [MaxLength(28)]
        [GF("PCON_COD_CONTA")]
        public string FinancialAccount { get; private set; }

        [Required]
        [MaxLength(15)]
        [GF("DCLI_NUM_DOC")]
        public string InvoiceNumber { get; private set; }

        [MaxLength(5)]
        [GF("DCLI_NUM_SERIE")]
        public string DcliNumSerie { get; private set; }

        [Required]
        [ValidateDate]
        [Format(dateFormat)]
        public DateTime DateEmissNF { get; private set; }

        [Required]
        [ValidateDate]
        [Format(dateFormat)]
        public DateTime DateVencNF { get; private set; }

        [Required]
        [GF("DCLI_VAL_LANCTO")]
        [NotMapped]
        public decimal TotalInvoicePrice { get; private set; }

        [Format(sequence)]
        public int TotalInvoicePriceInt { get => MakeValue(TotalInvoicePrice); }

        [Required]
        [MaxLength(1)]
        [GF("DCLI_IND_LANCTO")]
        public string DcliIndLancto { get => dcliIndLancto; }

        [Required]
        [MaxLength(40)]
        [GF("DCLI_NUM_ARQ")]
        public string DcliNumArq { get => $"{dcliNumArq}{DcliNumSerie}"; private set => dcliNumArq = value; }

        [Required]
        [GF("DCLI_VAL_DOCTO")]
        [NotMapped]
        public decimal DcliValDocto { get; private set; }

        [Format(sequence)]
        public decimal DcliValDoctoInt { get => MakeValue(DcliValDocto); }

        [Required]
        [Format(sequence)]
        [GF("NUM01")]
        public decimal NUM01 { get; private set; }

        [Required]
        [Format(sequence)]
        [GF("NUM02")]
        public decimal NUM02 { get; private set; }

        [Required]
        [Format(sequence)]
        [GF("NUM03")]
        public decimal NUM03 { get; private set; }

        [MaxLength(150)]
        [GF("VAR01")]
        public string VAR01 { get; private set; }

        [MaxLength(150)]
        [GF("VAR02")]
        public string VAR02 { get; private set; }

        [MaxLength(150)]
        [GF("VAR03")]
        public string VAR03 { get; private set; }

        [MaxLength(150)]
        [GF("VAR04")]
        public string VAR04 { get; private set; }

        [MaxLength(150)]
        [GF("VAR05")]
        public string VAR05 { get; private set; }

        [MaxLength(9)]
        [GF("UNIN_COD")]
        public string UninCod { get; private set; }

        [NotMapped]
        [Format(monthFormat)]
        public DateTime CycleBilling { get; private set; }

        [NotMapped]
        public string FileName { get => GetFileName(); }

        public AxiliaryBook(string companyCode, string affiliateCode, string customerCode, DateTime dateInvoiceClosing, string financialAccount, string invoiceNumber, DateTime dateEmissNF, DateTime dateVencNF, decimal totalInvoicePrice, string dcliNumArq, decimal dcliValDocto, DateTime cycleBilling)
        {
            CompanyCode = companyCode;
            AffiliateCode = affiliateCode;
            CustomerCode = customerCode;
            DateInvoiceClosing = dateInvoiceClosing;
            FinancialAccount = financialAccount;
            InvoiceNumber = invoiceNumber;
            DateEmissNF = dateEmissNF;
            DateVencNF = dateVencNF;
            TotalInvoicePrice = totalInvoicePrice;
            DcliNumArq = dcliNumArq;
            DcliValDocto = dcliValDocto;
            CycleBilling = cycleBilling;
        }

        private string GetFileName()
        {
            return $"GW_LIVRO_{string.Format(dayFormat, CycleBilling)}_{string.Format(monthFormat, CycleBilling)}.TXT";
        }

        public string[] GetConstantsValues()
        {
            return new string[] { dateFormat, sequence };
        }

        public IList<ValidationResult> ValidateModel()
        {
            return Util.ValidateModel(this);
        }

        private string ValidateCustomerCode(string customerCode)
       => !string.IsNullOrEmpty(customerCode) ? $"{InitialCustomerCode}{customerCode.PadLeft(14, '0')}" : customerCode;


        private int MakeValue(decimal value)
           => decimal.ToInt32((value) * 100);

    }
}
