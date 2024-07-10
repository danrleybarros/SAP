using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Get
{
    public class ManagementFinancialAccountRequest
    {
        public string UserId { get; private set; }     
        public List<Log> Logs { get; private set; }
        public StoreType StoreType{ get; set; }

        public Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount ManagementFinancialAccount { get; private set; }

        public ManagementFinancialAccountRequest(StoreType storeType, string userId)
        {
            UserId = userId;
            StoreType = storeType;
            Logs = new List<Log>();           
        }

        public void AddLog(string service, string message, TypeLog type)
            => Logs.Add(new Log(service, message, type));

        public void AddLogException(string service, string message, string stacktrace, TypeLog type)
            => Logs.Add(new Log(service, message, type, stacktrace,UserId));

        public void AddManagementFinancialAccount(Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount managementFinancialAccount)
            => ManagementFinancialAccount = managementFinancialAccount;
    }
}
