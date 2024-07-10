using System;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;

namespace Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount
{
    public class DeferralFinancialAccount : IEntity
    {
        public Guid Id { get; private set; }
        public string Store { get; private set; }
        public string Interface { get; private set; }
        public string ServiceCode { get; private set; }
        public string ServiceName { get; private set; }
        public string OfferCode { get; private set; }
        public string OfferName { get; private set; }
        public string FinancialAccount { get; private set; }
        public DeferralAccount LongTermTotal { get; private set; }
        public DeferralAccount LongTermInstallment { get; private set; }
        public DeferralAccount LongTermProvision { get; private set; }
        public DeferralAccount ShortTermTotal { get; private set; }
        public DeferralAccount ShortTermInstallment { get; private set; }
        public DeferralAccount ShortTermLowProvision { get; private set; }
        public DeferralAccount LongTermLowProvision { get; private set; }

        public DeferralFinancialAccount()   { }

        public DeferralFinancialAccount(Guid id, string store, string Interface, string serviceCode, string serviceName, string offerCode, string offerName, string financialAccount, DeferralAccount longTermTotal, DeferralAccount longTermInstallment, DeferralAccount longTermProvision, DeferralAccount shortTermTotal, DeferralAccount shortTermInstallment, DeferralAccount shortTermLowProvision, DeferralAccount longTermLowProvision)
        {
            Id = id;
            Store = store;
            this.Interface = Interface;
            ServiceCode = serviceCode;
            ServiceName = serviceName;
            OfferCode = offerCode;
            OfferName = offerName;
            FinancialAccount = financialAccount;
            LongTermTotal = longTermTotal;
            LongTermInstallment = longTermInstallment;
            LongTermProvision = longTermProvision;
            ShortTermTotal = shortTermTotal;
            ShortTermInstallment = shortTermInstallment;
            ShortTermLowProvision = shortTermLowProvision;
            LongTermLowProvision = longTermLowProvision;

        }

        public long GetAccountingAccountByType(AccountingAccountDeferralType accountingAccountDeferralType, AccountingEntryType accountingEntryType)
            => accountingAccountDeferralType switch
            {
                AccountingAccountDeferralType.ShortTermTotal => accountingEntryType == AccountingEntryType.Credit ? ShortTermTotal.Credit : ShortTermTotal.Debit,
                AccountingAccountDeferralType.ShortTermInstallment => accountingEntryType == AccountingEntryType.Credit ? ShortTermInstallment.Credit : ShortTermInstallment.Debit,
                AccountingAccountDeferralType.ShortTermLowProvision => accountingEntryType == AccountingEntryType.Credit ? ShortTermLowProvision.Credit : ShortTermLowProvision.Debit,
                AccountingAccountDeferralType.LongTermTotal => accountingEntryType == AccountingEntryType.Credit ? LongTermTotal.Credit : LongTermTotal.Debit,
                AccountingAccountDeferralType.LongTermInstallment => accountingEntryType == AccountingEntryType.Credit ? LongTermInstallment.Credit : LongTermInstallment.Debit,
                AccountingAccountDeferralType.LongTermProvision => accountingEntryType == AccountingEntryType.Credit ? LongTermProvision.Credit : LongTermProvision.Debit,
                AccountingAccountDeferralType.LongTermLowProvision => accountingEntryType == AccountingEntryType.Credit ? LongTermLowProvision.Credit : LongTermLowProvision.Debit,
                _ => throw new NotSupportedException(nameof(AccountingEntryType))
            };
        

    }
}
