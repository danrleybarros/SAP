using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.InterestAndFine.BillFeed.SendBillFeedProcessed
{
    public class SendBillFeedProcessedUcRequest
    {
        public SendBillFeedProcessedUcRequest(string fileName, string cycle)
        {
            Logs = new List<Log>();
            FileName = fileName;
            Cycle = cycle;
        }

        public string FileName { get; private set; }
        public string Cycle { get; private set; }
        public List<Log> Logs { get; private set; }

        public void AddProcessingLog(string message)
        => Logs.Add(new Log("Interest And Fine", message, TypeLog.Processing));

        public void AddExceptionLog(string message, string stackTrace)
            => Logs.Add(new Log("Interest And Fine", message, TypeLog.Error, stackTrace));

    }
}
