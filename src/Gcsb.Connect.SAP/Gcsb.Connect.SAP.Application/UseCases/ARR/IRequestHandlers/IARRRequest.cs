using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.Config.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using File = Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers
{
    public interface IARRRequest<T>
    {
        List<T> ARRDomain { get; set; }
        List<File::File> Files { get; set; }
        int SequenceFile { get; set; }
        public Dictionary<StoreType, (TypeRegister typeRegister, int sequenceFile)> SequenceFileStore { get; set; }
        Guid IDPaymentFeed { get; }
        List<ServiceFilter> Services { get; set; }
        List<ManagementFinancialAccount> Accounts { get; set; }
        List<ManagementFinancialAccountDto> AccountsDto { get; set; }
        List<AccountingEntry> AccountingEntriesArrecadacao { get; set; }
        List<AccountingEntry> AccountingUnassignedEntriesArrecadacao { get; set; }
        List<AccountARR> AccountsARR { get; set; }
        List<PaymentBoleto> paymentBoletos { get; set; }        
        List<PaymentCreditCard> paymentCreditCards { get; set; }
        List<PaymentReport> PaymentReports { get; set; }
        List<Log> Logs { get; set; }
        public List<LaunchItem> ManualPaymentLaunchItems { get; set; }
        List<Domain.Critical.LaunchCritical> Criticals { get; set; }
        public Dictionary<StoreType, List<LaunchItem>> Lines { get; set; }

        void AddProcessingLog(string message);

        void AddProcessingLog(string message, Guid fileId);

        void AddExceptionLog(Guid fileId, string message, string stackTrace);

        void AddExceptionLog(string message, string stackTrace);

        void AddLaunchs(StoreType storeType, List<LaunchItem> lines);
    }
}
