using System.Collections.Generic;
using System.Linq;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.Entities;
using Gcsb.Connect.SAP.Domain;
using Gcsb.Connect.SAP.Domain.Deferral;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.DeferralFinancialAccount;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.FinancialAccount;


namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Strategy.FinancialAccount
{
    public abstract class DeferralAccountingEntry
    {
        protected List<LaunchDeferralOffer> Launchers { get; set; } = new List<LaunchDeferralOffer>();
        public static List<Log> Logs = new List<Log>();
        public static bool IsValidFinancialAccount => Logs.Count.Equals(0);     

        protected DeferralFinancialAccount GetDeferralFinancialAccount(List<DeferralFinancialAccount> deferralFinancialAccounts, DeferralOffer offer)
        => deferralFinancialAccounts.Where(d => d.ServiceCode == offer.ServiceCode &&
                                                d.OfferCode == offer.OfferCode &&
                                                d.Store == offer.StoreAcronym).FirstOrDefault();

        protected Account GetAccountingAccount(AccountDetailsByServiceDto accountingAccounts, DeferralOffer offer, string accountType)
            => accountingAccounts.Services.Where(s => s.ServiceCode == offer.ServiceCode &&
                                                      s.StoreAcronym == offer.StoreAcronym)
                       .FirstOrDefault()?.AccountDetail?.Store.Where(s => s.InterfaceType == accountType && s.AccountType == FinancialAccountType.Billed.ToString())
                       .FirstOrDefault();

        ///<summary>
        ///Ajuste da conta de Receita / Lançamento da conta de Receita para conta de Passivo a Prestar Curto Prazo
        ///</summary>
        protected void IncomeAccountAdjustment(DeferralOffer offer, DeferralFinancialAccount deferralFinancialAccount)
            => LaunchDeferment(deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermTotal.Debit.ToString(),
                               deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermTotal.Credit.ToString(),
                               offer,
                               LaunchDeferralType.IncomeAccountAdjustment);

        ///<summary>
        ///Reconhecimento da Receita
        ///</summary>
        protected void IncomeRecognition(DeferralOffer offer, DeferralFinancialAccount deferralFinancialAccount)
            => LaunchDeferment(deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermInstallment.Debit.ToString(),
                               deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermInstallment.Credit.ToString(),
                               offer,
                               LaunchDeferralType.IncomeRecognition);

        ///<summary>
        ///Reconhecimento da Receita Provisionado
        ///</summary>
        protected void IncomeRecognitionProvision(DeferralOffer offer, DeferralFinancialAccount deferralFinancialAccount)
            => LaunchDeferment(deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermInstallment.Debit.ToString(),
                               deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermTotal.Credit.ToString(),
                               offer,
                               LaunchDeferralType.IncomeRecognitionProvision);

        ///<summary>
        ///Reconhecimento da Receita (Com Parcelas Diferidas)
        ///</summary>
        protected void IncomeRecognitionWithAccumulatedInstallments(DeferralOffer offer, DeferralFinancialAccount deferralFinancialAccount)
            => LaunchDeferment(deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermInstallment.Debit.ToString(),
                               deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermInstallment.Credit.ToString(),
                               offer,
                               LaunchDeferralType.IncomeRecognitionWithAccumulatedInstallments);

        ///<summary>
        ///Lançamento do valor a ser diferido a Longo Prazo
        ///</summary>
        protected void LongTermDeferringValue(DeferralOffer offer, DeferralFinancialAccount deferralFinancialAccount)
            => LaunchDeferment(deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermTotal.Credit.ToString(),
                               deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.LongTermTotal.Credit.ToString(),
                               offer,
                               LaunchDeferralType.LongTermDeferringValue);

        ///<summary>
        ///Lançamento da parcela de Longo Prazo
        ///</summary>
        protected void LongTermDeferringInstallment(DeferralOffer offer, DeferralFinancialAccount deferralFinancialAccount)
            => LaunchDeferment(deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.LongTermInstallment.Debit.ToString(),
                               deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermInstallment.Debit.ToString(),
                               offer,
                               LaunchDeferralType.LongTermDeferringInstallment);


        protected void LongTermDeferringInstallmentWithAccumulatedInstallments(DeferralOffer offer, DeferralFinancialAccount deferralFinancialAccount)
           => LaunchDeferment(deferralFinancialAccount.FinancialAccount,
                              deferralFinancialAccount.LongTermInstallment.Debit.ToString(),
                              deferralFinancialAccount.FinancialAccount,
                              deferralFinancialAccount.ShortTermInstallment.Debit.ToString(),
                              offer,
                              LaunchDeferralType.LongTermDeferringInstallmentWithAccumulatedInstallments);


        ///<summary>
        ///Lançamentos de provisão de Longo Prazo
        ///</summary>
        protected void LongTermProvision(DeferralOffer offer, DeferralFinancialAccount deferralFinancialAccount, Account competencyAdjustment)
            => LaunchDeferment(competencyAdjustment.FinancialAccount,
                               competencyAdjustment.FinancialAccountDeb,
                               deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.LongTermProvision.Credit.ToString(),
                               offer,
                               LaunchDeferralType.LongTermProvision);

        ///<summary>
        ///Lançamento da parcela de Longo Prazo Provisionada
        ///</summary>
        protected void LongTermProvisionInstallment(DeferralOffer offer, DeferralFinancialAccount deferralFinancialAccount)
            => LaunchDeferment(deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.LongTermLowProvision.Debit.ToString(),
                               deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermInstallment.Credit.ToString(),
                               offer,
                               LaunchDeferralType.LongTermProvisionInstallment);

        ///<summary>
        ///Provisão de oferta Curto Prazo - Lançamentos de provisão de Curto Prazo
        ///</summary>
        protected void ShortTermOfferProvision(DeferralOffer offer, DeferralFinancialAccount deferralFinancialAccount, Account competencyAdjustment)
            => LaunchDeferment(competencyAdjustment.FinancialAccount,
                               competencyAdjustment.FinancialAccountDeb,
                               deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermInstallment.Credit.ToString(),
                               offer,
                               LaunchDeferralType.ShortTermOfferProvision);

        ///<summary>
        ///Estorno do provisionamento de Longo Prazo
        ///</summary>
        protected void ReversalLongTermProvision(DeferralOffer offer, DeferralFinancialAccount deferralFinancialAccount, Account competencyAdjustment)
            => LaunchDeferment(deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.LongTermProvision.Debit.ToString(),
                               competencyAdjustment.FinancialAccount,
                               competencyAdjustment.FinancialAccountCred,
                               offer,
                               LaunchDeferralType.ReversalLongTermProvision);

        ///<summary>
        ///Estorno das parcelas provisionadas a Longo Prazo
        ///</summary>
        protected void ReversalLongTermProvisionInstallment(DeferralOffer offer, DeferralFinancialAccount deferralFinancialAccount)
            => LaunchDeferment(deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.LongTermLowProvision.Debit.ToString(),
                               deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermInstallment.Credit.ToString(),
                               offer,
                               LaunchDeferralType.ReversalLongTermProvisionInstallment);

        ///<summary>
        ///Estorno do provisionamento Curto Prazo
        ///</summary>
        protected void ReversalShortTermProvision(DeferralOffer offer, DeferralFinancialAccount deferralFinancialAccount, Account competencyAdjustment)
            => LaunchDeferment(deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermLowProvision.Debit.ToString(),
                               competencyAdjustment.FinancialAccount,
                               competencyAdjustment.FinancialAccountCred,
                               offer,
                               LaunchDeferralType.ReversalShortTermProvision);

        ///<summary>
        ///Estorno das parcelas provisionadas Curto Prazo
        ///</summary>
        protected void ReversalShortTermProvisionInstallment(DeferralOffer offer, DeferralFinancialAccount deferralFinancialAccount)
            => LaunchDeferment(deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermTotal.Debit.ToString(),
                               deferralFinancialAccount.FinancialAccount,
                               deferralFinancialAccount.ShortTermInstallment.Credit.ToString(),
                               offer,
                               LaunchDeferralType.ReversalShortTermProvisionInstallment);

        private void LaunchDeferment(string financialAccountDebit, string accountingEntryDebit, string financialAccountCredit, string accountingEntryCredit, DeferralOffer offer, LaunchDeferralType LaunchDeferralType)
        {
            var accountingEntries = new List<AccountingEntry>
            {
                 CreateAccountingEntries(financialAccountDebit, accountingEntryDebit,"D", offer),
                 CreateAccountingEntries(financialAccountCredit, accountingEntryCredit, "C", offer)
            };

            Launchers.Add(new LaunchDeferralOffer(offer, accountingEntries, LaunchDeferralType));
        }
        
        protected bool ValidateFinancialAccount(List<DeferralOffer> offers, List<DeferralFinancialAccount> deferralFinancialAccounts, AccountDetailsByServiceDto accountingAccounts = null, string interfaceType = "Diferimento")
        {
            var serviceWithoutAccount = offers
                .Where(w => !deferralFinancialAccounts.Any(a => a.ServiceCode == w.ServiceCode && a.OfferCode == w.OfferCode && a.Store == w.StoreAcronym))
                .Select(s => s.ServiceCode)
                .ToList();

            if (accountingAccounts is not null)
            {
                var serviceCodes = offers.Where(w => !accountingAccounts.Services.Where(s => s.ServiceCode == w.ServiceCode && s.StoreAcronym == w.StoreAcronym)
                                                                               .FirstOrDefault()?.AccountDetail?.Store
                                                                               .Any(s => s.InterfaceType == interfaceType && s.AccountType == "Billed") ?? false).Select(s => s.ServiceCode).ToList();
                if (serviceCodes.Any())
                    serviceWithoutAccount.AddRange(serviceCodes);
            }

            serviceWithoutAccount.ForEach(serviceCode => Logs.Add(Log.CreateExceptionLog("Generate Interface FAT",$"Service code: {serviceCode} não possui conta", $"Service code: {serviceCode} não possui conta para {interfaceType}")));

            return !serviceWithoutAccount.Any();

        }

        private static AccountingEntry CreateAccountingEntries(string financialAccount, string accountingEntry, string type, DeferralOffer offer)
           => new AccountingEntry(financialAccount, type, accountingEntry, offer.StoreAcronym.ToStoreType(), offer.ServiceCode, offer.ProviderStoreAcronym.ToStoreType());
    }
}
