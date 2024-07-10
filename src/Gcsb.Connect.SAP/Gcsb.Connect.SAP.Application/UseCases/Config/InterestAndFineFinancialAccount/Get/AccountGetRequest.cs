using Gcsb.Connect.Messaging.Messages.Log;
using Domain = Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using System.Collections.Generic;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Get
{
    public class AccountGetRequest
    {
        public string UserId { get; private set; }
        public StoreType Store { get; private set; }
        public List<Log> Logs { get; private set; }
        public Domain::InterestAndFineFinancialAccount InterestAndFineFinancialAccount { get; private set; }

        public AccountGetRequest(string userId, StoreType store)
        {
            UserId = userId;
            Store = store;
            Logs = new List<Log>();
        }

        public void AddLog(string service, string message)
            => Logs.Add(new Log(service, message, TypeLog.Processing));

        public void AddLogException(string service, string message, string stacktrace, TypeLog type)
            => Logs.Add(new Log(service, message, type, stacktrace, UserId));

        public void AddManagementFinancialAccount(Domain::InterestAndFineFinancialAccount interestAndFineFinancialAccount)
            => InterestAndFineFinancialAccount = interestAndFineFinancialAccount;
    }
}
