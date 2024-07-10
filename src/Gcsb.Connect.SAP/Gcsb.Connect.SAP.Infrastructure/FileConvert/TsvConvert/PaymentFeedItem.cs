namespace Gcsb.Connect.SAP.Infrastructure.FileConvert.TsvConvert
{
    public class PaymentFeedItem
    {
        public int ResultCode { get; set; }

        public string Description { get; set; }

        public string VersionId { get; set; }

        public string TerminalId { get; set; }

        public string EntityId { get; set; }

        public string MerchantId { get; set; }

        public int? ServiceId { get; set; }

        public string UserId { get; set; }

        public string TypeOperation { get; set; }

        public string ProcessCode { get; set; }

        public string OrderId { get; set; }

        public string CardPan { get; set; }

        public string CardExpirationDate { get; set; }

        public decimal? TransactionAmount { get; set; }

        public int? MerchantCurrency { get; set; }

        public string Currency { get; set; }

        public string OriginIPAddress { get; set; }

        public string DateTimeSIA { get; set; }

        public string DateTimePayment { get; set; }

        public string TransactionDate { get; set; }

        public int? SIAOperationNumber { get; set; }

        public string AuthorizationID { get; set; }

        public decimal? AlternativeAmount { get; set; }

        public int? AlternativeCurrency { get; set; }

        public string CustomerEmail { get; set; }

        public string MerchantSession { get; set; }

        public int? BatchID { get; set; }

        public string DataPrint { get; set; }       

        public string UrlPuce { get; set; }  

        public string UrlAuthPath { get; set; }

        public string AcquirerEntity { get; set; }

        public string PlanType { get; set; }

        public int? InstallmentsNumber { get; set; }

        public int? GracePeriod { get; set; }

        public decimal? InterestAmount { get; set; }

        public long? ExtendedSIAOperationNumber { get; set; }

        public string AcquirerTransactionID { get; set; }

        public int? BankIdentificationNumber { get; set; }

        public string CardIssuer { get; set; }

        public int? CardIssuerCountry { get; set; }

        public int? CardBrand { get; set; }

        public int? CardCategory { get; set; }

        public string CardType { get; set; }

        public string InvoiceNumberJsdn { get; set; }

        public string PaymentDate { get; set; }

        public string CreditCard { get; set; }

        public string CreditCardNSU { get; set; }

        public string AuthorizationCode { get; set; }

        public string CardLabel { get; set; }

        public string Acquirer { get; set; }

        public decimal? PaymentValue { get; set; }
    }
}