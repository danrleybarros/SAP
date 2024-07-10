using System.Linq;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.AJU;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.CounterChargeDispute;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Application.UseCases.UniqueStore.FinancialAccount
{
    public class UniqueStoreFinancialAccount : IUniqueStoreFinancialAccount
    {
        public string GetAccount(Domain.JSDN.CounterChargeDispute.CounterchargeDispute counterchargeDispute,
            ServiceAccountingAccountAJU serviceAccountingAccountAJU,
            TypeAccounting typeAccounting,
            AccountDetailsByServiceDto accountDetailsByServiceDto, 
            StoreType storeType)
        {
            if (counterchargeDispute != null && serviceAccountingAccountAJU != null)
            {
                if (counterchargeDispute.StoreAcronym.Equals("cloudco") && accountDetailsByServiceDto != null)
                {
                    var service = accountDetailsByServiceDto.Services.Where(w => w.ServiceCode.Equals(counterchargeDispute.CodigoServico) && w.StoreAcronym.Equals("cloudco")).FirstOrDefault();                    
                    var accountDetails = GetAccounts(counterchargeDispute.DisputeType, storeType, service.AccountDetail); 

                    return typeAccounting == TypeAccounting.Debito ? accountDetails.FinancialAccountDeb : accountDetails.FinancialAccountCred;
                }
                else return serviceAccountingAccountAJU.AccountingAccount[0];
            }
            else return "";
        }

        public string GetAccountFats(ServiceFilter serviceFilter,
            AccountingEntry accountingEntry,
            string typeAccounting,
            AccountDetailsByServiceDto accountDetailsByServiceDto,
            string interfaceType,
            string accountType,
            StoreType storeType)
        {
            if (serviceFilter != null && accountingEntry != null)
            {
                if (serviceFilter.StoreAcronym.Equals("cloudco") && accountDetailsByServiceDto != null)
                {
                    var service = accountDetailsByServiceDto.Services.Where(w => w.ServiceCode.Equals(serviceFilter.ServiceCode) && w.StoreAcronym.Equals("cloudco")).FirstOrDefault();
                    var accountDetails = GetAccounts(storeType, service.AccountDetail, interfaceType, accountType);

                    return typeAccounting == "D" ? accountDetails.FinancialAccountDeb : accountDetails.FinancialAccountCred;
                }
                else return accountingEntry.AccountingAccount;
            }
            else return "";
        }

        private string GetAccountType(DisputeType disputeType)
        {
            var accountType = disputeType switch
            {
                DisputeType.FutureAccount => "CounterchargePaid",
                DisputeType.RectifiedBoleto => "CounterchargeUnpaid",
                _=> "CounterchargePaid"
            };

            return accountType;
        }

        private Account GetAccounts(DisputeType disputeType, StoreType storeType, AccountDetail accountDetail)
        {
            var accountType = GetAccountType(disputeType);

            var account = storeType switch
            {
                StoreType.TLF2 => accountDetail.Store,
                _ => accountDetail.Intercompany
            };

            return account.Where(w => w.InterfaceType.Equals("Countercharge") && w.AccountType.Equals(accountType)).FirstOrDefault();
        }

        private Account GetAccounts(StoreType storeType, AccountDetail accountDetail, string interfaceType, string accountType)
        {            
            var account = storeType switch
            {
                StoreType.TLF2 => accountDetail.Store,
                _ => accountDetail.Intercompany
            };

            return account.Where(w => w.InterfaceType.Equals(interfaceType) && w.AccountType.Equals(accountType)).FirstOrDefault();
        }
    }
}
