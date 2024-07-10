using System;

namespace Gcsb.Connect.SAP.Tests.Builders.JSDN
{
    public partial class PaymentBoletoBuilder : Builder<Gcsb.Connect.SAP.Domain.JSDN.PaymentBoleto>
    {
        public PaymentBoletoBuilder()
        {
            Defaults();
        }

        #region Properties

        public Guid IdFile;
        public string EntityId;
        public decimal? TransactionAmount;
        public string DateTimeSIA;
        public string DateTimePayment;
        public DateTime TransactionDate;
        public string InvoiceNumberJsdn;

        public int Item;
        public int? NSA;
        public string UF;
        public int CodigoBanco;
        public string NomeBanco;
        public string CodigoConvenio;
        public DateTime DataVencimento;
        public string CodigoBarras;
        public decimal ValorRecebido;
        public DateTime DateProcessing;
        #endregion

        #region With Methods

        public PaymentBoletoBuilder WithItem(int item)
        {
            Item = item;
            return this;
        }

        public PaymentBoletoBuilder WithNSA(int? nsa)
        {
            NSA = nsa;
            return this;
        }

        public PaymentBoletoBuilder WithUF(string uf)
        {
            UF = uf;
            return this;
        }

        public PaymentBoletoBuilder WithCodigoBanco(int codigobanco)
        {
            CodigoBanco = codigobanco;
            return this;
        }

        public PaymentBoletoBuilder WithNomeBanco(string nomebanco)
        {
            NomeBanco = nomebanco;
            return this;
        }

        public PaymentBoletoBuilder WithCodigoConvenio(string codigoconvenio)
        {
            CodigoConvenio = codigoconvenio;
            return this;
        }

        public PaymentBoletoBuilder WithDataVencimento(DateTime datavencimento)
        {
            DataVencimento = datavencimento;
            return this;
        }

        public PaymentBoletoBuilder WithCodigoBarras(string codigobarras)
        {
            CodigoBarras = codigobarras;
            return this;
        }

        public PaymentBoletoBuilder WithValorRecebido(System.Decimal valorrecebido)
        {
            ValorRecebido = valorrecebido;
            return this;
        }

        public PaymentBoletoBuilder WithEntityId(string entityId)
        {
            EntityId = entityId;
            return this;
        }

        public PaymentBoletoBuilder WithTransactionAmount(decimal? transactionAmount)
        {
            TransactionAmount = transactionAmount;
            return this;
        }

        public PaymentBoletoBuilder WithDateTimeSIA(string dateTimeSIA)
        {
            DateTimeSIA = dateTimeSIA;
            return this;
        }

        public PaymentBoletoBuilder WithDateTimePayment(string dateTimePayment)
        {
            DateTimePayment = dateTimePayment;
            return this;
        }

        public PaymentBoletoBuilder WithTransactionDate(DateTime transactionDate)
        {
            TransactionDate = transactionDate;
            return this;
        }

        public PaymentBoletoBuilder WithInvoiceNumberJsdn(string invoiceNumberJsdn)
        {
            InvoiceNumberJsdn = invoiceNumberJsdn;
            return this;
        }

        public PaymentBoletoBuilder WithDateProcessing(DateTime dateProcessing)
        {
            DateProcessing = dateProcessing;
            return this;
        }
        #endregion

        #region Build
        public new Gcsb.Connect.SAP.Domain.JSDN.PaymentBoleto Build()
        {
            return new Gcsb.Connect.SAP.Domain.JSDN.PaymentBoleto(
                IdFile,
                EntityId,
                TransactionAmount,
                DateTimeSIA,
                DateTimePayment,
                TransactionDate,
                InvoiceNumberJsdn,
                Item,
                NSA,
                UF,
                CodigoBanco,
                NomeBanco,
                CodigoConvenio,
                DataVencimento,
                CodigoBarras,
                ValorRecebido,
                DateProcessing);
        }
        #endregion

        #region Default Methods 
        public new void Defaults()
        {
            IdFile = new Guid();
            EntityId = "TCBR";
            TransactionAmount = 250.00m;
            DateTimeSIA = "190312171646";
            DateTimePayment = "190312181532";
            TransactionDate = DateTime.UtcNow;
            InvoiceNumberJsdn = "cre-1-00000028";

            Item = 1;
            NSA = 1;
            /*** maxlength : 0 ****/
            UF = "SP";
            CodigoBanco = 1;
            /*** maxlength : 0 ****/
            NomeBanco = "Banco";
            /*** maxlength : 0 ****/
            CodigoConvenio = "1";
            DataVencimento = DateTime.UtcNow;
            /*** maxlength : 0 ****/
            CodigoBarras = "123456789012345678901234567890123456789012341232";

            DateProcessing = DateTime.UtcNow;
        }
        #endregion
    }
}
