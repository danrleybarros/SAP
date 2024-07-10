using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Remove.Handler
{
    public class RemoveHandler : Handler<AccountRemoveRequest>
    {
        private readonly IInterestAndFineFinancialAccountWriteOnlyRepository repository;

        public RemoveHandler(IInterestAndFineFinancialAccountWriteOnlyRepository repository)
        {
            this.repository = repository;
        }

        public override void ProcessRequest(AccountRemoveRequest request)
        {
            request.AddLog("AccountRemoveUseCase", "Removing managementFinancialAccount on database");

            var output = repository.Remove(request.InterestAndFineFinancialAccount);

            if (output == 0)
                throw new ArgumentException($"Error on tryed remove data of managementFinancialAccount on database to id {request.Id}");

            Sucessor?.ProcessRequest(request);
        }
    }
}
