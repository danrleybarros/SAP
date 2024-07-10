using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using File = Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR
{
    public class ARRRequest<T> : IARRRequest<T>
    {
        public List<T> ARRDomain { get; set; }
        public List<File::File> Files { get; set; }
        public int SequenceFile { get; set; }
        public Dictionary<StoreType, (TypeRegister typeRegister, int sequenceFile)> SequenceFileStore { get; set; }
        public Guid IDPaymentFeed { get; private set; }
        public List<ServiceFilter> Services { get; set; }
        public List<ManagementFinancialAccount> Accounts { get; set; }
        public List<ManagementFinancialAccountDto> AccountsDto { get; set; }
        public List<Log> Logs { get; set; }
        public List<AccountingEntry> AccountingEntriesArrecadacao { get; set; }
        public List<AccountingEntry> AccountingUnassignedEntriesArrecadacao { get; set; }
        public List<AccountARR> AccountsARR { get; set; }
        public List<PaymentBoleto> paymentBoletos { get; set; }
        public List<PaymentCreditCard> paymentCreditCards { get; set; }
        public List<PaymentReport> PaymentReports { get; set; }
        public List<Domain.Critical.LaunchCritical> Criticals { get; set; }
        public Dictionary<StoreType, List<LaunchItem>> Lines { get; set; }
        public List<LaunchItem> ManualPaymentLaunchItems { get; set; }

        public ARRRequest(TypeRegister typeRegister, Guid idPayment)
        {
            ARRDomain = new List<T>();
            IDPaymentFeed = idPayment;
            Logs = new List<Messaging.Messages.Log.Log>();
            Services = new List<ServiceFilter>();
            Criticals = new List<Domain.Critical.LaunchCritical>();
            Lines = new Dictionary<StoreType, List<LaunchItem>>();
            Files = new List<File::File>();
            Accounts = new List<ManagementFinancialAccount>();
            AccountsDto = new List<ManagementFinancialAccountDto>();
            AccountingEntriesArrecadacao = new List<AccountingEntry>();
            AccountingUnassignedEntriesArrecadacao = new List<AccountingEntry>();
            AccountsARR = new List<AccountARR>();
            ManualPaymentLaunchItems = new List<LaunchItem>();
            SequenceFileStore = new Dictionary<StoreType, (TypeRegister typeRegister, int sequenceFile)>();
        }

        public void AddProcessingLog(string message)
        {
            Logs.Add(new Log("Generate Interface ARR", message, TypeLog.Processing));
        }

        public void AddProcessingLog(string message, Guid fileId)
        {
            Logs.Add(new Log("Generate Interface ARR", fileId, message, TypeLog.Processing));
        }

        public void AddExceptionLog(Guid fileId, string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface ARR", fileId, message, TypeLog.Error, stackTrace));
        }

        public void AddExceptionLog(string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface ARR", message, TypeLog.Error, stackTrace));
        }

        public void AddLaunchs(StoreType storeType, List<LaunchItem> lines)
        {
            if (!this.Lines.ContainsKey(storeType))
                this.Lines.Add(storeType, lines);
            else
                this.Lines[storeType].AddRange(lines);
        }
    }
}
