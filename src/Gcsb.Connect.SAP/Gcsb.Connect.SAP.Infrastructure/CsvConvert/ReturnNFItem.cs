using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.CsvConvert
{
    public class ReturnNFItem
    {
        public string InvoiceID { get; set; }
        public string NumeroNF { get; set; }
        public string SerieNF { get; set; }
        public DateTime DataEmissaoNF { get; set; }
        public decimal ValorTotalNF { get; set; }
        public decimal ValorTotalDescontoNF { get; set; }
        public string NFCancelada { get; set; }
        public string ChaveNF { get; set; }
    }
}
