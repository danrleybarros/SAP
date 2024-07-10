using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser.Mapping;

namespace Gcsb.Connect.SAP.Infrastructure.FileConvert.TsvBoletoConvert
{
    public class PaymentFeedItemTsvMap : CsvMapping<PaymentFeedItem>
    {
        public PaymentFeedItemTsvMap() : base()
        {
            MapProperty(0, x => x.Item);
            MapProperty(1, x => x.DataProcessamento);
            MapProperty(2, x => x.NSA);
            MapProperty(3, x => x.CicloFaturamento);
            MapProperty(4, x => x.UFPagamento);
            MapProperty(5, x => x.DataPagamento);
            MapProperty(6, x => x.NumeroInvoice);
            MapProperty(7, x => x.DataPagamentoAtribuicao);
            MapProperty(8, x => x.ValorPagamento);
            MapProperty(9, x => x.CodigoBanco);
            MapProperty(10, x => x.NomeBanco);
            MapProperty(11, x => x.CodigoConvenio);
            MapProperty(12, x => x.CodigoCliente);
            MapProperty(13, x => x.DataVencimento);
            MapProperty(14, x => x.MesAnoFaturamento);
            MapProperty(15, x => x.CodigoBarras);
            MapProperty(16, x => x.ValorRecebido);
        }
    }
}