using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.GetByStore
{
    public class GetByStoreRequest
    {
        public StoreType StoreAcronym { get; private set; }
        public GetByStoreOutput Output { get; internal set; }
        public List<Log> Logs { get; private set; }

        public GetByStoreRequest(StoreType storeAcronym)
        {
            StoreAcronym = storeAcronym;
            Logs = new List<Log>();
        }

        public void AddLog(string service, string message, TypeLog type)
          => Logs.Add(new Log(service, message, type));

        public void AddLogException(string service, string message, string stacktrace)
            => Logs.Add(new Log(service, message, TypeLog.Error, stacktrace));
    }
}
