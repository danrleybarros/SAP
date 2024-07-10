using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Master
{
    public class MasterRequest : IRequest
    {        
        private const string service = "MasterRequest";
        public Guid IdNFFile { get; set; }
        public Connect.Messaging.Messages.File.File File { get; set; }
        public List<Domain.GF.Master> Masters { get; set; }
        public List<Log> Logs { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<Domain.GF.Nfe.ReturnNF> ReturnNFs { get; set; }
        public string OutputFile { get; set; }

        public TypeRegister TypeInterface { get; set; }
        public string FileName { get; set; }
        public string Service { get => service; }
    

        public MasterRequest(Guid idNFFile)
        {
            this.IdNFFile = idNFFile;
            this.Masters = new List<Domain.GF.Master>();
            this.Logs = new List<Log>();
            this.Invoices = new List<Invoice>();
            this.ReturnNFs = new List<Domain.GF.Nfe.ReturnNF>();
        }

        public void AddLog(string messageLog, TypeLog typeLog)
            => this.Logs.Add(new Log("MasterRequestNF", messageLog, typeLog));

        public void AddLog(string messageLog, string stackTrace)
            => this.Logs.Add(new Log("MasterRequestNF", messageLog, TypeLog.Error, stackTrace));

        public void AddExceptionLog(string message, string stackTrace)
            => Logs.Add(new Log("Generate Interface MasterRequestNF", message, TypeLog.Error, stackTrace));
    }
}
