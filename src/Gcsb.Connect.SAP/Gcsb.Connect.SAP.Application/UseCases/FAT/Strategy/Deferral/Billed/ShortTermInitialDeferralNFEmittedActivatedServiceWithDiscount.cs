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
    ///Cenário 6: Diferimento INICIAL com número de parcelas MENOR ou IGUAL a 12 e oferta com desconto condicional
    ///</summary>
    public class ShortTermInitialDeferralNFEmittedActivatedServiceWithDiscount : DeferralAccountingEntry, IDeferralStrategy
    {
        public Func<DeferralOffer, bool> Condition => d => d.NumberOfInstallments <= 12 &&
                                                           d.IsActive &&
                                                           d.IsNFEmitted &&                                                          
                                                           d.HasDiscount &&
                                                          !d.DeferralStarted &&
                                                          !d.IsProvisioned &&
                                                          !d.AlreadyProcessed;

        public List<LaunchDeferralOffer> DeferOffer(List<DeferralOffer> offers, List<DeferralFinancialAccount> deferralFinancialAccounts, AccountDetailsByServiceDto accountingAccounts)
    {            
            if (offers.Any())
            {
                if (ValidateFinancialAccount(offers,deferralFinancialAccounts))
                {
                    offers.ForEach(offer =>
                    {
                        var deferralFinancialAccount = GetDeferralFinancialAccount(deferralFinancialAccounts, offer);

                        #region Launches
                        IncomeAccountAdjustment(offer, deferralFinancialAccount);
                        IncomeRecognition(offer, deferralFinancialAccount);
                        #endregion

                        offer.SetDeferralType(DeferralType.ShortTermInitialDeferralNFEmittedActivatedServiceWithDiscount);
                        offer.UpdateShortBalance();
                        offer.UpdateCurrentInstallment();
                        offer.StartDeferral();
                        offer.UpdateDeferralStatus();
                        offer.SetAsProcessed();                       
                    });
                }
            }

            return Launchers;
        }
    }
}
