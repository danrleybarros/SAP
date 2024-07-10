using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Add.Handler
{
    public class SaveHandler : Handler<AccountAddRequest>
    {
        private readonly IInterestAndFineFinancialAccountWriteOnlyRepository repository;

        public SaveHandler(IInterestAndFineFinancialAccountWriteOnlyRepository repository)
        {
            this.repository = repository;
        }

        public override void ProcessRequest(AccountAddRequest request)
        {
            request.AddLog("SaveHandler", "Saving financial account on database");

            repository.Add(request.InterestAndFineFinancialAccount);

            Sucessor?.ProcessRequest(request);
        }
    }
}
