using Gcsb.Connect.Messaging.Messages.Log;
using Domain = Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using System.Collections.Generic;
using Gcsb.Connect.Messaging.Messages.Log.Enum;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Update
{
    public class AccountUpdateRequest 
    {
        public string UserId { get; private set; }
        public List<Log> Logs { get; private set; }
        public Domain::InterestAndFineFinancialAccount InterestAndFineFinancialAccount { get; private set; }

        public AccountUpdateRequest(string userId, Domain::InterestAndFineFinancialAccount interestAndFineFinancialAccount)
        {
            UserId = userId;
            InterestAndFineFinancialAccount = interestAndFineFinancialAccount;
            Logs = new List<Log>();
        }

        public void AddLog(string service, string message)
            => Logs.Add(new Log(service, message, TypeLog.Processing));

        public void AddLogException(string service, string message, string stacktrace, TypeLog type)
            => Logs.Add(new Log(service, message, type, stacktrace, UserId));
    }
}
