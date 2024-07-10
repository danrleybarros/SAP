using Gcsb.Connect.SAP.Domain.AttributeValidation;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.GF
{
    public class SpecialRegime
    {
        private const string nf = "";
        private const string serie = "";
        private const string cfop = "";
        private const string rg = "";
        private const string zone = "";
        private const string affiliateCode = "9141";
        private const string formatDate = "{0:dd/MM/yyyy}";
        private const string formatValue = "{0,0:0.00}";
        private const string monthFormat = "{0:MMyyyy}";
        private const string zipCodeFormat = "{0:00000000}";
        private const string cpfFormat = "{0:00000000000}";
        private const string cnpjFormat = "{0:00000000000000}";
        private string zipCodeBilling;

        [Required]
        [GF("N doc")]
        public string InvoiceNumber { get; private set; }

        [Required]
        [MaxLength(10)]
        [GF("LNeg")]
        public string AffiliateCode { get => affiliateCode; }

        [Required]
        [GF("Material")]
        public string ServiceCode { get; private set; }

        [Required]
        [GF("TxtBreveMaterial")]
        public string ServiceName { get; private set; }

        [GF("N NF")]
        public string NF { get => nf; }

        [GF("Ser")]
        public string Serie { get => serie; }

        [Required]
        [Format(formatDate)]
        [GF("Dta.lncto")]
        public DateTime InvoiceCreationDate { get; private set; }

        [Required]
        [GF("Nome 1")]
        public string CompanyName { get; private set; }

        [Required]
        [Format(formatValue)]
        [GF("Valor liquido")]
        public decimal TotalInvoicePrice { get; private set; }

        [Required]
        [Format(formatValue)]
        [GF("Mont.desconto liq")]
        public decimal TotalRetailPriceDiscount { get; private set; }

        [Required]
        [Format(formatValue)]
        [GF("Valor de Crédito")]
        public decimal CreditValue { get; set; }

        [Required]
        [Format(formatValue)]
        [GF("Montante basico")]
        public decimal GrossRetailPrice { get; private set; }

        [Required]
        [Format(formatValue)]
        [GF("TaxaImp")]
        public decimal PercentISS { get; private set; }

        [Required]
        [Format(formatValue)]
        [GF("Valor fiscal")]
        public decimal TotalTax { get; private set; }

        [GF("CFOP")]
        public string Cfop { get => cfop; }

        [GF("Rg")]
        public string RG { get => rg; }

        [ValidDoc]
        [GF("CNPJ")]
        [Format(cnpjFormat)]
        public string Cnpj { get; private set; }

        [Required]
        [GF("Ref.doc.origem")]
        public string InvoiceNumberRefDocOrigem { get; private set; }

        [GF("Dt.estorno")]
        public DateTime? ReversalDate { get; } = null;

        [Required]
        [MaxLength(35)]
        [GF("Cidade")]
        public string CityBilling { get; private set; }

        [Required]
        [MaxLength(8)]
        [GF("CodigoPost")]
        [Format(zipCodeFormat)]
        public string ZipCodeBilling
        {
            get { return zipCodeBilling; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    zipCodeBilling = value.Replace("-", "");
                else
                    zipCodeBilling = value;
            }
        }

        [Required]
        [MaxLength(60)]
        [GF("Rua")]
        public string StreetBilling { get; private set; }

        [GF("Zona")]
        public string Zone { get => zone; }

        [Required]
        [ValidDoc]
        [GF("CPF")]
        [Format(cpfFormat)]
        public string Cpf { get; private set; }

        [Required]
        [ValidDoc]
        [GF("CNPJ Prestador de Servico")]
        [Format(cnpjFormat)]
        public string CnpjMarketPlace { get; private set; }

        [Required]
        [GF("Razao Social")]
        public string CompanyNameMarketPlace { get; private set; }

        [Required]
        [GF("CCM")]
        public string MunicipalTaxpayerRegistration { get; private set; }

        [Required]
        [MaxLength(150)]
        [GF("Numero do Processo Regime Especial")]
        public string SpecialProcedureNumber { get; private set; }

        [Required]
        [MaxLength(10)]
        [GF("Codigo do Servico Prestado (Prefeitura)")]
        public string ServiceCodeCity { get; private set; }

        [Required]
        [GF("Numero de Contrato Cliente")]
        public string CustomerCode { get; private set; }

        [Required]
        [Format(formatDate)]
        [GF("Vencimento Fatura Cliente")]
        public DateTime DueDate { get; private set; }

        [NotMapped]
        [Format(monthFormat)]
        public DateTime CycleFatDate { get; private set; }

        [Required]
        [NotMapped]
        public string StoreAcronym { get; private set; }

        [NotMapped]
        public StoreType StoreType { get; private set; }

        public SpecialRegime(string invoiceNumber, string serviceCode, string serviceName, DateTime invoiceCreationDate, string companyName, decimal totalInvoicePrice, decimal totalRetailPriceDiscount,
            decimal creditValue, decimal grossRetailPrice, decimal percentISS, decimal totalTax, string cnpj, string invoiceNumberRefDocOrigem, string cityBilling, string zipCodeBilling, string streetBilling,
            string cpf, string cnpjMarketPlace, string companyNameMarketPlace, string municipalTaxpayerRegistration, string specialProcedureNumber, string serviceCodeCity, string customerCode, DateTime dueDate, DateTime cycleFatDate, string storeAcronym)
        {
            this.InvoiceNumber = invoiceNumber;
            this.ServiceCode = serviceCode;
            this.ServiceName = serviceName;
            this.InvoiceCreationDate = invoiceCreationDate;
            this.CompanyName = companyName;
            this.TotalInvoicePrice = totalInvoicePrice;
            this.TotalRetailPriceDiscount = totalRetailPriceDiscount;
            this.CreditValue = creditValue;
            this.GrossRetailPrice = grossRetailPrice;
            this.PercentISS = percentISS;
            this.TotalTax = totalTax;
            this.Cnpj = cnpj;
            this.InvoiceNumberRefDocOrigem = invoiceNumberRefDocOrigem;
            this.CityBilling = cityBilling;
            this.ZipCodeBilling = zipCodeBilling;
            this.StreetBilling = streetBilling;
            this.Cpf = cpf;
            this.CnpjMarketPlace = cnpjMarketPlace;
            this.CompanyNameMarketPlace = companyNameMarketPlace;
            this.MunicipalTaxpayerRegistration = municipalTaxpayerRegistration;
            this.SpecialProcedureNumber = specialProcedureNumber;
            this.ServiceCodeCity = serviceCodeCity;
            this.CustomerCode = customerCode;
            this.DueDate = dueDate;
            this.CycleFatDate = cycleFatDate;
            this.StoreAcronym = storeAcronym;

            StoreType = Util.ToEnum<StoreType>(storeAcronym);
        }

        public static string GetFileName(StoreType storeType, DateTime cycleFatDate)
            => $"Relatorio_MODELO_REGIME_SANTANA_DO_PARNAIBA_{storeType}-{string.Format(monthFormat, cycleFatDate)}.csv";

        public IList<ValidationResult> ValidateModel()
            => Util.ValidateModel(this);

        public string[] GetConstantsValues()
            => new string[] { formatDate, formatValue, monthFormat, zipCodeFormat, cpfFormat, cnpjFormat };
    }
}
