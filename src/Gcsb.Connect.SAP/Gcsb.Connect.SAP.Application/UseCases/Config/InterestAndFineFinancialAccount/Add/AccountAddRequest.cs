using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using System.Collections.Generic;
using Domain = Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Add
{
    public class AccountAddRequest
    {
        public string UserId { get; private set; }
        public Domain::InterestAndFineFinancialAccount InterestAndFineFinancialAccount { get; private set; }
        public List<Log> Logs { get; private set; }

        public AccountAddRequest(string userId, Domain::InterestAndFineFinancialAccount interestAndFineFinancialAccount)
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
