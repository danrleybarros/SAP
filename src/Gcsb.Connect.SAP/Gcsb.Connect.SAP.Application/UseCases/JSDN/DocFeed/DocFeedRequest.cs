using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN
{
    public class DocFeedRequest
    {        
        public string Base64String { get; set; }

        public Messaging.Messages.File.File File { get; set; }  
        
        public List<IDoc> DocFeed { get; set; }

        public int TotalDocs { get; set; }

        public List<Log> Logs { get; set; }

        public List<ServiceInvoice> Services { get; set; }       

        protected DocFeedRequest(TypeRegister bILL) { }

        public DocFeedRequest()
        {

        }
        public DocFeedRequest(TypeRegister type, string fileName, string base64)
        {
            this.Base64String = base64;
            File = new Connect.Messaging.Messages.File.File(fileName, type);
            DocFeed = new List<IDoc>();
            Logs = new List<Log>();
        }

        public void AddProcessingLog(string title, string message)
        {
            Logs.Add(new Log(title, message, TypeLog.Processing));
        }

        public void AddProcessingLog(string title, string message, Guid fileId)
        {
            Logs.Add(new Log(title, fileId, message, TypeLog.Processing));
        }

        public void AddExceptionLog(string title, Guid fileId, string message, string stackTrace)
        {
            Logs.Add(new Log(title, fileId, message, TypeLog.Error, stackTrace));
        }

        public void AddExceptionLog(string title, string message, string stackTrace)
        {
            Logs.Add(new Log(title, message, TypeLog.Error, stackTrace));
        }

        public void AddErrorValidationLog(string service, Guid fileId, string message, List<LogDetail> logDetails, TypeLog typeLog)
        {
            Logs.Add(new Log(service, fileId, message, logDetails, typeLog));
        }
    }
}
