using TinyCsvParser.Mapping;

namespace Gcsb.Connect.SAP.Infrastructure.FileConvert.TsvConvert
{
    public class PaymentFeedItemTsvMap : CsvMapping<PaymentFeedItem>
    {
        public PaymentFeedItemTsvMap() : base()
        {
            MapProperty(0, x => x.ResultCode);
            MapProperty(1, x => x.Description);
            MapProperty(2, x => x.UserId);
            MapProperty(3, x => x.TypeOperation);
            MapProperty(4, x => x.CardExpirationDate);
            MapProperty(5, x => x.TransactionAmount);
            MapProperty(6, x => x.MerchantCurrency);
            MapProperty(7, x => x.Currency);
            MapProperty(8, x => x.OriginIPAddress);
            MapProperty(9, x => x.DateTimeSIA);
            MapProperty(10, x => x.DateTimePayment);
            MapProperty(11, x => x.SIAOperationNumber);
            MapProperty(12, x => x.AuthorizationID);
            MapProperty(13, x => x.CustomerEmail);
            MapProperty(14, x => x.AcquirerEntity);
            MapProperty(15, x => x.ExtendedSIAOperationNumber);
            MapProperty(16, x => x.AcquirerTransactionID);
            MapProperty(17, x => x.BankIdentificationNumber);
            MapProperty(18, x => x.CardIssuer);
            MapProperty(19, x => x.CardIssuerCountry);
            MapProperty(20, x => x.CardBrand);
            MapProperty(21, x => x.CardCategory);
            MapProperty(22, x => x.CardType);
            MapProperty(23, x => x.OrderId);
            MapProperty(24, x => x.VersionId);
            MapProperty(25, x => x.TerminalId);
            MapProperty(26, x => x.EntityId);
            MapProperty(27, x => x.MerchantId);
            MapProperty(28, x => x.ServiceId);
            MapProperty(29, x => x.ProcessCode);
            MapProperty(30, x => x.CardPan);
            MapProperty(32, x => x.TransactionDate);
            MapProperty(33, x => x.AlternativeAmount);
            MapProperty(34, x => x.AlternativeCurrency);
            MapProperty(35, x => x.MerchantSession);
            MapProperty(36, x => x.BatchID);
            MapProperty(37, x => x.DataPrint);
            MapProperty(38, x => x.UrlPuce);
            MapProperty(39, x => x.UrlAuthPath);
            MapProperty(40, x => x.PlanType);
            MapProperty(41, x => x.InstallmentsNumber);
            MapProperty(42, x => x.GracePeriod);
            MapProperty(43, x => x.InterestAmount);            
            MapProperty(44, x => x.InvoiceNumberJsdn);
            MapProperty(45, x => x.PaymentDate);
            MapProperty(46, x => x.CreditCard);
            MapProperty(47, x => x.CreditCardNSU);
            MapProperty(48, x => x.AuthorizationCode);
            MapProperty(49, x => x.CardLabel);
            MapProperty(50, x => x.Acquirer);
            MapProperty(51, x => x.PaymentValue);
        }
    }
}