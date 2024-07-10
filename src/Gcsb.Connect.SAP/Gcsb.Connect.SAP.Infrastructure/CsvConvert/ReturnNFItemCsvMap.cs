using System.Globalization;
using TinyCsvParser.Mapping;

namespace Gcsb.Connect.SAP.Infrastructure.CsvConvert
{
    class ReturnNFItemCsvMap : CsvMapping<ReturnNFItem>
    {
        public ReturnNFItemCsvMap() : base()
        {
            MapProperty(0, x => x.InvoiceID);
            MapProperty(1, x => x.NumeroNF);
            MapProperty(2, x => x.SerieNF);
            MapProperty(3, x => x.DataEmissaoNF, new TinyCsvParser.TypeConverter.DateTimeConverter("dd/MM/yyyy"));
            MapProperty(4, x => x.ValorTotalNF, new TinyCsvParser.TypeConverter.DecimalConverter(new CultureInfo("pt-BR")));
            MapProperty(5, x => x.ValorTotalDescontoNF, new TinyCsvParser.TypeConverter.DecimalConverter(new CultureInfo("pt-BR")));
            MapProperty(6, x => x.NFCancelada);
            MapProperty(7, x => x.ChaveNF);
        }
    }
}
