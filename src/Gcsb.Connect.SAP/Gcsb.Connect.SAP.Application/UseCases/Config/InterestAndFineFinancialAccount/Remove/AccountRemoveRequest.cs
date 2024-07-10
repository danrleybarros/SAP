using Gcsb.Connect.Messaging.Messages.Log;
using Domain = Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using System;
using System.Collections.Generic;
using System.Text;
using Gcsb.Connect.Messaging.Messages.Log.Enum;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Remove
{
    public class AccountRemoveRequest
    {
        public Guid Id { get; private set; }
        public string UserId { get; private set; }
        public List<Log> Logs { get; private set; }
        public Domain::InterestAndFineFinancialAccount InterestAndFineFinancialAccount { get; private set; }

        public AccountRemoveRequest(Guid id, string userId)
        {
            Id = id;
            UserId = userId;
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
