using System;
using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Entities;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.FinancialAccount;
using Gcsb.Connect.SAP.Domain.Deferral;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Deferral.Provision
{
    /// <summary>
    /// US 58602
    /// Cenário 9: Emissão da Nota Fiscal para serviço com diferimento provisionado com número de parcelas MAIOR que 12 e sem reconhecimento de receita
    /// </summary>
    public class LongTermNFEmittedDeferralProvisionWithoutRevenueRecognition : DeferralAccountingEntry, IDeferralStrategy
    {
        public const string billingInterfaceType = "Billing";

        public Func<DeferralOffer, bool> Condition => d => d.NumberOfInstallments > 12 &&
                                                           d.IsActive  && 
                                                           d.IsNFEmitted &&
                                                           d.IsProvisioned &&                                                           
                                                           d.DeferralStatus == DeferralStatus.InProgress &&
                                                          !d.IsIncomeRecognized &&   
                                                          !d.AlreadyProcessed;

        public List<LaunchDeferralOffer> DeferOffer(List<DeferralOffer> offers, List<DeferralFinancialAccount> deferralFinancialAccounts, AccountDetailsByServiceDto accountingAccounts)
        {           
            if (offers.Any())
            {
                if (ValidateFinancialAccount(offers,deferralFinancialAccounts,accountingAccounts, billingInterfaceType))
                {
                    offers.ForEach(offer =>
                    {
                        var billingAccountingAccount = GetAccountingAccount(accountingAccounts, offer, billingInterfaceType);
                        var deferralFinancialAccount = GetDeferralFinancialAccount(deferralFinancialAccounts, offer);

                        IncomeAccountAdjustment(offer, deferralFinancialAccount);
                        ReversalShortTermProvision(offer, deferralFinancialAccount, billingAccountingAccount);
                        ReversalLongTermProvision(offer, deferralFinancialAccount, billingAccountingAccount); 
                        LongTermDeferringValue(offer, deferralFinancialAccount);
                        LongTermDeferringInstallment(offer, deferralFinancialAccount);
                        IncomeRecognition(offer, deferralFinancialAccount);
                                               
                        offer.UpdateLongBalance();
                        offer.UpdateCurrentInstallment();
                        offer.UpdateIsProvisioned(false);
                        offer.StartDeferral();
                        offer.SetAsProcessed();
                        offer.SetDeferralType(DeferralType.LongTermNFEmittedDeferralProvisionWithoutRevenueRecognition);
                    });
                }
            }

            return Launchers;
        }
    }
}
