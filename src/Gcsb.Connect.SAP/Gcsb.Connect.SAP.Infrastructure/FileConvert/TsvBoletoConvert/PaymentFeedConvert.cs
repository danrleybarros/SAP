using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Gcsb.Connect.SAP.Domain.JSDN;
using TinyCsvParser;

namespace Gcsb.Connect.SAP.Infrastructure.FileConvert.TsvBoletoConvert
{
    public class PaymentFeedConvert : Application.Repositories.IPaymentFeedConvertRepository<PaymentBoleto>
    {
        public ICollection<PaymentBoleto> FromTsv(string base64String, Guid idHeader, string fileName)
        {
            var blk = System.Convert.FromBase64String(base64String);
            var tsv = Encoding.Default.GetString(blk);
            tsv = tsv.Replace("\n", Environment.NewLine);
            var dateProcessing = GetDateProcessingFile(fileName);

            CsvParserOptions tsvParserOptions = new CsvParserOptions(true, '\t');
            CsvReaderOptions tsvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });
            CsvParser<PaymentFeedItem> tsvParser = new CsvParser<PaymentFeedItem>(tsvParserOptions, new PaymentFeedItemTsvMap());

            ICollection<PaymentBoleto> coll = tsvParser.ReadFromString(tsvReaderOptions, tsv).Select(r =>
               new PaymentBoleto(
                   idHeader,
                   r.Result.CodigoCliente,
                   r.Result.ValorPagamento,
                   ConvertDate(r.Result.DataProcessamento).ToString("yyyy-MM-dd HH:mm:ss"),
                   ConvertDate(r.Result.DataPagamento).ToString("yyyy-MM-dd HH:mm:ss"),
                   ConvertDate(r.Result.DataPagamentoAtribuicao),
                   r.Result.NumeroInvoice,
                   r.Result.Item,
                   r.Result.NSA,
                   r.Result.UFPagamento,
                   r.Result.CodigoBanco,
                   r.Result.NomeBanco,
                   r.Result.CodigoConvenio,
                   ConvertDate(r.Result.DataVencimento),
                   r.Result.CodigoBarras,
                   r.Result.ValorRecebido,
                   dateProcessing
               )).ToList();

            return coll;
        }

        private DateTime ConvertDate(string date)
        {
            var dateFormat = "dd/MM/yyyy";
            return DateTime.ParseExact(date, dateFormat, CultureInfo.InvariantCulture);
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