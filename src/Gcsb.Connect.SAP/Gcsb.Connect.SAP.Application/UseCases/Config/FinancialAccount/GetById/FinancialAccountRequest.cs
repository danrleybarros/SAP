
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.FinancialAccount.GetById
{
   public class FinancialAccountRequest
    {      

        public string UserId { get;private set; }
        public Guid Id { get; private set; }
        public Domain.Config.FinancialAccount FinancialAccount { get; private set; }
        public List<Log> Logs { get; private set; }

        public FinancialAccountRequest(string userId, Guid id)
        {
            UserId = userId;
            Id = id;
            Logs = new List<Log>();
        }


        public void AddLog(string service, string message, TypeLog type)
          => Logs.Add(new Log(service, message, type));

        public void AddLogException(string service, string message, string stacktrace, TypeLog type)
            => Logs.Add(new Log(service, message, type, stacktrace, UserId));

        public void AddManagementFinancialAccount(Domain.Config.FinancialAccount financialAccount)
            => FinancialAccount = financialAccount;

    }
}
