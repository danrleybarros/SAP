using System;
using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Entities;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.FinancialAccount;
using Gcsb.Connect.SAP.Domain.Deferral;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Deferral.Billed
{
    ///<summary>
    ///US 58601
    ///Cenário 4: Ativação de serviço com diferimento iniciado com número de parcelas MAIOR que 12
    ///</summary>
    public class LongTermInProgressDeferralNFEmittedWithServiceActivation : DeferralAccountingEntry, IDeferralStrategy
    {
        public const string interfaceType = "Billed";

        public Func<DeferralOffer, bool> Condition => d => d.NumberOfInstallments > 12 &&
                                                           d.IsActive &&
                                                           d.IsNFEmitted &&
                                                           d.DeferralStatus == DeferralStatus.InProgress &&
                                                          !d.DeferralStarted &&
                                                          !d.IsProvisioned &&
                                                          !d.AlreadyProcessed;


        public List<LaunchDeferralOffer> DeferOffer(List<DeferralOffer> offers, List<DeferralFinancialAccount> deferralFinancialAccounts, AccountDetailsByServiceDto accountingAccounts)
        {         
            if (offers.Any())
            {
                if (ValidateFinancialAccount(offers, deferralFinancialAccounts, accountingAccounts, interfaceType))
                {
                    offers.ForEach(offer =>
                    {
                        var billedAccountingAccount = GetAccountingAccount(accountingAccounts, offer, interfaceType);
                        var deferralFinancialAccount = GetDeferralFinancialAccount(deferralFinancialAccounts, offer);

                        #region Launches
                        LongTermDeferringInstallment(offer, deferralFinancialAccount);
                        IncomeRecognition(offer, deferralFinancialAccount);
                        #endregion

                        offer.SetDeferralType(DeferralType.LongTermRecurringDeferralNFEmittedWithServiceActivation);
                        offer.StartDeferral();
                        offer.UpdateLongBalance();
                        offer.UpdateCurrentInstallment();
                        offer.UpdateDeferralStatus();
                        offer.SetAsProcessed();
                    });
                }
            }

            return Launchers;
        }
    }
}
