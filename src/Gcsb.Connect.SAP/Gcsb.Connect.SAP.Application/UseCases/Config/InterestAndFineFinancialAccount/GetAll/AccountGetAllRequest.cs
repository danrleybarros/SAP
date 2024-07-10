using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using System.Collections.Generic;
using Domain = Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.GetAll
{
    public class AccountGetAllRequest
    {
        public string UserId { get; private set; }
        public List<Log> Logs { get; private set; }
        public List<Domain::InterestAndFineFinancialAccount> InterestAndFineFinancialAccounts { get; private set; }

        public AccountGetAllRequest(string userId)
        {
            UserId = userId;
            Logs = new List<Log>();
            InterestAndFineFinancialAccounts = new List<Domain::InterestAndFineFinancialAccount>();
        }

        public void AddLog(string service, string message)
            => Logs.Add(new Log(service, message, TypeLog.Processing));

        public void AddLogException(string service, string message, string stacktrace, TypeLog type)
            => Logs.Add(new Log(service, message, type, stacktrace, UserId));

        public void AddManagementFinancialAccount(List<Domain::InterestAndFineFinancialAccount> interestAndFineFinancialAccounts)
            => InterestAndFineFinancialAccounts = interestAndFineFinancialAccounts;
    }
}
