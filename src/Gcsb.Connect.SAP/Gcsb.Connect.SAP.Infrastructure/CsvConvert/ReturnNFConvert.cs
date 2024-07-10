using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCsvParser;

namespace Gcsb.Connect.SAP.Infrastructure.CsvConvert
{
    public class ReturnNFConvert : IReturnNFConvertRepository
    {
        public ICollection<ReturnNF> FromCsv(string base64String, Guid FileId, string storeAcronym)
        {
            var blk = Convert.FromBase64String(base64String);
            var csv = Encoding.UTF8.GetString(blk);
            csv = csv.Replace("\r", Environment.NewLine);
            CsvParserOptions csvParserOptions = new CsvParserOptions(false, ';');
            CsvReaderOptions csvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });
            CsvParser<ReturnNFItem> csvParser = new CsvParser<ReturnNFItem>(csvParserOptions, new ReturnNFItemCsvMap());
            ICollection<ReturnNF> coll = csvParser.ReadFromString(csvReaderOptions, csv).Select(r =>
             new ReturnNF(
                  FileId,
                  r.Result.InvoiceID,
                  r.Result.NumeroNF,
                  r.Result.SerieNF,
                  r.Result.DataEmissaoNF,
                  r.Result.ValorTotalNF,
                  r.Result.ValorTotalDescontoNF,
                  r.Result.NFCancelada,
                  r.Result.ChaveNF,
                  storeAcronym
             )).ToList();

            return coll;
        }
    }
}
