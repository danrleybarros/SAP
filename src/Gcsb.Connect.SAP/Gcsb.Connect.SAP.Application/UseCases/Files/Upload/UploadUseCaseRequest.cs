using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Upload
{
    public class UploadUseCaseRequest
    {
        public Domain.Upload.Enum.UploadTypeEnum UploadType { get; private set; }
        public string FileName { get; private set; }
        public string Base64 { get; private set; }
        public string UserId { get; private set; }
        public string NfeFilesJSON { get; set; }
        public List<Log> Logs { get; set; }

        public UploadUseCaseRequest(Domain.Upload.Enum.UploadTypeEnum uploadType, string fileName, string base64, string userId)
        {
            UploadType = uploadType;
            FileName = fileName;
            Base64 = base64;
            UserId = userId;
            Logs = new List<Log>();
        }
        
        public void AddProcessingLog(string message)
        {
            Logs.Add(new Log("Upload file", message, TypeLog.Processing));
        }

        public void AddProcessingLog(string message, Guid fileId)
        {
            Logs.Add(new Log("Upload file", fileId, message, TypeLog.Processing));
        }

        public void AddExceptionLog(Guid fileId, string message, string stackTrace)
        {
            Logs.Add(new Log("Upload file", fileId, message, TypeLog.Error, stackTrace));
        }

        public void AddExceptionLog(string message, string stackTrace)
        {
            Logs.Add(new Log("Upload file", message, TypeLog.Error, stackTrace));
        }
    }
}
