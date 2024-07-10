using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.Config.HistoryConsumption;
using Gcsb.Connect.SAP.Domain.JSDN;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.HistoryConsumption
{
    public class HistoryRequest
    {
        public long CustomerCode { get; private set; }
        public List<BillFeedDoc> BillFeedDocs { get; set; }
        public List<HistoryConsumptionValue> HistoryConsumptions { get; private set; }
        public List<Log> Logs { get; private set; }

        public HistoryRequest(long customerCode)
        {
            this.CustomerCode = customerCode;
            this.BillFeedDocs = new List<BillFeedDoc>();
            this.HistoryConsumptions = new List<HistoryConsumptionValue>();
            this.Logs = new List<Log>();
        }

        public void AddLog(string message, TypeLog typeLog)
            => Logs.Add(new Log("HistoryRequest", message, typeLog));
    }
}
