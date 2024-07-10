using Gcsb.Connect.SAP.Domain.Log;
using Gcsb.Connect.SAP.Domain.Log.Enum;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Tests.Builders
{
    public class LogBuilder
    {
        public Guid Id;
        public string Service;
        public Guid FileId;
        public string Message;
        public List<LogDetail> LogDetails;
        public DateTime DateLog;
        public TypeLog TypeLog;
        public string StackTrace;

        public static LogBuilder New()
        {
            return new LogBuilder
            {
                Id = Guid.NewGuid(),
                Service = "ReadJsdnFile",
                FileId = Guid.NewGuid(),
                Message = "Falha na conexão com o BD",
                LogDetails = new List<LogDetail>(),
                DateLog = DateTime.UtcNow,
                TypeLog = TypeLog.Error,
                StackTrace = ""
            };
        }

        public LogBuilder WithService(string service)
        {
            Service = service;
            return this;
        }

        public LogBuilder WithFileId(Guid fileId)
        {
            FileId = fileId;
            return this;
        }

        public LogBuilder WithMessage(string message)
        {
            Message = message;
            return this;
        }

        public LogBuilder WithLogDetails(List<LogDetail> logDetails)
        {
            LogDetails = logDetails;
            return this;
        }

        public LogBuilder WithTypeLog(TypeLog typeLog)
        {
            TypeLog = typeLog;
            return this;
        }

        public LogBuilder WithStackTrace(string stackTrace)
        {
            StackTrace = stackTrace;
            return this;
        }

        public Log Build()
        {
            return new Log(Service,                
                FileId,
                Message,
                LogDetails,
                TypeLog,
                StackTrace
            );
        }
    }
}
