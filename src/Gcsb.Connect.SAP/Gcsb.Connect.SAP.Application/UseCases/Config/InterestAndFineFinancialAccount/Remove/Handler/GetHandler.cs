using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Remove.Handler
{
    public class GetHandler : Handler<AccountRemoveRequest>
    {
        private readonly IInterestAndFineFinancialAccountReadOnlyRepository repository;

        public GetHandler(IInterestAndFineFinancialAccountReadOnlyRepository repository)
        {
            this.repository = repository;
        }

        public override void ProcessRequest(AccountRemoveRequest request)
        {
            request.AddLog("GetHandler", "Getting managementFinancialAccount on database");

            request.AddManagementFinancialAccount(repository.GetById(request.Id));

            if (request.InterestAndFineFinancialAccount == null)
            {
                request.AddLog("AccountRemoveUseCase", $"No data found on database to id: {request.Id}");
                return;
            }

            Sucessor?.ProcessRequest(request);
        }
    }
}
