using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Add.Handler
{
    public class GetHandler : Handler<AccountAddRequest>
    {
        private readonly IInterestAndFineFinancialAccountReadOnlyRepository repository;

        public GetHandler(IInterestAndFineFinancialAccountReadOnlyRepository repository)
        {
            this.repository = repository;
        }

        public override void ProcessRequest(AccountAddRequest request)
        {
            request.AddLog("GetHandler", "Getting InterestAndFineFinancialAccount on database");

            var existsAccount = repository.GetByStore(request.InterestAndFineFinancialAccount.Store) != null;

            if (existsAccount)
                throw new ArgumentException($"duplicate key, there is already a saved configuration on database ");

            Sucessor?.ProcessRequest(request);
        }
    }
}
