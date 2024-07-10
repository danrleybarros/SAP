using Gcsb.Connect.Messaging.Messages.File.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Domain.JSDN
{
    public class PaymentCreditCard : PaymentFeedDoc
    {
        [Required]
        public int ResultCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        [MaxLength(4)]
        public string VersionId { get; set; }

        //[Required]
        [MaxLength(11)]
        public string TerminalId { get; set; }

        [Required]
        [MaxLength(15)]
        public string MerchantId { get; set; }

        public int? ServiceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserId { get; set; }

        [Required]
        [MaxLength(4)]
        public string TypeOperation { get; set; }

        public string ProcessCode { get; set; }

        [MaxLength(20)]
        public string OrderId { get; set; }

        [MaxLength(19)]
        public string CardPan { get; set; }

        [MaxLength(4)]
        public string CardExpirationDate { get; set; }

        public int? MerchantCurrency { get; set; }

        public string Currency { get; set; }

        [MaxLength(40)]
        public string OriginIPAddress { get; set; }

        public int? SIAOperationNumber { get; set; }

        [MaxLength(6)]
        public string AuthorizationID { get; set; }

        [Range(0.0, Double.MaxValue)]
        public decimal? AlternativeAmount { get; set; }

        public int? AlternativeCurrency { get; set; }

        [MaxLength(60)]
        public string CustomerEmail { get; set; }

        [MaxLength(10)]
        public string MerchantSession { get; set; }

        public int? BatchID { get; set; }

        [MaxLength(999)]
        public string DataPrint { get; set; }

        //TODO: Verificar o que é essa propriedade
        public string UrlPuce { get; set; }

        //TODO: Verificar o que é essa propriedade
        public string UrlAuthPath { get; set; }

        [MaxLength(4)]
        public string AcquirerEntity { get; set; }

        [MaxLength(2)]
        public string PlanType { get; set; }

        public int? InstallmentsNumber { get; set; }

        public int? GracePeriod { get; set; }

        [Range(0.0, Double.MaxValue)]
        public decimal? InterestAmount { get; set; }

        public long? ExtendedSIAOperationNumber { get; set; }

        [MaxLength(40)]
        public string AcquirerTransactionID { get; set; }

        public int? BankIdentificationNumber { get; set; }

        [MaxLength(4)]
        public string CardIssuer { get; set; }

        public int? CardIssuerCountry { get; set; }

        public int? CardBrand { get; set; }

        public int? CardCategory { get; set; }

        public string PaymentDate { get; set; }

        public string CreditCard { get; set; }

        public string CreditCardNSU { get; set; }

        public string AuthorizationCode { get; set; }

        public string CardLabel { get; set; }

        public string Acquirer { get; set; }

        public decimal? PaymentValue { get; set; }

        [MaxLength(1)]
        public string CardType { get; set; }

        protected PaymentCreditCard() { }

        public PaymentCreditCard(Guid IdFile, int resultCode, string description, string versionId, string terminalId, string entityId, string merchantId, int? serviceId,
           string userId, string typeOperation, string processCode, string orderId, string cardPan, string cardExpirationDate, decimal? transactionAmount, int? merchantCurrency,
           string currency, string originIPAddress, string dateTimeSIA, string dateTimePayment, DateTime? transactionDate, int? siaOperationNumber, string authorizationID,
           decimal? alternativeAmount, int? alternativecurrency, string customerEmail, string merchantSession, int? batchID, string dataPrint, string urlPUCE, string url_AUTH_PATH,
           string acquirerEntity, string planType, int? installmentsNumber, int? gracePeriod, decimal? interestAmount, long? extendedSIAOperationNumber, string acquirerTransactionID,
           int? bankIdentificationNumber, string cardIssuer, int? cardIssuerCountry, int? cardBrand, int? cardCategory, string cardType, string invoiceNumberJsdn, DateTime dateProcessing,
           string paymentDate, string creditCard, string creditCardNSU, string authorizationCode, string cardLabel, string acquirer, decimal? paymentValue)
            : base(Guid.NewGuid(), IdFile, invoiceNumberJsdn, transactionAmount, dateTimeSIA, dateTimePayment, transactionDate, entityId, TypePaymentMethod.CreditCard, dateProcessing)
        {
            this.IdFile = IdFile;
            ResultCode = resultCode;
            Description = description;
            VersionId = versionId;
            TerminalId = terminalId;
            EntityId = entityId;
            MerchantId = merchantId;
            ServiceId = serviceId;
            UserId = userId;
            TypeOperation = typeOperation;
            ProcessCode = processCode;
            OrderId = orderId;
            CardPan = cardPan;
            CardExpirationDate = cardExpirationDate;
            TransactionAmount = transactionAmount;
            MerchantCurrency = merchantCurrency;
            Currency = currency;
            OriginIPAddress = originIPAddress;
            DateTimeSIA = dateTimeSIA;
            DateTimePayment = dateTimePayment;
            TransactionDate = transactionDate;
            SIAOperationNumber = siaOperationNumber;
            AuthorizationID = authorizationID;
            AlternativeAmount = alternativeAmount;
            AlternativeCurrency = alternativecurrency;
            CustomerEmail = customerEmail;
            MerchantSession = merchantSession;
            BatchID = batchID;
            DataPrint = dataPrint;
            UrlPuce = urlPUCE;
            UrlAuthPath = url_AUTH_PATH;
            AcquirerEntity = acquirerEntity;
            PlanType = planType;
            InstallmentsNumber = installmentsNumber;
            GracePeriod = gracePeriod;
            InterestAmount = interestAmount;
            ExtendedSIAOperationNumber = extendedSIAOperationNumber;
            AcquirerTransactionID = acquirerTransactionID;
            BankIdentificationNumber = bankIdentificationNumber;
            CardIssuer = cardIssuer;
            CardIssuerCountry = cardIssuerCountry;
            CardBrand = cardBrand;
            CardCategory = cardCategory;
            CardType = cardType;
            InvoiceNumberJsdn = invoiceNumberJsdn;
            PaymentDate = paymentDate;
            CreditCard = creditCard;
            CreditCardNSU = creditCardNSU;
            AuthorizationCode = authorizationCode;
            CardLabel = cardLabel;
            Acquirer = acquirer;
            PaymentValue = paymentValue;
        }
    }
}
