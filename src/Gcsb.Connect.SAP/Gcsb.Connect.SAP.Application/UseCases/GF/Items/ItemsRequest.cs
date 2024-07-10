using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Domain.GF;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Items
{
    public class ItemsRequest
    {
        public Guid IdNFFile;
        private const string service = "ItemsReport";
        public Connect.Messaging.Messages.File.File File { get; set; }
        public List<Domain.GF.Items> Items { get; set; }
        public List<Log> Logs { get; set; }
        public List<Invoice> Invoices { get; set; }
        public string OutputFile { get; set; }
        public List<Domain.GF.Nfe.ReturnNF> ReturnNFs { get; set; }
        public string Service { get => service; }
        public List<CodIbgeOutput> CodIbgeOutputs { get; set; }
        public string FileName { get; set; }

        public ItemsRequest(Guid idNFFile)
        {
            this.IdNFFile = idNFFile;
            this.Items = new List<Domain.GF.Items>();
            this.Logs = new List<Log>();
            this.Invoices = new List<Invoice>();
            this.ReturnNFs = new List<Domain.GF.Nfe.ReturnNF>();
            this.CodIbgeOutputs = new List<CodIbgeOutput>();
        }
    }
}
