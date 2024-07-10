using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.ExportCSV.Handler
{
    public class GetAccountsHandler : Handler<AccountExportCSVRequest>
    {
        private readonly IInterestAndFineFinancialAccountReadOnlyRepository repository;

        public GetAccountsHandler(IInterestAndFineFinancialAccountReadOnlyRepository repository)
        {
            this.repository = repository;
        }

        public override void ProcessRequest(AccountExportCSVRequest request)
        {
            request.AddLog("GetAccountsHandler", "Get all financial account on database");

            request.InterestAndFineFinancialAccounts.Add(repository.GetByStore(request.Store));

            Sucessor?.ProcessRequest(request);
        }
    }
}
