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
    ///Cenário 3: Diferimento Provisionado INICIAL com número de parcelas MENOR OU IGUAL a 12, a mais de 30 dias da data da compra
    ///</summary>
    public class ShortTermInitialDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays : DeferralAccountingEntry, IDeferralStrategy
    {      
        public const string interfaceType = "Billing";

        public Func<DeferralOffer, bool> Condition => d => d.NumberOfInstallments <= 12 &&
                                                           d.IsActive &&
                                                           d.IsProvisioned &&
                                                           d.PurchaseDays > 30 &&
                                                           d.DeferralStatus == DeferralStatus.New &&
                                                          !d.IsNFEmitted &&                                               
                                                          !d.AlreadyProcessed;
      
        public List<LaunchDeferralOffer> DeferOffer(List<DeferralOffer> offers, List<DeferralFinancialAccount> deferralFinancialAccounts, AccountDetailsByServiceDto accountingAccounts)
        {
            if (offers.Any())
            {
                if (ValidateFinancialAccount(offers,deferralFinancialAccounts, accountingAccounts, interfaceType))
                {
                    offers.ForEach(offer =>
                    {
                        var billedAccountingAccount = base.GetAccountingAccount(accountingAccounts, offer, interfaceType);
                        var deferralFinancialAccount = base.GetDeferralFinancialAccount(deferralFinancialAccounts, offer);

                        ShortTermOfferProvision(offer, deferralFinancialAccount, billedAccountingAccount);
                        IncomeRecognitionProvision(offer, deferralFinancialAccount);

                        offer.UpdateShortBalance();
                        offer.UpdateCurrentInstallment();
                        offer.UpdateDeferralStatus();
                        offer.IncomeRecognitionProvision();
                        offer.SetDeferralType(DeferralType.ShortTermInitialDeferralProvisionNotNFEmittedGreaterThan30PurchaseDays);
                        offer.SetAsProcessed();                       
                    });
                }
            }

            return base.Launchers;
        }

    }
}
