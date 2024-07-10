using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Download
{
    public class DownloadUseCaseRequest
    {
        public Guid FileId { get; private set; }
        public string Base64 { get; set; }
        public List<Log> Logs { get; set; }
        public List<Messaging.Messages.File.File> Interfaces { get; set; }
        public byte[] BytesZip { get; set; }
        public List<Domain.Upload.InterfaceProgress> InterfacesProgress { get; set; }

        public DownloadUseCaseRequest(Guid fileId)
        {
            FileId = fileId;
            Logs = new List<Log>();
            Interfaces = new List<Messaging.Messages.File.File>();
        }

        public void AddProcessingLog(string message)
        {
            Logs.Add(new Log("Download file", message, TypeLog.Processing));
        }

        public void AddProcessingLog(string message, Guid fileId)
        {
            Logs.Add(new Log("Download file", fileId, message, TypeLog.Processing));
        }

        public void AddExceptionLog(Guid fileId, string message, string stackTrace)
        {
            Logs.Add(new Log("Download file", fileId, message, TypeLog.Error, stackTrace));
        }

        public void AddExceptionLog(string message, string stackTrace)
        {
            Logs.Add(new Log("Download file", message, TypeLog.Error, stackTrace));
        }
    }
}
