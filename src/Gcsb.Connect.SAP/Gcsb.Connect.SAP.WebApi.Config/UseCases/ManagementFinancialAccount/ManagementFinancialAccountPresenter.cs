
using Gcsb.Connect.SAP.Application.Boundaries.ManangementFinancialAccount;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount.Get;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.ManagementFinancialAccount
{
    public class ManagementFinancialAccountPresenter : IOutputPort
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

        public void Standard(Domain.Config.ManagementFinancialAccount.ManagementFinancialAccount entity)
        {
            var response = new ManagementFinancialAccountGetResponse
            (
                entity.Id,
                new Model.ManagementFinancialAccount.Boleto(entity.ARR.Boleto.FinancialAccount, entity.ARR.Boleto.AccountingAccount.Credit, entity.ARR.Boleto.AccountingAccount.Debit),
                new Model.ManagementFinancialAccount.CreditCard(entity.ARR.CreditCard.FinancialAccount, entity.ARR.CreditCard.AccountingAccount.Credit, entity.ARR.CreditCard.AccountingAccount.Debit),
                new Model.ManagementFinancialAccount.Unassigned(entity.Unassigned.FinancialAccount, entity.Unassigned.AccountingAccount.Credit, entity.Unassigned.AccountingAccount.Debit),
                new Model.ManagementFinancialAccount.Critic(entity.Critic.FinancialAccount, entity.Critic.AccountingAccount.Credit, entity.Critic.AccountingAccount.Debit),
                new Model.ManagementFinancialAccount.Transferred(entity.Transfer.FinancialAccount, entity.Transfer.AccountingAccount.Credit, entity.Transfer.AccountingAccount.Debit)
            );

            ViewModel = new OkObjectResult(response);

        }
    }
}
