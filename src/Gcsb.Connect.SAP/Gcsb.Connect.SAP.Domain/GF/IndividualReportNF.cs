using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Gcsb.Connect.SAP.Domain.GF
{
    public class IndividualReportNF
    {
        private const string locationServiceProvision = "1";
        private const int retainedIRRFValue = 0;
        private const string expiryCode = "001";
        private const string unity = "UM";
        private const string monthFormat = "{0:MMyyyy}";
        private const string dateFormat = "{0:dd/MM/yyyy}";
        private const string cepFormat = "{0:00000000}";
        private const string valueFormat = "{0:0.00}";
        private const string strComAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç'";
        private const string strSemAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc ";
        private const int quantity = 1;
        private const string serviceCode = "1.03";
        private const string description = "Processamento,armaz. ou hosped. de dados, textos, imagens, videos, paginas eletronicas, apps e sist. de info., entre outros formatos e congeneres";
        private const int retainedISSFValue = 0;
        private const int retainedPISFValue = 0;
        private const int retainedCofinsFValue = 0;

        [Required]
        [GF("CCM")]
        public string CCM { get; private set; }

        [Required]
        [GF("Data Inícial")]
        [Format(dateFormat)]
        public DateTime InitialDate { get; private set; }

        [Required]
        [GF("Data Final")]
        [Format(dateFormat)]
        public DateTime EndDate { get; private set; }

        [Required]
        [GF("Referência")]
        public string Reference { get; private set; }

        [Required]
        [GF("Data Emissão")]
        [Format(dateFormat)]
        public DateTime InvoiceCreationDate { get; private set; }

        [Required]
        [GF("Local Prestação do Serviço")]
        public string LocationServiceProvision { get => locationServiceProvision; }

        [Required]
        [GF("Valor Total da Nota Fiscal")]
        [Format(valueFormat)]
        public double TotalNFValue { get; private set; }

        [Required]
        [GF("Codigo do Serviço Prefeitura")]
        public string CityHallServiceCode { get; private set; }

        [Required]
        [GF("Aliquota ISS")]
        public decimal ISSAliquot { get; private set; }

        [Required]
        [GF("Valor ISS Retido")]
        [Format(valueFormat)]
        public decimal RetainedISSValue { get => retainedISSFValue; }

        [GF("Valor IRRF Retido")]
        [Format(valueFormat)]
        public decimal RetainedIRRFValue { get => retainedIRRFValue; }

        [GF("Valor PIS Retido")]
        [Format(valueFormat)]
        public decimal RetainedPISValue { get => retainedPISFValue; }

        [GF("Valor Cofins Retido")]
        [Format(valueFormat)]
        public decimal RetainedCofinsValue { get => retainedCofinsFValue; }

        [Required]
        [GF("CPF/CNPJ Tomador")]
        public string CNPJ_CPF_Tomador { get => GetCpfCnpj(); }

        [Required]
        [NotMapped]
        public string CPF { get; private set; }

        [NotMapped]
        public string CNPJ { get; private set; }

        [Required]
        [GF("Data Vencimento Fatura")]
        [Format(dateFormat)]
        public DateTime DateDueInvoice { get; private set; }

        [Required]
        [GF("Código de Vencimento")]
        public string ExpiryCode { get => expiryCode; }

        [Required]
        [GF("Código do Serviço - JSDN")]
        public string ServiceCode { get => serviceCode; }

        [Required]
        [GF("Quantidade")]
        public double Quantity { get => quantity; }

        [Required]
        [GF("Unidade")]
        public string Unity { get => unity; }

        [Required]
        [GF("Descrição")]
        public string Description { get => description; }

        [Required]
        [GF("Valor Unitário")]
        [Format(valueFormat)]
        public double UnityValue { get; private set; }

        [Required]
        [GF("Razão Social")]
        public string CompanyName { get; private set; }

        [Required]
        [GF("Inscrição Estadual")]
        public string StateRegistration { get; private set; }

        [Required]
        [NotMapped]
        public string MailingStreet { get; private set; }

        [Required]
        [NotMapped]
        public string MailingNumber { get; private set; }

        [Required]
        [GF("Endereço")]
        public string Address { get => $"{MailingStreet} {MailingNumber}"; }

        [Required]
        [GF("Município")]
        public string County { get; private set; }

        [Required]
        [GF("UF")]
        public string UF { get; private set; }

        [Required]
        [GF("CEP")]
        [Format(cepFormat)]
        public string ZipCode { get; private set; }

        [Required]
        [GF("E-mail do tomador")]
        public string CustomerEmail { get; private set; }

        [Required]
        [NotMapped]
        public string BillingAddress { get; private set; }

        [Required]
        [NotMapped]
        public string BillingNumberAddress { get; private set; }

        [Required]
        [GF("Endereço de cobrança")]
        public string ChargeAddress { get => $"{BillingAddress} {BillingNumberAddress}"; }

        [NotMapped]
        [Format(monthFormat)]
        public DateTime CycleFatDate { get; private set; }

        [Required]
        [GF("E-mail da telefônica")]
        public string TelefonicaEmail { get => Environment.GetEnvironmentVariable("EMAIL_NFE"); }

        [NotMapped]
        public string StoreAcronym { get; private set; }

        [NotMapped]
        public StoreType StoreType { get; private set; }

        public IndividualReportNF(string ccm, DateTime initialDate, DateTime endDate, string reference, DateTime invoiceCreationDate, double totalNFValue, string cityHallServiceCode, decimal iSSAliquot, string cPF, string cNPJ, DateTime dateDueInvoice, double unityValue,
            string companyName, string stateRegistration, string mailingStreet, string numberAddress, string county, string uF, string zipCode, string customerEmail, string billingAddress, string billingNumberAddress, DateTime cycleFatDate, string storeAcronym)
        {
            this.CCM = ccm;
            this.InitialDate = initialDate;
            this.EndDate = endDate;
            this.Reference = reference;
            this.InvoiceCreationDate = invoiceCreationDate;
            this.TotalNFValue = totalNFValue;
            this.CityHallServiceCode = cityHallServiceCode;
            this.ISSAliquot = iSSAliquot;
            this.CPF = cPF;
            this.CNPJ = cNPJ;
            this.DateDueInvoice = dateDueInvoice;
            this.UnityValue = unityValue;
            this.CompanyName = RemoverAcentos(companyName);
            this.StateRegistration = GetStateRegistration(stateRegistration);
            this.MailingStreet = RemoverAcentos(mailingStreet);
            this.MailingNumber = numberAddress;
            this.County = RemoverAcentos(county);
            this.UF = uF;
            this.ZipCode = Regex.Replace(zipCode ?? "", "[-]+", "");
            this.CustomerEmail = customerEmail;
            this.BillingAddress = RemoverAcentos(billingAddress);
            this.BillingNumberAddress = RemoverAcentos(billingNumberAddress);
            this.CycleFatDate = cycleFatDate;
            this.StoreAcronym = storeAcronym;
            this.StoreType = Util.ToEnum<StoreType>(storeAcronym);
        }

        private string GetCpfCnpj()
            => Regex.Replace(string.IsNullOrEmpty(this.CNPJ) ? this.CPF : this.CNPJ, "[.]+|[-]+|[/]+", "");

        private string RemoverAcentos(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            int cont = 0;

            foreach (char c in strComAcentos)
            {
                value = value.Replace(c.ToString().Trim(), strSemAcentos[cont].ToString().Trim());
                cont++;
            }

            return value;
        }

        private string GetStateRegistration(string value)
            => value == null ? value : value.Trim().ToUpper().Equals("ISENTO") ? "" : value;
    }
}