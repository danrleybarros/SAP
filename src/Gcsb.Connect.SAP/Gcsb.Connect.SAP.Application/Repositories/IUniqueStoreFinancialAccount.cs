using Gcsb.Connect.SAP.Domain.AJU;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IUniqueStoreFinancialAccount
    {
        string GetAccount(CounterchargeDispute counterchargeDispute, ServiceAccountingAccountAJU serviceAccountingAccountAJU, TypeAccounting typeAccounting, Domain.FinancialAccountsClient.FinancialAccount.AccountDetailsByServiceDto accountDetailsByServiceDto, StoreType storeType);
        string GetAccountFats(ServiceFilter serviceFilter, AccountingEntry accountingEntry, string typeAccounting, Domain.FinancialAccountsClient.FinancialAccount.AccountDetailsByServiceDto accountDetailsByServiceDto, string interfaceType, string accountType, StoreType storeType);
    }
}
