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
    ///Cenário 6: Diferimento provisionado INICIAL com número de parcelas MAIOR que 12, a menos de 30 dias da data da compra
    ///</summary>
    public class LongTermInitialDeferralProvisionNotNFEmittedLessThan30PurchaseDays : DeferralAccountingEntry, IDeferralStrategy
    {
        public const string interfaceType = "Billing";

        public Func<DeferralOffer, bool> Condition => d => d.NumberOfInstallments > 12 &&
                                                           d.IsActive &&
                                                           d.IsProvisioned &&
                                                           d.PurchaseDays < 30 &&
                                                           d.DeferralStatus == DeferralStatus.New &&
                                                          !d.IsNFEmitted &&                                                        
                                                          !d.AlreadyProcessed;

        public List<LaunchDeferralOffer> DeferOffer(List<DeferralOffer> offers, List<DeferralFinancialAccount> deferralFinancialAccounts, AccountDetailsByServiceDto accountingAccounts)
        {
            if (offers.Any())
            {
                if (ValidateFinancialAccount(offers, deferralFinancialAccounts, accountingAccounts, interfaceType))
                {
                    offers.ForEach(offer =>
                    {
                        var billingAccountingAccount = GetAccountingAccount(accountingAccounts, offer, interfaceType);
                        var deferralFinancialAccount = GetDeferralFinancialAccount(deferralFinancialAccounts, offer);

                        ShortTermOfferProvision(offer, deferralFinancialAccount, billingAccountingAccount);
                        LongTermProvision(offer, deferralFinancialAccount, billingAccountingAccount);

                        offer.SetDeferralType(DeferralType.LongTermInitialDeferralProvisionNotNFEmittedLessThan30PurchaseDays);
                        offer.UpdateDeferralStatus();                       
                        offer.SetAsProcessed();
                        
                    });
                }
            }

            return Launchers;
        }
    }
}
