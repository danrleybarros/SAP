using System;
using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Helper;
using Gcsb.Connect.SAP.Domain.Deferral;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.FAT.IFAT;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;
using Gcsb.Connect.SAP.Domain.GF;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using File = Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT
{
    public class FATRequest
    {
        public List<Domain.FAT.FATBase.FAT> FATDomain { get; set; }
        public string FATDoc { get; set; }
        public IIdentificationRecord IdentificationRecord { get; set; }
        public Header Header { get; set; }
        public List<ILaunch> LaunchItems { get; set; }
        public List<ILaunch> LaunchInterestAndFine { get; set; }
        public List<ILaunch> LaunchEstimativas { get; set; }
        public List<File::File> Files { get; set; }
        public Guid IdBillFeed { get; set; }
        public int SequenceFile { get; set; }
        public List<ServiceFilter> Services { get; set; }
        public List<ServiceFilter> FineServices { get; set; }
        public List<ServiceFilter> InterestServices { get; set; }
        public List<ServiceFilter> ContractualFineServices { get; set; }
        public List<ServiceFilter> CounterchargeChargebackServices { get; set; }
        public List<Domain.Config.FinancialAccount> Accounts { get; set; } /*TODO: DELETE*/
        public List<Domain.FinancialAccountsClient.FinancialAccount.FinancialAccount> FinancialAccounts { get; set; } /*TODO: NEW*/
        public Domain.FinancialAccountsClient.FinancialAccount.AccountDetailsByServiceDto AccountDetailsByService { get; set; }
        public List<string> InterfaceTypes { get; set; }
        public List<string> AccountTypes { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<CepOutput> Address { get; set; }
        public DateTime BillingCycleDate { get; set; }
        public List<Log> Logs { get; set; }
        public List<AccountingEntry> AccountingEntriesFaturamento { get; set; }
        public List<AccountingEntry> AccountingEntriesDesconto { get; set; }
        public TypeRegister TypeRegister { get; private set; }
        public DateTime Cycle { get => Invoices.Where(w => w.BillTo != null).Max(m => m.BillTo).Value; }
        public Dictionary<StoreType, List<ILaunch>> Lines { get; set; }
        public List<Domain.Config.InterestAndFineFinancialAccount.InterestAndFineFinancialAccount> InterestAndFineFinancialAccounts { get; set; }
        public List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute> CounterchargeDisputes { get; set; }
        public List<AccountingEntry> InterestAccountingEntries { get; set; }
        public List<AccountingEntry> FinesAccountingEntries { get; set; }
        public List<AccountingEntry> ContractualFineAccountingEntries { get; set; }
        public Dictionary<ChargeBackType, List<ServiceFilter>> InterestAndFineCounterchargeChargebackServices { get; set; }
        public List<DeferralOffer> DeferralOffers { get; set; }
        public List<DeferralFinancialAccount> DeferralFinancialAccounts { get; set; }
        public AccountDetailsByServiceDto AccountingAccounts { get; set; }    
        public bool HasDeferral { get; set; }

        public FATRequest(TypeRegister typeRegister, Guid idBillFeed, DateTime billingCycleDate)
        {
            this.FATDomain = new List<Domain.FAT.FATBase.FAT>();
            this.TypeRegister = typeRegister;
            this.IdBillFeed = idBillFeed;
            this.BillingCycleDate = billingCycleDate;
            this.Logs = new List<Log>();
            this.LaunchItems = new List<ILaunch>();
            this.Address = new List<CepOutput>();
            this.AccountingEntriesFaturamento = new List<AccountingEntry>();
            this.AccountingEntriesDesconto = new List<AccountingEntry>();
            this.ContractualFineAccountingEntries = new List<AccountingEntry>();
            this.Lines = new Dictionary<StoreType, List<ILaunch>>();
            this.Files = new List<File::File>();
            this.InterestServices = new List<ServiceFilter>();
            this.FineServices = new List<ServiceFilter>();
            this.ContractualFineServices = new List<ServiceFilter>();
            this.CounterchargeDisputes = new List<Domain.JSDN.CounterChargeDispute.CounterchargeDispute>();
            this.CounterchargeChargebackServices = new List<ServiceFilter>();
            this.InterestAndFineCounterchargeChargebackServices = new Dictionary<ChargeBackType, List<ServiceFilter>>();
            this.FinancialAccounts = new List<Domain.FinancialAccountsClient.FinancialAccount.FinancialAccount>();        
            this.DeferralFinancialAccounts = new List<DeferralFinancialAccount>();
            this.AccountingAccounts = new AccountDetailsByServiceDto();           
        }

        public void AddProcessingLog(string message)
        {
            Logs.Add(new Log("Generate Interface FAT", message, TypeLog.Processing));
        }

        public void AddErrorLog(string message)
        {
            Logs.Add(new Log("Generate Interface FAT", message, TypeLog.Error));
        }

        public void AddProcessingLog(string message, Guid fileId)
        {
            Logs.Add(new Log("Generate Interface FAT", fileId, message, TypeLog.Processing));
        }

        public void AddExceptionLog(Guid fileId, string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface FAT", fileId, message, TypeLog.Error, stackTrace));
        }

        public void AddExceptionLog(string message, string stackTrace)
        {
            Logs.Add(new Log("Generate Interface FAT", message, TypeLog.Error, stackTrace));
        }

        public List<ServiceFilter> ServicesWithoutFinancialAccounts()
            => Services.Where(w => !FinancialAccounts.Select(s => s.ServiceCode).ToList().Contains(w.ServiceCode)).ToList();

        public void AddLaunchs(StoreType storeType, List<ILaunch> lines)
        {
            if (!this.Lines.ContainsKey(storeType))
                this.Lines.Add(storeType, lines);
            else
                this.Lines[storeType].AddRange(lines);
        }     
            
    }
}
