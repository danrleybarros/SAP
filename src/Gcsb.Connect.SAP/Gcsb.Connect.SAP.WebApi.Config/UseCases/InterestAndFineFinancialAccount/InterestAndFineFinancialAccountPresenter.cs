using Gcsb.Connect.SAP.Application.Boundaries.InterestAndFineFinancialAccount;
using Domain = Gcsb.Connect.SAP.Domain.Config.InterestAndFineFinancialAccount;
using Microsoft.AspNetCore.Mvc;
using System;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount.Get;
using Model = Gcsb.Connect.SAP.WebApi.Config.Model.InterestAndFineFinancialAccount;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.InterestAndFineFinancialAccount
{
    public class InterestAndFineFinancialAccountPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "Error",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);

        public void Standard(Guid id)
        {
            ViewModel = new OkObjectResult(id);
        }

        public void Standard(Domain::InterestAndFineFinancialAccount entity)
        {
            var response = new InterestAndFineFinancialAccountGetResponse
                (
                    entity.Id,
                    new Model::FinancialAccount(
                        entity.Store,
                        new Model::Account(
                            entity.Interest.FinancialAccount,
                            entity.Interest.BilledCounterchargeChargeback,
                            entity.Interest.GrantedDebit,
                            new Model::BaseFinancialAccount(entity.Interest.InterestOrFine.Credit, entity.Interest.InterestOrFine.Debit),
                            new Model::BaseFinancialAccount(entity.Interest.UnpaidInvoice.Credit, entity.Interest.UnpaidInvoice.Debit),
                            new Model::BaseFinancialAccount(entity.Interest.PaidInvoice.Credit, entity.Interest.PaidInvoice.Debit),
                            new Model::BaseFinancialAccount(entity.Interest.CycleEstimate.Credit, entity.Interest.CycleEstimate.Debit),
                            new Model::BaseFinancialAccount(entity.Interest.ChargebackFutureCreditUnusedValue?.Credit, entity.Interest.ChargebackFutureCreditUnusedValue?.Debit),
                            new Model::BaseFinancialAccount(entity.Interest.ChargebackFutureCreditUsedValue?.Credit, entity.Interest.ChargebackFutureCreditUsedValue?.Debit),
                            new Model::BaseFinancialAccount(entity.Interest.ChargebackRectifiedBoleto?.Credit, entity.Interest.ChargebackRectifiedBoleto?.Debit),
                            new Model::BaseFinancialAccount(entity.Interest.GrantedDebitAccounting?.Credit, entity.Interest.GrantedDebitAccounting?.Debit)
                        ),
                        new Model::Account(
                            entity.Fine.FinancialAccount,
                            entity.Fine.BilledCounterchargeChargeback,
                            entity.Fine.GrantedDebit,
                            new Model::BaseFinancialAccount(entity.Fine.InterestOrFine.Credit, entity.Fine.InterestOrFine.Debit),
                            new Model::BaseFinancialAccount(entity.Fine.UnpaidInvoice.Credit, entity.Fine.UnpaidInvoice.Debit),
                            new Model::BaseFinancialAccount(entity.Fine.PaidInvoice.Credit, entity.Fine.PaidInvoice.Debit),
                            new Model::BaseFinancialAccount(entity.Fine.CycleEstimate.Credit, entity.Fine.CycleEstimate.Debit),
                            new Model::BaseFinancialAccount(entity.Fine.ChargebackFutureCreditUnusedValue?.Credit, entity.Fine.ChargebackFutureCreditUnusedValue?.Debit),
                            new Model::BaseFinancialAccount(entity.Fine.ChargebackFutureCreditUsedValue?.Credit, entity.Fine.ChargebackFutureCreditUsedValue?.Debit),
                            new Model::BaseFinancialAccount(entity.Fine.ChargebackRectifiedBoleto?.Credit, entity.Fine.ChargebackRectifiedBoleto?.Debit),
                            new Model::BaseFinancialAccount(entity.Fine.GrantedDebitAccounting?.Credit, entity.Fine.GrantedDebitAccounting?.Debit)
                        )
                    )
                );

            ViewModel = new OkObjectResult(response);
        }

        public void Standard(List<Domain::InterestAndFineFinancialAccount> entities)
        {
            var response = new List<InterestAndFineFinancialAccountGetResponse>();

            entities.ForEach(entity =>
            {
                var financialAcount = new InterestAndFineFinancialAccountGetResponse
                (
                    entity.Id,
                    new Model::FinancialAccount(
                        entity.Store,
                        new Model::Account(
                            entity.Interest.FinancialAccount,
                            entity.Interest.BilledCounterchargeChargeback,
                            entity.Interest.GrantedDebit,
                            new Model::BaseFinancialAccount(entity.Interest.InterestOrFine.Credit, entity.Interest.InterestOrFine.Debit),
                            new Model::BaseFinancialAccount(entity.Interest.UnpaidInvoice.Credit, entity.Interest.UnpaidInvoice.Debit),
                            new Model::BaseFinancialAccount(entity.Interest.PaidInvoice.Credit, entity.Interest.PaidInvoice.Debit),
                            new Model::BaseFinancialAccount(entity.Interest.CycleEstimate.Credit, entity.Interest.CycleEstimate.Debit),
                            new Model::BaseFinancialAccount(entity.Interest.ChargebackFutureCreditUnusedValue?.Credit, entity.Interest.ChargebackFutureCreditUnusedValue?.Debit),
                            new Model::BaseFinancialAccount(entity.Interest.ChargebackFutureCreditUsedValue?.Credit, entity.Interest.ChargebackFutureCreditUsedValue?.Debit),
                            new Model::BaseFinancialAccount(entity.Interest.ChargebackRectifiedBoleto?.Credit, entity.Interest.ChargebackRectifiedBoleto?.Debit),
                            new Model::BaseFinancialAccount(entity.Interest.GrantedDebitAccounting?.Credit, entity.Interest.GrantedDebitAccounting?.Debit)
                        ),
                        new Model::Account(
                            entity.Fine.FinancialAccount,
                            entity.Fine.BilledCounterchargeChargeback,
                            entity.Fine.GrantedDebit,
                            new Model::BaseFinancialAccount(entity.Fine.InterestOrFine.Credit, entity.Fine.InterestOrFine.Debit),
                            new Model::BaseFinancialAccount(entity.Fine.UnpaidInvoice.Credit, entity.Fine.UnpaidInvoice.Debit),
                            new Model::BaseFinancialAccount(entity.Fine.PaidInvoice.Credit, entity.Fine.PaidInvoice.Debit),
                            new Model::BaseFinancialAccount(entity.Fine.CycleEstimate.Credit, entity.Fine.CycleEstimate.Debit),
                            new Model::BaseFinancialAccount(entity.Fine.ChargebackFutureCreditUnusedValue?.Credit, entity.Fine.ChargebackFutureCreditUnusedValue?.Debit),
                            new Model::BaseFinancialAccount(entity.Fine.ChargebackFutureCreditUsedValue?.Credit, entity.Fine.ChargebackFutureCreditUsedValue?.Debit),
                            new Model::BaseFinancialAccount(entity.Fine.ChargebackRectifiedBoleto?.Credit, entity.Fine.ChargebackRectifiedBoleto?.Debit),
                            new Model::BaseFinancialAccount(entity.Fine.GrantedDebitAccounting?.Credit, entity.Fine.GrantedDebitAccounting?.Debit)
                        )
                    )
                );

                response.Add(financialAcount);
            });

            ViewModel = new OkObjectResult(response);
        }
    }
}
