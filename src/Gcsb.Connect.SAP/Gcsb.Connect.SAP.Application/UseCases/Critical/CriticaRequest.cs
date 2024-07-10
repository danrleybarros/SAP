using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Domain.Critical;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Critical
{
    public class CriticaRequest
    {
        public ManagementFinancialAccount Accounts { get; set; }
        public List<LaunchCritical> LaunchItems { get; set; }
        public List<AccountingEntry> AccountingEntriesCritica { get; set; }
        public List<Domain.PAY.Critical> Criticas { get; set; }
        public List<Log> Logs { get; set; }
        public Guid IdPayment { get; private set; }

        public CriticaRequest(Guid idPayment)
        {
            this.IdPayment = idPayment;
            this.LaunchItems = new List<LaunchCritical>();
            this.AccountingEntriesCritica = new List<AccountingEntry>();
            this.Criticas = new List<Domain.PAY.Critical>();
            this.Logs = new List<Log>();
        }

        public void AddProcessingLog(string message)
        {
            Logs.Add(new Log("Generate Interface FAT", message, TypeLog.Processing));
        }

        public void AddExceptionLog(string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface FAT", message, TypeLog.Error, stackTrace));
        }
    }
}
