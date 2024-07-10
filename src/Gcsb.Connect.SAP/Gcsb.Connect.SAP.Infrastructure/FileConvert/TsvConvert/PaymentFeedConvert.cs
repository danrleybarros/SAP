using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Gcsb.Connect.SAP.Domain.JSDN;
using TinyCsvParser;

namespace Gcsb.Connect.SAP.Infrastructure.FileConvert.TsvConvert
{
    public class PaymentFeedConvert : Application.Repositories.IPaymentFeedConvertRepository<PaymentCreditCard>
    {
        public ICollection<PaymentCreditCard> FromTsv(string base64String, Guid idHeader,string fileName)
        {
            var blk = System.Convert.FromBase64String(base64String);
            var tsv = Encoding.Default.GetString(blk);
            tsv = tsv.Replace("\n", Environment.NewLine);
            var dateProcessing = GetDateProcessingFile(fileName);

            CsvParserOptions tsvParserOptions = new CsvParserOptions(true, '\t');
            CsvReaderOptions tsvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });
            CsvParser<PaymentFeedItem> tsvParser = new CsvParser<PaymentFeedItem>(tsvParserOptions, new PaymentFeedItemTsvMap());
            var teste = tsvParser.ReadFromString(tsvReaderOptions, tsv).Where(w => !w.IsValid).ToList();
            ICollection<PaymentCreditCard> coll = tsvParser.ReadFromString(tsvReaderOptions, tsv).Select(r =>
               new PaymentCreditCard(
                   idHeader,
                   r.Result.ResultCode,
                   r.Result.Description,
                   r.Result.VersionId,
                   r.Result.TerminalId,
                   r.Result.EntityId,
                   r.Result.MerchantId,
                   r.Result.ServiceId,
                   r.Result.UserId,
                   r.Result.TypeOperation,
                   r.Result.ProcessCode,
                   r.Result.OrderId,
                   r.Result.CardPan,
                   r.Result.CardExpirationDate,
                   r.Result.TransactionAmount,
                   r.Result.MerchantCurrency,
                   r.Result.Currency,
                   r.Result.OriginIPAddress,
                   r.Result.DateTimeSIA,
                   r.Result.DateTimePayment,
                   ConvertDate(r.Result.TransactionDate),
                   r.Result.SIAOperationNumber,
                   r.Result.AuthorizationID,
                   r.Result.AlternativeAmount,
                   r.Result.AlternativeCurrency,
                   r.Result.CustomerEmail,
                   r.Result.MerchantSession,
                   r.Result.BatchID,
                   r.Result.DataPrint,
                   r.Result.UrlPuce,
                   r.Result.UrlAuthPath,
                   r.Result.AcquirerEntity,
                   r.Result.PlanType,
                   r.Result.InstallmentsNumber,
                   r.Result.GracePeriod,
                   r.Result.InterestAmount,
                   r.Result.ExtendedSIAOperationNumber,
                   r.Result.AcquirerTransactionID,
                   r.Result.BankIdentificationNumber,
                   r.Result.CardIssuer,
                   r.Result.CardIssuerCountry,
                   r.Result.CardBrand,
                   r.Result.CardCategory,
                   r.Result.CardType,
                   r.Result.InvoiceNumberJsdn,
                   dateProcessing,
                   r.Result.PaymentDate,
                   r.Result.CreditCard,
                   r.Result.CreditCardNSU,
                   r.Result.AuthorizationCode,
                   r.Result.CardLabel,
                   r.Result.Acquirer,
                   r.Result.PaymentValue
               )).ToList();

            return coll;
        }

        private DateTime? ConvertDate(string date)
        {
            if (string.IsNullOrEmpty(date)) return null;
            if (date.Length < 12) throw new ArgumentOutOfRangeException();

            var year = $"20{date.Substring(0, 2)}";
            var month = date.Substring(2, 2);
            var day = date.Substring(4, 2);
            var hour = date.Substring(6, 2);
            var minute = date.Substring(8, 2);
            var second = date.Substring(10, 2);

            return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minute), int.Parse(second));
        }

        private DateTime GetDateProcessingFile(string fileName)
        {
            DateTime dateProcessing;
            var culture = CultureInfo.CreateSpecificCulture("pt-br");

            string dateFile = Regex.Replace(fileName, "[a-z_.A-Z]", string.Empty);            

            if (DateTime.TryParse(dateFile, culture, DateTimeStyles.None, out dateProcessing))
                return dateProcessing;
            else
                throw new ArgumentOutOfRangeException();

        }
    }
}