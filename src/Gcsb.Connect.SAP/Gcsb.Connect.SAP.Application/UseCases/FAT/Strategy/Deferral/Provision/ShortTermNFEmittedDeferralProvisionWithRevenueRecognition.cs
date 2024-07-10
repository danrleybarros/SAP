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
    ///<summary>
    ///US 58602
    ///Cenário 5: Emissão da Nota Fiscal para serviço com diferimento provisionado com número de parcelas MENOR OU IGUAL a 12 e com reconhecimento de receita
    ///</summary>
    public class ShortTermNFEmittedDeferralProvisionWithRevenueRecognition : DeferralAccountingEntry, IDeferralStrategy
    {      
        public const string billingInterfaceType = "Billing";
        public const string billedInterfaceType = "Billed";

        public Func<DeferralOffer, bool> Condition => d => d.NumberOfInstallments <= 12 &&                                                         
                                                           d.IsActive &&
                                                           d.IsNFEmitted &&
                                                           d.IsProvisioned &&                                                                                                            
                                                           d.DeferralStatus == DeferralStatus.InProgress &&
                                                           d.IsIncomeRecognized &&   
                                                          !d.AlreadyProcessed;       

        public List<LaunchDeferralOffer> DeferOffer(List<DeferralOffer> offers, List<DeferralFinancialAccount> deferralFinancialAccounts, AccountDetailsByServiceDto accountingAccounts)
        {           
            if (offers.Any())
            {
                if (ValidateFinancialAccount(offers,deferralFinancialAccounts,accountingAccounts, billedInterfaceType))
                {
                    offers.ForEach(offer =>
                    {
                        var billingAccountingAccount = base.GetAccountingAccount(accountingAccounts, offer, billingInterfaceType);
                        var deferralFinancialAccount = base.GetDeferralFinancialAccount(deferralFinancialAccounts, offer);
                                               
                        IncomeAccountAdjustment(offer, deferralFinancialAccount);
                        ReversalShortTermProvision(offer, deferralFinancialAccount, billingAccountingAccount);
                        ReversalShortTermProvisionInstallment(offer, deferralFinancialAccount);
                        IncomeRecognitionWithAccumulatedInstallments(offer, deferralFinancialAccount);

                        offer.SetDeferralType(DeferralType.ShortTermNFEmittedDeferralProvisionWithRevenueRecognition);
                        offer.UpdateShortBalance();
                        offer.UpdateCurrentInstallment();                    
                        offer.UpdateIsProvisioned(false);
                        offer.StartDeferral();
                        offer.SetAsProcessed();
                    });
                }
            }

            return base.Launchers;
        }
       
    }
}
