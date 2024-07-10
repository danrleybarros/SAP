using System;

namespace Gcsb.Connect.SAP.Infrastructure.FileConvert.TsvBoletoConvert
{
    public class PaymentFeedItem
    {
        public int Item { get; set; }

        public string DataProcessamento { get; set; }

        public int? NSA { get; set; }

        public int CicloFaturamento { get; set; }

        public string UFPagamento { get; set; }

        public string DataPagamento { get; set; }

        public string NumeroInvoice { get; set; }

        public string DataPagamentoAtribuicao { get; set; }

        public decimal ValorPagamento { get; set; }

        public int CodigoBanco { get; set; }

        public string NomeBanco { get; set; }

        public string CodigoConvenio { get; set; }

        public string CodigoCliente { get; set; }

        public string DataVencimento { get; set; }

        public string MesAnoFaturamento { get; set; }

        public string CodigoBarras { get; set; }

        public decimal ValorRecebido { get; set; }
    }
}