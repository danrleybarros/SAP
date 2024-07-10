using System.Collections.Generic;
using CreditGranted = Gcsb.Connect.SAP.Domain.Config.CreditGrantedFinancialAccount;
using InterestAndFine = Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount;

namespace Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts
{
    public interface IFinancialAccountsClient
    {        
        AccountDetailsByServiceDto GetAccountDetailsByService(List<string> serviceCodes, List<string> interfaceTypes);
        List<ManagementFinancialAccountDto> GetAllManagementFinancialAccount();
        List<InterestAndFine::InterestAndFineFinancialAccount> GetAllInterestAndFineFinancialAccount();
        List<CreditGranted::CreditGrantedFinancialAccount> GetAllCreditGrantedFinancialAccount();
        List<DeferralFinancialAccount> GetAllDeferralFinancialAccount();
    }
}
