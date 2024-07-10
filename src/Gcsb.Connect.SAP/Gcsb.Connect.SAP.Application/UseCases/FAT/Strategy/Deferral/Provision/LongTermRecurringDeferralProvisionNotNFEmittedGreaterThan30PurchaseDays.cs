﻿using System;
using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Entities;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.FinancialAccount;
using Gcsb.Connect.SAP.Domain.Deferral;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Deferral.Provision
{
    ///<summary>
    ///US 58602
    ///Cenário 7: Diferimento provisionado MENSAL com número de parcelas MAIOR que a 12
    ///</summary>
    public class LongTermRecurringDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays : DeferralAccountingEntry, IDeferralStrategy
    {           
        public Func<DeferralOffer, bool> Condition => d => d.NumberOfInstallments > 12 &&
                                                           d.IsActive &&
                                                           d.PurchaseDays > 30 &&
                                                           d.IsProvisioned &&
                                                           d.DeferralStatus == DeferralStatus.InProgress &&                                                         
                                                          !d.IsNFEmitted &&
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

                        LongTermProvisionInstallment(offer, deferralFinancialAccount);
                        IncomeRecognitionProvision(offer, deferralFinancialAccount);

                        offer.UpdateLongBalance();
                        offer.UpdateCurrentInstallment();
                        offer.IncomeRecognitionProvision();
                        offer.SetDeferralType(DeferralType.LongTermRecurringDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays);
                        offer.SetAsProcessed();                       
                    });
                }
            }

            return Launchers;
        }
    }
}
