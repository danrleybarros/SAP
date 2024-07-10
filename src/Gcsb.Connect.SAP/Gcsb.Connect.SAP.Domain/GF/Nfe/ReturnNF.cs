using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gcsb.Connect.SAP.Domain.GF.Nfe
{
    public class ReturnNF
    {
        public Guid Id { get; private set; }

        public Guid FileId { get; private set; }

        [Required]
        [GF("Referência")]
        public string InvoiceID { get; private set; }

        [Required]
        [GF("Número da Nota Fiscal")]
        public string NumeroNF { get; private set; }

        [Required]
        [GF("Série")]
        public string SerieNF { get; private set; }

        [Required]
        [GF("Data de Emissão da NF")]
        public DateTime DataEmissaoNF { get; private set; }

        [Required]
        [GF("Valor total da Nota Fiscal")]
        public decimal ValorTotalNF { get; private set; }

        [Required]
        [GF("Valor total de Desconto na NF")]
        public decimal ValorTotalDescontoNF { get; private set; }

        [Required]
        [GF("Indicador de NF Cancelada")]
        public string NFCancelada { get; private set; }

        [Required]
        [GF("Chave Nfe")]
        public string ChaveNF { get; private set; }

        [Required]
        public string StoreAcronym { get; private set; }

        [NotMapped]
        public StoreType StoreType { get; private set; }

        public ReturnNF(Guid FileId, string invoiceID, string numeroNF, string serieNF, DateTime dataEmissaoNF, decimal valorTotalNF, decimal valorTotalDescontoNF, string nfCancelada, string chaveNF, string storeAcronym)
        {
            Id = Guid.NewGuid();
            this.FileId = FileId;
            InvoiceID = invoiceID;
            NumeroNF = numeroNF;
            SerieNF = serieNF;
            DataEmissaoNF = dataEmissaoNF;
            ValorTotalNF = valorTotalNF;
            ValorTotalDescontoNF = valorTotalDescontoNF;
            NFCancelada = nfCancelada;
            ChaveNF = chaveNF;
            StoreAcronym = storeAcronym;
            StoreType = Util.ToEnum<StoreType>(storeAcronym);
        }
    }
}
