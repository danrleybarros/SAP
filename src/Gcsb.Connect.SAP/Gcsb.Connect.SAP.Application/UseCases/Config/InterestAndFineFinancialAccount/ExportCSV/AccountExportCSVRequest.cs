using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.ExportCSV
{
    public class AccountExportCSVRequest
    {
        public StoreType Store { get; private set; }
        public StringBuilder ContentCSV { get; set; }
        public List<Domain.Config.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount> InterestAndFineFinancialAccounts { get; set; }
        public List<Log> Logs { get; private set; }

        public AccountExportCSVRequest(StoreType store)
        {
            Store = store;
            InterestAndFineFinancialAccounts = new List<Domain.Config.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount>();
            Logs = new List<Log>();
        }

        public void AddLog(string service, string message)
            => Logs.Add(new Log(service, message, TypeLog.Processing));

        public void AddLogException(string service, string message, string stacktrace, TypeLog type)
            => Logs.Add(new Log(service, message, type, stacktrace, null));
    }
}
