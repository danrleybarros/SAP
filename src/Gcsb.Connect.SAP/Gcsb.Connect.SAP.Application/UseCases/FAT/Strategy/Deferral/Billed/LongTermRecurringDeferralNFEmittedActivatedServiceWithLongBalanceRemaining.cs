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
    ///US 58606
    ///Cenário 4: Diferimento MENSAL com número de parcelas MAIOR que 12
    ///</summary>
    public class LongTermRecurringDeferralNFEmittedActivatedServiceWithLongBalanceRemaining : DeferralAccountingEntry, IDeferralStrategy
    {  
        public Func<DeferralOffer, bool> Condition => d => d.NumberOfInstallments > 12 &&
                                                           d.IsNFEmitted &&
                                                           d.IsActive &&
                                                           d.DeferralStarted &&
                                                           d.TotalLongBalance > 0 &&
                                                          !d.IsProvisioned &&
                                                          !d.AlreadyProcessed;

        public List<LaunchDeferralOffer> DeferOffer(List<DeferralOffer> offers, List<DeferralFinancialAccount> deferralFinancialAccounts, AccountDetailsByServiceDto accountingAccounts)
        {
            if (offers.Any())
            {
                if (ValidateFinancialAccount(offers, deferralFinancialAccounts))
                {
                    offers.ForEach(offer =>
                    {
                        var deferralFinancialAccount = GetDeferralFinancialAccount(deferralFinancialAccounts, offer);

                        #region Launches
                        LongTermDeferringInstallment(offer, deferralFinancialAccount);
                        IncomeRecognition(offer, deferralFinancialAccount);
                        #endregion

                        offer.UpdateLongBalance();
                        offer.UpdateCurrentInstallment();
                        offer.SetDeferralType(DeferralType.LongTermRecurringDeferralNFEmittedActivatedServiceWithLongBalanceRemaining);
                        offer.UpdateDeferralStatus();
                        offer.SetAsProcessed();                      
                    });
                }
            }

            return Launchers;

        }
    }
}

