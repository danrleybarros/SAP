using Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.FAT.FATFaturado;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.FAT.Helper
{
    public class Launcher : ILauncher
    {
        public List<LaunchFaturado> GetLaunches(
            ChargeBackType type,
            List<ServiceFilter> CounterchargeChargebacks,
            Account financialAccount,
            string store,
            DateTime cycle,
            int lines = 0)
        {
            var storeType = Domain.Util.ToEnum<StoreType>(store);
            var accountingAccounts = GetAccountingAccounts(type, financialAccount, storeType);

            return CounterchargeChargebacks
                .SelectMany(s => accountingAccounts, (service, account) => new { service, account })
                .GroupBy(g => new { g.account.FinancialAccount, g.service.Invoice.Customer.BillingStateOrProvince, g.service.Invoice.PaymentMethod, g.service.ServiceType, g.account.AccountingEntryType, g.account.AccountingAccount })
                .Where(w => w.Sum(sum => Convert.ToDecimal(sum.service.GrandTotalRetailPrice.Value)) > 0)
                .Select(s => new LaunchFaturado(
                    ++lines,
                    cycle,
                    s.Key.FinancialAccount,
                    s.Sum(sum => Convert.ToDecimal(sum.service.GrandTotalRetailPrice.Value)),
                    Util.GetUF(s.Key.BillingStateOrProvince, storeType).InternalOrder,
                    Util.GetUFByState(s.Key.BillingStateOrProvince, storeType),
                    cycle,
                    s.Key.PaymentMethod.RemoveAccents(),
                    s.Key.AccountingEntryType,
                    s.Key.AccountingAccount,
                    storeType,
                    false))
                .ToList();
        }

        private List<AccountingEntry> GetAccountingAccounts(ChargeBackType type, Account account, StoreType storeType)
        {
            return type switch
            {
                ChargeBackType.TotalUsed => new List<AccountingEntry>()
                {
                    new AccountingEntry(account.BilledCounterchargeChargeback, "D", account.ChargebackFutureCreditUsedValue.Debit, storeType),
                    new AccountingEntry(account.BilledCounterchargeChargeback, "C", account.ChargebackFutureCreditUsedValue.Credit, storeType)
                },
                ChargeBackType.TotalNotUsed => new List<AccountingEntry>()
                {
                    new AccountingEntry(account.BilledCounterchargeChargeback, "D", account.ChargebackFutureCreditUnusedValue.Debit, storeType),
                    new AccountingEntry(account.BilledCounterchargeChargeback, "C", account.ChargebackFutureCreditUnusedValue.Credit, storeType),
                },
                ChargeBackType.RetifiedBoleto => new List<AccountingEntry>()
                {
                    new AccountingEntry(account.BilledCounterchargeChargeback, "D", account.ChargebackRectifiedBoleto.Debit, storeType),
                    new AccountingEntry(account.BilledCounterchargeChargeback, "C", account.ChargebackRectifiedBoleto.Credit, storeType),
                },
                ChargeBackType.DebtGranted => new List<AccountingEntry>()
                {
                    new AccountingEntry(account.GrantedDebit, "D", account.GrantedDebitAccounting.Debit, storeType),
                    new AccountingEntry(account.GrantedDebit, "C", account.GrantedDebitAccounting.Credit, storeType),
                },
                _ => throw new NotSupportedException()
            };
        }

       
    }
}
