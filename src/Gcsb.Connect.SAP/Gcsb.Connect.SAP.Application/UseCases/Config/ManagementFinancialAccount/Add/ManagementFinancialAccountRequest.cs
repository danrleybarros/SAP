using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Add
{

    public class ManagementFinancialAccountRequest
    {
       
        public string UserId { get; private set; }
        public Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount ManagementFinancialAccount { get; private set; }
    
        public List<Log> Logs { get; private set; }

        public ManagementFinancialAccountRequest(string userId, Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount managementFinancialAccount)
        {
            this.UserId = userId;
            this.ManagementFinancialAccount = managementFinancialAccount;
            Logs = new List<Log>();
        }

        public void AddLog(string service, string message, TypeLog type)
            => Logs.Add(new Log(service, message, type));

        public void AddLogException(string service, string message, string stacktrace, TypeLog type)
        => Logs.Add(new Log(service, message, type, stacktrace, UserId));

    }

}
