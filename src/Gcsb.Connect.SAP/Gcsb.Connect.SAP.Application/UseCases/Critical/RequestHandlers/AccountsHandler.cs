using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.Critical.RequestHandlers
{
    public class AccountsHandler : Handler
    {
        private readonly IManagementFinancialAccountReadOnlyRepository Repository;

        public AccountsHandler(IManagementFinancialAccountReadOnlyRepository repository)
        {
            this.Repository = repository;
        }

        public override void ProcessRequest(CriticaRequest request)
        {
            request.AddProcessingLog("Consulting Financial Accounts - Critica");

            request.Accounts = Repository.Get();

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
