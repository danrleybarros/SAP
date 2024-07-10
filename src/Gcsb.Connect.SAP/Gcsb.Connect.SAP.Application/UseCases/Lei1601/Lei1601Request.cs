using System;
using System.Collections.Generic;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Domain.LEI1601;
using File = Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.Lei1601
{
    public class Lei1601Request 
    {
        public List<Domain.LEI1601.Lei1601> LeiDomain { get; set; } = new();
        public Domain.LEI1601.Lei1601 Lei { get; set; }
        public DateTime ProcessDate { get; set; }
        public int Sequence { get; set; }
        public string FileName { get; set; }
        public string FileText { get; set; }
        public bool UploadFile { get; set; }
        public DateTime ReferenceDate { get; set; }
        public Dictionary<StoreType, (TypeRegister typeRegister, int sequenceFile)> SequenceFileStore { get; set; }
        public List<Launch> Lines { get; set; } = new();
        public Guid? IDPaymentFeed { get; set; }
        public List<Log> Logs { get; set; } = new();
        public List<File::File> Files { get; set; } = new();

        public void AddExceptionLog(Guid fileId, string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface Lei 1601", fileId, message, TypeLog.Error, stackTrace));
        }

        public void AddExceptionLog(string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface Lei 1601", message, TypeLog.Error, stackTrace));
        }

        public void AddProcessingLog(string message)
        {
            Logs.Add(new Log("Generate Interface Lei 1601", message, TypeLog.Processing));
        }

        public void AddProcessingLog(string message, Guid fileId)
        {
            Logs.Add(new Log("Generate Interface Lei 1601", fileId, message, TypeLog.Processing));
        }
    }
}
