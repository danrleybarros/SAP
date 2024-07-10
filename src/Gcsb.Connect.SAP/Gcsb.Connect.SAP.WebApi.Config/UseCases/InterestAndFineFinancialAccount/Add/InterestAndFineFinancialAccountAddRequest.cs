using System;
using Model = Gcsb.Connect.SAP.WebApi.Config.Model.InterestAndFineFinancialAccount;
using Domain = Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using System.ComponentModel.DataAnnotations;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount.Add
{
    public class InterestAndFineFinancialAccountAddRequest
    {
        [Required]
        public Model::FinancialAccount FinancialAccount { get; set; }

        public Domain::InterestAndFineFinancialAccount Map()
        {
            var model = new Domain::InterestAndFineFinancialAccount(
                Guid.NewGuid(),
                FinancialAccount.StoreAcronym,
                new Domain::Account(
                    FinancialAccount.Interest.FinancialAccount,
                    FinancialAccount.Interest.BilledCounterchargeChargeback,
                    FinancialAccount.Interest.GrantedDebit,
                    new Domain::AccountingAccount(FinancialAccount.Interest.InterestOrFine.Credit, FinancialAccount.Interest.InterestOrFine.Debit),
                    new Domain::AccountingAccount(FinancialAccount.Interest.UnpaidInvoice.Credit, FinancialAccount.Interest.UnpaidInvoice.Debit),
                    new Domain::AccountingAccount(FinancialAccount.Interest.PaidInvoice.Credit, FinancialAccount.Interest.PaidInvoice.Debit),
                    new Domain::AccountingAccount(FinancialAccount.Interest.CycleEstimate.Credit, FinancialAccount.Interest.CycleEstimate.Debit),
                    new Domain::AccountingAccount(FinancialAccount.Interest.ChargebackFutureCreditUnusedValue.Credit, FinancialAccount.Interest.ChargebackFutureCreditUnusedValue.Debit),
                    new Domain::AccountingAccount(FinancialAccount.Interest.ChargebackFutureCreditUsedValue.Credit, FinancialAccount.Interest.ChargebackFutureCreditUsedValue.Debit),
                    new Domain::AccountingAccount(FinancialAccount.Interest.ChargebackRectifiedBoleto.Credit, FinancialAccount.Interest.ChargebackRectifiedBoleto.Debit),
                    new Domain::AccountingAccount(FinancialAccount.Interest.GrantedDebitAccounting.Credit, FinancialAccount.Interest.GrantedDebitAccounting.Debit)
                ),
                new Domain::Account(
                    FinancialAccount.Fine.FinancialAccount,
                    FinancialAccount.Fine.BilledCounterchargeChargeback,
                    FinancialAccount.Fine.GrantedDebit,
                    new Domain::AccountingAccount(FinancialAccount.Fine.InterestOrFine.Credit, FinancialAccount.Fine.InterestOrFine.Debit),
                    new Domain::AccountingAccount(FinancialAccount.Fine.UnpaidInvoice.Credit, FinancialAccount.Fine.UnpaidInvoice.Debit),
                    new Domain::AccountingAccount(FinancialAccount.Fine.PaidInvoice.Credit, FinancialAccount.Fine.PaidInvoice.Debit),
                    new Domain::AccountingAccount(FinancialAccount.Fine.CycleEstimate.Credit, FinancialAccount.Fine.CycleEstimate.Debit),
                    new Domain::AccountingAccount(FinancialAccount.Fine.ChargebackFutureCreditUnusedValue.Credit, FinancialAccount.Fine.ChargebackFutureCreditUnusedValue.Debit),
                    new Domain::AccountingAccount(FinancialAccount.Fine.ChargebackFutureCreditUsedValue.Credit, FinancialAccount.Fine.ChargebackFutureCreditUsedValue.Debit),
                    new Domain::AccountingAccount(FinancialAccount.Fine.ChargebackRectifiedBoleto.Credit, FinancialAccount.Fine.ChargebackRectifiedBoleto.Debit),
                    new Domain::AccountingAccount(FinancialAccount.Fine.GrantedDebitAccounting.Credit, FinancialAccount.Fine.GrantedDebitAccounting.Debit)
                )
            );

            return model;
        }
    }
}
