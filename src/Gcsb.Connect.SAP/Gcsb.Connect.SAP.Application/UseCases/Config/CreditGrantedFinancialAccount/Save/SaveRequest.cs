using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.Save
{
    public class SaveRequest
    {
        public Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount CreditGrantedFinancialAccount { get; private set; }
        public List<Log> Logs { get; private set; }
        
        public SaveRequest(Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount creditGrantedFinancialAccount)
        {
            CreditGrantedFinancialAccount = creditGrantedFinancialAccount;
            Logs = new List<Log>();
        }

        public void AddLog(string service, string message, TypeLog type)
          => Logs.Add(new Log(service, message, type));

        public void AddLogException(string service, string message, string stacktrace)
            => Logs.Add(new Log(service, message, TypeLog.Error, stacktrace));
    }
}
