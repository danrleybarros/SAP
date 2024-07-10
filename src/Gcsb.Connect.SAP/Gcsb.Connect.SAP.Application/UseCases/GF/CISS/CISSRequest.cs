using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.CISS
{
    public class CISSRequest
    {        
        private const string service = "CISSFile";
        public Guid IdFileReturnNF { get; private set; }

        public string CISSDoc { get; set; }
        public List<Domain.GF.CISS> LaunchItems { get; set; }
        public Connect.Messaging.Messages.File.File File { get; set; }
        public int SequenceFile { get; set; }
        public List<ServiceFilter> Services { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<Domain.GF.Nfe.ReturnNF> ReturnNFs { get; set; }
        public List<Log> Logs { get; set; }
        public string Service { get => service; }
        public string CISSFileName { get; set; }

        public CISSRequest(Guid idFileReturnNF)
        {
            this.IdFileReturnNF = idFileReturnNF;
            Logs = new List<Log>();
            Invoices = new List<Invoice>();
            ReturnNFs = new List<Domain.GF.Nfe.ReturnNF>();
            LaunchItems = new List<Domain.GF.CISS>();
        }

        public void AddProcessingLog(string message)
        {
            Logs.Add(new Log("Generate Interface CISS", message, TypeLog.Processing));
        }

        public void AddProcessingLog(string message, Guid fileId)
        {            
            Logs.Add(new Log("Generate Interface CISS", fileId, message, TypeLog.Processing));
        }

        public void AddExceptionLog(Guid fileId, string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface CISS", fileId, message, TypeLog.Error, stackTrace));
        }

        public void AddExceptionLog(string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface CISS", message, TypeLog.Error, stackTrace));
        }
    }
}
