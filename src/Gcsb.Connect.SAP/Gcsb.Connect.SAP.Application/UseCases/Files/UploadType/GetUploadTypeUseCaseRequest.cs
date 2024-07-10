using System;
using System.Collections.Generic;
using System.Text;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.UploadTypeDto;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.UploadType
{
    public class GetUploadTypeUseCaseRequest
    {
        public List<UploadTypeDto> UploadTypes { get; set; }
        public List<Log> Logs { get; set; }
        public long UserId { get; set; }
        public bool HasExecuted { get; set; }

        public GetUploadTypeUseCaseRequest(long userId)
        {
            UserId = userId;
            UploadTypes = new List<UploadTypeDto>();
            Logs = new List<Log>();
        }

        public void AddProcessingLog(string service, string message, string stackTrace = null)
            => Logs.Add(new Log(service, message, TypeLog.Processing, stackTrace ?? message, UserId.ToString()));

        public void AddErrorLog(string service, string message, string stackTrace = null)
               => Logs.Add(new Log(service, message, TypeLog.Error, stackTrace ?? message, UserId.ToString()));

    }
}
