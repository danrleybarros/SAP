using Gcsb.Connect.SAP.Domain.JSDN;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.JSDN
{
    public class PaymentFeedDocBuilder
    {
        public Guid IdFile;
        public int ResultCode;
        public string Description;
        public string VersionId;
        public string TerminalId;
        public string EntityId;
        public string MerchantId;
        public int? ServiceId;
        public string UserId;
        public string TypeOperation;
        public string ProcessCode;
        public string OrderId;
        public string CardPan;
        public string CardExpirationDate;
        public decimal? TransactionAmount;
        public int? MerchantCurrency;
        public string Currency;
        public string OriginIPAddress;
        public string DateTimeSIA;
        public string DateTimePayment;
        public DateTime TransactionDate;
        public int? SIAOperationNumber;
        public string AuthorizationID;
        public decimal? AlternativeAmount;
        public int? AlternativeCurrency;
        public string CustomerEmail;
        public string MerchantSession;
        public int? BatchID;
        public string DataPrint;
        public string UrlPuce;
        public string UrlAuthPath;
        public string AcquirerEntity;
        public string PlanType;
        public int? InstallmentsNumber;
        public int? GracePeriod;
        public decimal? InterestAmount;
        public long? ExtendedSIAOperationNumber;
        public string AcquirerTransactionID;
        public int? BankIdentificationNumber;
        public string CardIssuer;
        public int? CardIssuerCountry;
        public int? CardBrand;
        public int? CardCategory;
        public string CardType;
        public string InvoiceNumberJsdn;
        public DateTime DateProcessing;
        public string PaymentDate;
        public string CreditCard;
        public string CreditCardNSU;
        public string AuthorizationCode;
        public string CardLabel;
        public string Acquirer;
        public decimal? PaymentValue;

        public static PaymentFeedDocBuilder New()
        {
            return new PaymentFeedDocBuilder()
            {
                IdFile = new Guid(),
                ResultCode = 9,
                Description = "APPROVED TOKEN ALREADY CREATED",
                VersionId = "0005",
                TerminalId = "0000",
                EntityId = "TCBR",
                MerchantId = "01200000001",
                ServiceId = 0,
                UserId = "PRUEBA_TOKEN",
                TypeOperation = "1210",
                ProcessCode = "",
                OrderId = "2019371552425332257",
                CardPan = "454881******0004",
                CardExpirationDate = "1220",
                TransactionAmount = 250.00m,
                MerchantCurrency = 986,
                Currency = "",
                OriginIPAddress = "",
                DateTimeSIA = "190312171646",
                DateTimePayment = "190312181532",
                TransactionDate = DateTime.UtcNow,
                SIAOperationNumber = 1580690,
                AuthorizationID = "365724",
                AlternativeAmount = 10.01m,
                AlternativeCurrency = 0,
                CustomerEmail = "",
                MerchantSession = "",
                BatchID = 0,
                DataPrint = "",
                UrlPuce = "",
                UrlAuthPath = "",
                AcquirerEntity = "0005",
                PlanType = "00",
                InstallmentsNumber = 0,
                GracePeriod = 0,
                InterestAmount = 10.01m,
                ExtendedSIAOperationNumber = null,
                AcquirerTransactionID = "000001580690",
                BankIdentificationNumber = 454881,
                CardIssuer = "ES09",
                CardIssuerCountry = 724,
                CardBrand = 01,
                CardCategory = 99,
                CardType = "C",
                InvoiceNumberJsdn = "cre-1-00000028",
                DateProcessing = DateTime.UtcNow,

                //TODO: Verificar no arquivo vindo da JSDN quais os valores possíveis

                PaymentDate = "28/09/2020",
                CreditCard = "TESTE",
                CreditCardNSU = "TESTE",
                AuthorizationCode = "TESTE",
                CardLabel = "TESTE",
                Acquirer = "TESTE",
                PaymentValue = 100.0m,
            };
        }

        public PaymentFeedDocBuilder WithIdFile(Guid idFile)
        {
            IdFile = idFile;
            return this;
        }

        public PaymentFeedDocBuilder WithResultCode(int resultCode)
        {
            ResultCode = resultCode;
            return this;
        }

        public PaymentFeedDocBuilder WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public PaymentFeedDocBuilder WithVersionId(string versionId)
        {
            VersionId = versionId;
            return this;
        }

        public PaymentFeedDocBuilder WithTerminalId(string terminalId)
        {
            TerminalId = terminalId;
            return this;
        }

        public PaymentFeedDocBuilder WithEntityId(string entityId)
        {
            EntityId = entityId;
            return this;
        }

        public PaymentFeedDocBuilder WithMerchantId(string merchantId)
        {
            MerchantId = merchantId;
            return this;
        }

        public PaymentFeedDocBuilder WithServiceId(int? serviceId)
        {
            ServiceId = serviceId;
            return this;
        }

        public PaymentFeedDocBuilder WithUserId(string userId)
        {
            UserId = userId;
            return this;
        }

        public PaymentFeedDocBuilder WithTypeOperation(string typeOperation)
        {
            TypeOperation = typeOperation;
            return this;
        }

        public PaymentFeedDocBuilder WithProcessCode(string processCode)
        {
            ProcessCode = processCode;
            return this;
        }

        public PaymentFeedDocBuilder WithOrderId(string orderId)
        {
            OrderId = orderId;
            return this;
        }

        public PaymentFeedDocBuilder WithCardPan(string cardPan)
        {
            CardPan = cardPan;
            return this;
        }

        public PaymentFeedDocBuilder WithCardExpirationDate(string cardExpirationDate)
        {
            CardExpirationDate = cardExpirationDate;
            return this;
        }

        public PaymentFeedDocBuilder WithTransactionAmount(decimal? transactionAmount)
        {
            TransactionAmount = transactionAmount;
            return this;
        }

        public PaymentFeedDocBuilder WithMerchantCurrency(int? merchantCurrency)
        {
            MerchantCurrency = merchantCurrency;
            return this;
        }

        public PaymentFeedDocBuilder WithCurrency(string currency)
        {
            Currency = currency;
            return this;
        }

        public PaymentFeedDocBuilder WithOriginIPAddress(string originIPAddress)
        {
            OriginIPAddress = originIPAddress;
            return this;
        }

        public PaymentFeedDocBuilder WithDateTimeSIA(string dateTimeSIA)
        {
            DateTimeSIA = dateTimeSIA;
            return this;
        }

        public PaymentFeedDocBuilder WithDateTimePayment(string dateTimePayment)
        {
            DateTimePayment = dateTimePayment;
            return this;
        }

        public PaymentFeedDocBuilder WithTransactionDate(DateTime transactionDate)
        {
            TransactionDate = transactionDate;
            return this;
        }

        public PaymentFeedDocBuilder WithSIAOperationNumber(int? siaOperationNumber)
        {
            SIAOperationNumber = siaOperationNumber;
            return this;
        }

        public PaymentFeedDocBuilder WithAuthorizationID(string authorizationId)
        {
            AuthorizationID = authorizationId;
            return this;
        }

        public PaymentFeedDocBuilder WithAlternativeAmount(decimal? auternativeAmount)
        {
            AlternativeAmount = auternativeAmount;
            return this;
        }

        public PaymentFeedDocBuilder WithAlternativeCurrency(int? alternativeCurrency)
        {
            AlternativeCurrency = alternativeCurrency;
            return this;
        }

        public PaymentFeedDocBuilder WithCustomerEmail(string customerEmail)
        {
            CustomerEmail = customerEmail;
            return this;
        }

        public PaymentFeedDocBuilder WithMerchantSession(string merchantSession)
        {
            MerchantSession = merchantSession;
            return this;
        }

        public PaymentFeedDocBuilder WithBatchID(int? batchId)
        {
            BatchID = batchId;
            return this;
        }

        public PaymentFeedDocBuilder WithDataPrint(string dataPrint)
        {
            DataPrint = dataPrint;
            return this;
        }

        public PaymentFeedDocBuilder WithUrlPuce(string urlPuce)
        {
            UrlPuce = urlPuce;
            return this;
        }

        public PaymentFeedDocBuilder WithUrlAuthPath(string urlAuthPath)
        {
            UrlAuthPath = urlAuthPath;
            return this;
        }

        public PaymentFeedDocBuilder WithAcquirerEntity(string acquirerEntity)
        {
            AcquirerEntity = acquirerEntity;
            return this;
        }

        public PaymentFeedDocBuilder WithPlanType(string planType)
        {
            PlanType = planType;
            return this;
        }

        public PaymentFeedDocBuilder WithInstallmentsNumber(int? installmentsNumber)
        {
            InstallmentsNumber = installmentsNumber;
            return this;
        }

        public PaymentFeedDocBuilder WithGracePeriod(int? gracePeriod)
        {
            GracePeriod = gracePeriod;
            return this;
        }

        public PaymentFeedDocBuilder WithInterestAmount(decimal? interestAmount)
        {
            InterestAmount = interestAmount;
            return this;
        }

        public PaymentFeedDocBuilder WithExtendedSIAOperationNumber(long? extendedSIAOperationNumber)
        {
            ExtendedSIAOperationNumber = extendedSIAOperationNumber;
            return this;
        }

        public PaymentFeedDocBuilder WithAcquirerTransactionID(string acquirerTransationID)
        {
            AcquirerTransactionID = acquirerTransationID;
            return this;
        }

        public PaymentFeedDocBuilder WithBankIdentificationNumber(int? bankIdentificationNumber)
        {
            BankIdentificationNumber = bankIdentificationNumber;
            return this;
        }

        public PaymentFeedDocBuilder WithCardIssuer(string cardIssuer)
        {
            CardIssuer = cardIssuer;
            return this;
        }

        public PaymentFeedDocBuilder WithCardIssuerCountry(int? cardIssuerCountry)
        {
            CardIssuerCountry = cardIssuerCountry;
            return this;
        }

        public PaymentFeedDocBuilder WithCardBrand(int? cardBrand)
        {
            CardBrand = cardBrand;
            return this;
        }

        public PaymentFeedDocBuilder WithCardCategory(int? cardCategory)
        {
            CardCategory = cardCategory;
            return this;
        }

        public PaymentFeedDocBuilder WithCardType(string cardType)
        {
            CardType = cardType;
            return this;
        }

        public PaymentFeedDocBuilder WithInvoiceNumberJsdn(string invoiceNumberJsdn)
        {
            InvoiceNumberJsdn = invoiceNumberJsdn;
            return this;
        }

        public PaymentFeedDocBuilder WithDateProcessing(DateTime dateProcessing)
        {
            DateProcessing = dateProcessing;
            return this;
        }

        public PaymentFeedDocBuilder WithPaymentDate(string paymentDate)
        {
            PaymentDate = paymentDate;
            return this;
        }

        public PaymentFeedDocBuilder WithCreditCard(string creditCard)
        {
            CreditCard = creditCard;
            return this;
        }

        public PaymentFeedDocBuilder WithCreditCardNSU(string creditCardNSU)
        {
            CreditCardNSU = creditCardNSU;
            return this;
        }

        public PaymentFeedDocBuilder WithAuthorizationCode(string authorizationCode)
        {
            AuthorizationCode = authorizationCode;
            return this;
        }

        public PaymentFeedDocBuilder WithCardLabel(string cardLabel)
        {
            CardLabel = cardLabel;
            return this;
        }

        public PaymentFeedDocBuilder WithAcquirer(string acquirer)
        {
            Acquirer = acquirer;
            return this;
        }

        public PaymentFeedDocBuilder WithPaymentValue(decimal? paymentValue)
        {
            PaymentValue = paymentValue;
            return this;
        }

        public PaymentCreditCard Build()
            => new PaymentCreditCard(IdFile, ResultCode, Description, VersionId, TerminalId, EntityId, MerchantId, ServiceId, UserId, TypeOperation, ProcessCode, OrderId, CardPan,
                CardExpirationDate, TransactionAmount, MerchantCurrency, Currency, OriginIPAddress, DateTimeSIA, DateTimePayment, TransactionDate, SIAOperationNumber, AuthorizationID,
                AlternativeAmount, AlternativeCurrency, CustomerEmail, MerchantSession, BatchID, DataPrint, UrlPuce, UrlAuthPath, AcquirerEntity, PlanType, InstallmentsNumber,
                GracePeriod, InterestAmount, ExtendedSIAOperationNumber, AcquirerTransactionID, BankIdentificationNumber, CardIssuer, CardIssuerCountry, CardBrand, CardCategory, CardType,
                InvoiceNumberJsdn, DateProcessing, PaymentDate, CreditCard, CreditCardNSU, AuthorizationCode, CardLabel, Acquirer, PaymentValue);
    }
}