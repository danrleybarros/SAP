using System.Collections.Generic;
using System.IO;
using Gcsb.Connect.SAP.Application.Repositories.FinancialAccounts;
using Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.ManagementFinancialAccount;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Moq;
using Newtonsoft.Json;

namespace Gcsb.Connect.SAP.Tests.Mock
{
    public class FinancialAccountsMock
    {
        public Mock<IFinancialAccountsClient> Execute()
        {
            var mockFinancialAccount = new Mock<IFinancialAccountsClient>();

            var accountDetailsByServiceDto = GetContentFile<AccountDetailsByServiceDto>("getAccountDetailsByService.json");
            var managementFinancialAccountDto = GetContentFile<List<ManagementFinancialAccountDto>>("GetAllManagementFinancialAccount.json");
            var interestAndFineFinancialAccountDto = GetContentFile<List<InterestAndFineFinancialAccountDto>>("GetAllInterestAndFineFinancialAccount.json");

            mockFinancialAccount
                .Setup(s => s.GetAccountDetailsByService(It.IsAny<List<string>>(), It.IsAny<List<string>>()))
                .Returns(accountDetailsByServiceDto);

            mockFinancialAccount.Setup(s => s.GetAllManagementFinancialAccount())
               .Returns(managementFinancialAccountDto);

            mockFinancialAccount.Setup(s => s.GetAllInterestAndFineFinancialAccount())
               .Returns(MountInterestAndFineFinancialAccount(interestAndFineFinancialAccountDto));

            return mockFinancialAccount;
        }

        private TDomain GetContentFile<TDomain>(string fileName)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Samples", fileName);
            var contentFile = File.ReadAllText(fullPath);
            var resultFile = JsonConvert.DeserializeObject<TDomain>(contentFile);

            return resultFile;
        }

        private List<InterestAndFineFinancialAccount> MountInterestAndFineFinancialAccount(List<InterestAndFineFinancialAccountDto> response)
        {
            var interestAndFineFinancialAccounts = new List<InterestAndFineFinancialAccount>();
            response.ForEach(f =>
            {
                if (f.FinancialAccount != null)
                {
                    var interest = new Domain.Config.InterestAndFineFinancialAccount.Account(
                             f.FinancialAccount.Interest.FinancialAccount,
                             f.FinancialAccount.Interest.BilledCounterchargeChargeback,
                             f.FinancialAccount.Interest.GrantedDebit,
                             new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Interest.InterestOrFine.Credit, f.FinancialAccount.Interest.InterestOrFine.Debit),
                             new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Interest.UnpaidInvoice.Credit, f.FinancialAccount.Interest.UnpaidInvoice.Debit),
                             new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Interest.PaidInvoice.Credit, f.FinancialAccount.Interest.PaidInvoice.Debit),
                             new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Interest.CycleEstimate.Credit, f.FinancialAccount.Interest.CycleEstimate.Debit),
                             new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Interest.ChargebackFutureCreditUnusedValue.Credit, f.FinancialAccount.Interest.ChargebackFutureCreditUnusedValue.Debit),
                             new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Interest.ChargebackFutureCreditUsedValue.Credit, f.FinancialAccount.Interest.ChargebackFutureCreditUsedValue.Debit),
                             new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Interest.ChargebackRectifiedBoleto.Credit, f.FinancialAccount.Interest.ChargebackRectifiedBoleto.Debit),
                             new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Interest.GrantedDebitAccounting.Credit, f.FinancialAccount.Interest.GrantedDebitAccounting.Debit));

                    var fines = new Domain.Config.InterestAndFineFinancialAccount.Account(
                            f.FinancialAccount.Fine.FinancialAccount,
                            f.FinancialAccount.Fine.BilledCounterchargeChargeback,
                            f.FinancialAccount.Fine.GrantedDebit,
                            new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Fine.InterestOrFine.Credit, f.FinancialAccount.Fine.InterestOrFine.Debit),
                            new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Fine.UnpaidInvoice.Credit, f.FinancialAccount.Fine.UnpaidInvoice.Debit),
                            new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Fine.PaidInvoice.Credit, f.FinancialAccount.Fine.PaidInvoice.Debit),
                            new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Fine.CycleEstimate.Credit, f.FinancialAccount.Fine.CycleEstimate.Debit),
                            new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Fine.ChargebackFutureCreditUnusedValue.Credit, f.FinancialAccount.Fine.ChargebackFutureCreditUnusedValue.Debit),
                            new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Fine.ChargebackFutureCreditUsedValue.Credit, f.FinancialAccount.Fine.ChargebackFutureCreditUsedValue.Debit),
                            new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Fine.ChargebackRectifiedBoleto.Credit, f.FinancialAccount.Fine.ChargebackRectifiedBoleto.Debit),
                            new Domain.Config.InterestAndFineFinancialAccount.AccountingAccount(f.FinancialAccount.Fine.GrantedDebitAccounting.Credit, f.FinancialAccount.Fine.GrantedDebitAccounting.Debit));

                    interestAndFineFinancialAccounts.Add(new InterestAndFineFinancialAccount(f.Id, Domain.Util.ToEnum<StoreType>(f.FinancialAccount.StoreAcronym), interest, fines));
                }
            });

            return interestAndFineFinancialAccounts;

        }
    }
}
