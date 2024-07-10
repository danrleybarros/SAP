using System;
using System.Collections.Generic;
using System.Text;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.Upload;

namespace Gcsb.Connect.SAP.Application.UseCases.File
{

    public class UploadStatusRequest
    {
        public List<Domain.Upload.Upload> Uploads { get; set; }
        public List<Log> Logs { get; set; }
        public string UserId { get; set; }
        public bool HasExecuted { get; set; }
        public List<UploadStatusDto> Output { get; set; }
        public List<Messaging.Messages.File.File> UploadFiles { get; set; }

        public UploadStatusRequest(string userId)
        {
            UserId = userId;
            Uploads = new List<Domain.Upload.Upload>();
            Logs = new List<Log>();
            HasExecuted = true;
            UploadFiles = new List<Messaging.Messages.File.File>();
        }

        public void AddProcessingLog( string service ,string message, string stackTrace = null)
            => Logs.Add(new Log( service, message, TypeLog.Processing, stackTrace ?? message));


        public void AddErrorLog( string service, string message, string stackTrace = null)
            => Logs.Add(new Log( service, message, TypeLog.Error, stackTrace ?? message));
    }
}

