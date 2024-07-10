using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.PAS.RequestHandlers
{
    public class PASChainRequest
    {
        private const string service = @"PAS";
        public string Service { get => service; }
        public Messaging.Messages.File.File FilePaymentFeed { get; set; }       
        public Dictionary<StoreType, List<Domain.PAS.Body>> Lines { get; set; }   
        public List<Log> Logs { get; private set; }
        public List<Messaging.Messages.File.File> PASFile { get; set; }
        public PASChainRequest(Connect.Messaging.Messages.File.File file)
        {
            FilePaymentFeed = file;
            Lines = new Dictionary<StoreType, List<Domain.PAS.Body>>();
            Logs = new List<Log>();
            PASFile = new List<Messaging.Messages.File.File>();
        }

        public void AddProcessingLog(string message)
        {
            Logs.Add(new Log("Generation of PAS interface", message, TypeLog.Processing));
        }

        public void AddExceptionLog(Guid fileId, string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface PAS", fileId, message, TypeLog.Error, stackTrace));
        }

        public void AddExceptionLog(string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface PAS", message, TypeLog.Error, stackTrace));
        }
    }
}
