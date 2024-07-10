using System;
using Gcsb.Connect.Messaging.Messages.Log;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.File
{
    public class LogResult
    {
        public Guid Id { get; private set; }
        public string Service { get; private set; }
        public Guid? FileId { get; private set; }
        public string UserId { get; private set; }
        public string Message { get; private set; }
        public List<LogDetail> LogDetails { get; private set; }
        public DateTime DateLog { get; private set; }
        public string TypeLog { get; private set; }
        public string StackTrace { get; private set; }


        public LogResult(Log log)
        {
            this.Id = log.Id;
            this.Service = log.Service;
            this.FileId = log.FileId;
            this.UserId = log.UserId;
            this.Message = log.Message ;
            this.LogDetails = log.LogDetails;
            this.DateLog = log.DateLog;
            this.TypeLog = log.TypeLog.ToString();
            this.StackTrace = log.StackTrace;
        }

   
    }
}
