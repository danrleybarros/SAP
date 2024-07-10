using System;
using System.Collections.Generic;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Domain.GF;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using File = Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport
{
    public class IndividualReportRequestNF
    {
        private const string service = "IndividualReport";

        public string Service { get => service; }
        public Guid IdBillFeedFile { get; private set; }
        public List<JsdnStore> Stores { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<UfOutput> UfOutputs { get; set; }
        public List<CepOutput> Logradouros { get; set; }
        public List<IndividualReportNF> IndividualReports { get; set; }
        public Dictionary<StoreType, Guid> IndividualFiles { get; set; }
        public List<File::File> Files { get; set; }
        public string OutputFile { get; set; }
        public bool UploadFile { get; set; }
        public List<Log> Logs { get; set; }

        public IndividualReportRequestNF(Guid idBillFeedFile)
        {
            IdBillFeedFile = idBillFeedFile;
            Stores = new List<JsdnStore>();
            Invoices = new List<Invoice>();
            UfOutputs = new List<UfOutput>();
            Logradouros = new List<CepOutput>();
            IndividualReports = new List<IndividualReportNF>();
            IndividualFiles = new Dictionary<StoreType, Guid>();
            Files = new List<File::File>();
            Logs = new List<Log>();
        }
    }
}
