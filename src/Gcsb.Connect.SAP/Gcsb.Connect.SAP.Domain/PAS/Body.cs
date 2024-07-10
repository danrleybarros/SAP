using Gcsb.Connect.SAP.Domain.AttributeValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.PAS
{
    public class Body
    {
        // TODO: Atualizar constantes quando houver retorno da Vivo-SAP        
        private const string costCenter = "";//29TR018233";
        private const string internalOrder = null;
        private const string administrator = null;
        private const string lineNumberFormat = @"{0:000000}";
        private const string valueFormat = @"{0:0.00}";        
        private const string dataDocumentFormat = @"{0:yyyyMMdd}";
        private const string cepFormat = @"{0:00000-000}";
        private const string acquirer = "002";
        private const string nsuFormat = @"{0:000000000000}";
        private const string account = "";
        private const string formatCodAuth = @"{0:000000}";
        private const string accountingAccount = "11211411";

        [Required]
        [Range(1, 999999)]
        [Format(lineNumberFormat)]
        public int LineNumber { get; set; }
        [Required]
        [Format(dataDocumentFormat)]
        public DateTime DocumentDate { get; private set; }
        [Required]
        [MaxLength(35)]
        public string CustomerName { get; private set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; private set; }
        [Required]
        [MaxLength(30)]
        public string City { get; private set; }
        [Required]
        [MaxLength(2)]
        public string State { get; private set; }
        [Required]
        [Range(1, 9999999999)]
        [Format(cepFormat)]
        public long CEP { get; private set; }
        [Required]
        [Range(1, 99999999999999)]
        [ValidDoc]
        public string Doc { get; private set; }
        [Required]
        [Range(0.0, Double.MaxValue)]
        [Format(valueFormat)]
        public decimal Value { get; private set; }
        [MaxLength(15)]
        public string Account { get; private set; }
        [MaxLength(10)]
        public string CostCenter { get => costCenter; }
        [MaxLength(12)]
        public string InternalOrder { get => internalOrder; }
        [MaxLength(10)]
        public string TaxAccountDeb { get; private set; }
        [MaxLength(10)]
        public string TaxAccountCred { get; private set; }
        [MaxLength(10)]
        public string TaxCostCenter { get; private set; }
        [Required]
        [MaxLength(20)]        
        public string CreditCard { get; private set; }
        [Required]
        [Range(1, long.MaxValue)]
        [Format(nsuFormat)]
        public long NSU { get; private set; }
        [Required]
        [MaxLength(12)]
        [Format(formatCodAuth)]
        public string AutorizationCode { get; private set; }
        [Range(1, 999)]
        public string Flag { get; private set; }
        [MaxLength(3)]
        public string Administrator { get => administrator; }
        [Required]
        [MaxLength(3)]
        public string Acquirer
        {
            get { return acquirer; }            
        }

        public Body(int lineNumber, DateTime documentDate, string customerName, string address, string city, string state, long cep,
            string doc, decimal value, string account, string creditCard, long nsu, string autorisationCode, string flag)
        {
            LineNumber = lineNumber;
            DocumentDate = documentDate;
            CustomerName = ChangeCustomerName(customerName);
            Address = ChangeAdress(address);
            City = city;
            State = state;
            CEP = cep;
            Doc = doc;
            Value = value;
            Account = account;
            CreditCard = creditCard;
            NSU = nsu;
            AutorizationCode = autorisationCode;
            Flag = PaymentCardNumberToSAP(flag);
        }

        private string PaymentCardNumberToSAP(string flag)
        {
            switch (flag)
            {
                //VISA
                case "1": return "001";
                //MASTERCARD
                case "2": return "002";
                //ELO
                case "30": return "003";
                //DINERS
                case "6": return "004";
                //HiperCard
                case "31": return "005";
                //AMEX
                case "8": return "006";
                default:
                    throw new ArgumentOutOfRangeException("Invalid Card Flag");
            }
        }

        public IList<ValidationResult> ValidateModel()
        {
            return Util.ValidateModel(this);
        }

        public void ChangeState(string state)
        {            
            this.State = state;
        }

        public void ChangeCity(string city)
        {
            this.City = city;
        }

        public string ChangeCustomerName(string customerName)
            => customerName?.Length > 35 ? customerName.Substring(0, 35) : customerName;

        public string ChangeAdress(string adress)
            => adress?.Length > 50 ? adress.Substring(0, 50) : adress;
    }
}
