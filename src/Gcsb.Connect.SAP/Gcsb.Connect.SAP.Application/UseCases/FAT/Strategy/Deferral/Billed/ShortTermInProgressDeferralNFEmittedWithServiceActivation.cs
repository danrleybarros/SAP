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
    ///Cenário 3: Ativação de serviço com diferimento iniciado com número de parcelas MENOR OU IGUAL a 12
    ///</summary>
    public class ShortTermInProgressDeferralNFEmittedWithServiceActivation : DeferralAccountingEntry, IDeferralStrategy
    {      
        public Func<DeferralOffer, bool> Condition => d => d.NumberOfInstallments <= 12 &&
                                                           d.IsActive &&
                                                           d.IsNFEmitted &&
                                                           d.DeferralStatus == DeferralStatus.InProgress &&
                                                           d.TotalShortBalance > 0 &&
                                                          !d.DeferralStarted &&
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
                        IncomeRecognition(offer, deferralFinancialAccount);
                        #endregion

                        offer.SetDeferralType(DeferralType.ShortTermRecurringDeferralNFEmittedActivatedService);
                        offer.StartDeferral();
                        offer.UpdateShortBalance();
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
