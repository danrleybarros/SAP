using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.AJU;
using Gcsb.Connect.SAP.Domain.Config;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using System;
using System.Collections.Generic;
using CounterChargeDispute = Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using Gcsb.Connect.SAP.Domain.Config.CreditGrantedFinancialAccount;
using Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute.Helper;
using Gcsb.Connect.SAP.Domain.Upload;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute
{
    public class CounterchargeDisputeRequest
    {
        public int SequenceFile { get; set; }
        public List<Messaging.Messages.File.File> Files { get; set; }
        public List<ServiceAccountingAccountAJU> ServiceAccountingAccountAdjusment { get; set; }
        public List<ServiceAccountingAccountAJU> ServiceAccountingAccountBillings { get; set; }
        public List<ServiceAccountingAccountAJU> ServiceAccountingAccountNotEmittedPaid { get; set; }
        public List<ServiceAccountingAccountAJU> ServiceAccountingAccountNotEmittedNotPaid { get; set; }
        public AJU AJUDomain { get; set; }
        public List<FinancialAccount> FinancialAccounts { get; set; }/*TODO: OLD*/
        public List<Domain.FinancialAccountsClient.FinancialAccount.FinancialAccount> FinancialAccountsNew { get; set; } /*TODO: NEW*/
        public List<CounterChargeDispute::CounterchargeDispute> CounterchargeDisputesAdjustment { get; set; }
        public List<CounterChargeDispute::CounterchargeDispute> CounterchargeDisputesBilling { get; set; }
        public List<CounterChargeDispute::CounterchargeDispute> CounterchargeDisputes { get; set; }
        public Dictionary<ChargeBackType, List<CounterChargeDispute::CounterchargeDispute>> CounterchargeChargeBack { get; set; }
        public List<InterestAndFineFinancialAccount> InterestAndFineFinancialAccounts { get; set; }
        public List<Log> Logs { get; set; }
        public DateTime DateFrom { get; private set; }
        public DateTime DateTo { get; private set; }
        public bool IsJob { get; private set; }
        public string LoginName { get; private set; }
        public Upload Upload { get; set; }
        public string FileName { get; set; }
        public Guid InterfaceProgressIdParent { get; set; }
        public List<CreditGrantedFinancialAccount> CreditGrantedFinancialAccounts { get; set; }
        public Dictionary<StoreType, List<Launch>> Lines { get; set; }
        public Domain.FinancialAccountsClient.FinancialAccount.AccountDetailsByServiceDto AccountDetailsByService { get; set; }

        public CounterchargeDisputeRequest(DateTime dateFrom, DateTime dateTo, bool isJob = true, string loginName = null)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
            IsJob = isJob;
            LoginName = loginName;
            Logs = new List<Log>();
            CounterchargeDisputesAdjustment = new List<CounterChargeDispute::CounterchargeDispute>();
            CounterchargeDisputesBilling = new List<CounterChargeDispute::CounterchargeDispute>();
            CounterchargeDisputes = new List<CounterChargeDispute::CounterchargeDispute>();
            CounterchargeChargeBack = new Dictionary<ChargeBackType, List<CounterChargeDispute::CounterchargeDispute>>();
            ServiceAccountingAccountAdjusment = new List<ServiceAccountingAccountAJU>();
            ServiceAccountingAccountBillings = new List<ServiceAccountingAccountAJU>();
            ServiceAccountingAccountNotEmittedPaid = new List<ServiceAccountingAccountAJU>();
            ServiceAccountingAccountNotEmittedNotPaid = new List<ServiceAccountingAccountAJU>();            
            Files = new List<Messaging.Messages.File.File>();
            Lines = new Dictionary<StoreType, List<Launch>>();
            FinancialAccounts = new List<FinancialAccount>();
            CreditGrantedFinancialAccounts = new List<CreditGrantedFinancialAccount>();
            InterestAndFineFinancialAccounts = new List<InterestAndFineFinancialAccount>();
            FinancialAccountsNew = new List<Domain.FinancialAccountsClient.FinancialAccount.FinancialAccount>();
        }

        public void AddProcessingLog(string message)
        {
            Logs.Add(new Log("Generate Interface Contestação", message, TypeLog.Processing));
        }

        public void AddExceptionLog(string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface Contestação", message, TypeLog.Error, stackTrace));
        }

        public void AddLaunchs(StoreType storeType, List<Launch> lines)
        {
            if (!this.Lines.ContainsKey(storeType))
                this.Lines.Add(storeType, lines);
            else
                this.Lines[storeType].AddRange(lines);
        }
    }
}
