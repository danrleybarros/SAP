using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using System;

namespace Gcsb.Connect.SAP.Tests.Builders.GF
{
    public partial class ReturnNFBuilder : Builder<ReturnNF>
    {
        public File File;
        public string InvoiceID;
        public string NumeroNF;
        public string SerieNF;
        public DateTime DataEmissaoNF;
        public decimal ValorTotalNF;
        public decimal ValorTotalDescontoNF;
        public string NFCancelada;
        public string ChaveNF;
        public string StoreAcronym;

        public ReturnNFBuilder()
        {
            File = FileBuilder.New().Build();
            InvoiceID = "RSO-1-00000126";
            NumeroNF = "538";
            SerieNF = "NA";
            DataEmissaoNF = DateTime.UtcNow;
            ValorTotalNF = 100.59m;
            ValorTotalDescontoNF = 35.99m;
            NFCancelada = "N";
            ChaveNF = "NA";
            StoreAcronym = "telerese";
        }

        public ReturnNFBuilder WithFile(File file)
        {
            File = file;
            return this;
        }

        public ReturnNFBuilder WithInvoiceID(string invoiceID)
        {
            InvoiceID = invoiceID;
            return this;
        }

        public ReturnNFBuilder WithNumeroNF(string numeronf)
        {
            NumeroNF = numeronf;
            return this;
        }

        public ReturnNFBuilder WithSerieNF(string serienf)
        {
            SerieNF = serienf;
            return this;
        }

        public ReturnNFBuilder WithDataEmissaoNF(DateTime dataemissaonf)
        {
            DataEmissaoNF = dataemissaonf;
            return this;
        }

        public ReturnNFBuilder WithValorTotalNF(decimal valortotalnf)
        {
            ValorTotalNF = valortotalnf;
            return this;
        }

        public ReturnNFBuilder WithValorTotalDescontoNF(decimal valortotaldescontonf)
        {
            ValorTotalDescontoNF = valortotaldescontonf;
            return this;
        }

        public ReturnNFBuilder WithNFCancelada(string nfcancelada)
        {
            NFCancelada = nfcancelada;
            return this;
        }

        public ReturnNFBuilder WithChaveNF(string chavenf)
        {
            ChaveNF = chavenf;
            return this;
        }

        public ReturnNFBuilder WithStoreAcronym(string storeAcronym)
        {
            StoreAcronym = storeAcronym;
            return this;
        }

        public new ReturnNF Build()
            => new ReturnNF(File.Id, InvoiceID, NumeroNF, SerieNF, DataEmissaoNF, ValorTotalNF, ValorTotalDescontoNF, NFCancelada, ChaveNF, StoreAcronym);
    }
}
