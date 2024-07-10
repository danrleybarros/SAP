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
    ///Cenário 2: Diferimento INICIAL com número de parcelas MAIOR que 12
    ///</summary>
    public class LongTermInitialDeferralNFEmittedNotActivatedService : DeferralAccountingEntry, IDeferralStrategy
    {
        public Func<DeferralOffer, bool> Condition => d => d.NumberOfInstallments > 12 &&                                                         
                                                          !d.IsActive &&
                                                           d.IsNFEmitted &&
                                                          !d.DeferralStarted &&
                                                          !d.HasDiscount &&
                                                          !d.IsProvisioned &&
                                                           d.DeferralStatus == DeferralStatus.New &&
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
                        IncomeAccountAdjustment(offer, deferralFinancialAccount);
                        LongTermDeferringValue(offer, deferralFinancialAccount);
                        #endregion

                        offer.SetDeferralType(DeferralType.LongTermInitialDeferralNFEmittedNotActivatedService);
                        offer.UpdateDeferralStatus();
                        offer.SetAsProcessed(); 
                    });
                }
            }

            return Launchers;
        }
    }
}
