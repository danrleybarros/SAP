using System;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Entities
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

        [Required]
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

        [MaxLength(1)]
        public string CardType { get; set; }

        public string PaymentDate { get; set; }

        public string CreditCard { get; set; }

        public string CreditCardNSU { get; set; }

        public string AuthorizationCode { get; set; }

        public string CardLabel { get; set; }

        public string Acquirer { get; set; }

        public decimal? PaymentValue { get; set; }
    }
}
