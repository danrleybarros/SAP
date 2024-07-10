using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories.Config;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.FinancialAccount.GetById.Handler
{
    public class GetHandler : Handler
    {
        private readonly IFinancialAccountReadOnlyRepository financialAccountReadOnlyRepository;

        public GetHandler(IFinancialAccountReadOnlyRepository financialAccountReadOnlyRepository)
        {
            this.financialAccountReadOnlyRepository = financialAccountReadOnlyRepository;
        }

        public override void ProcessRequest(FinancialAccountRequest request)
        {
            request.AddLog("GetHandler", "Getting financialAccount on database", TypeLog.Processing);

            request.AddManagementFinancialAccount(financialAccountReadOnlyRepository.GetFinancialAccount(request.Id));

            if (request.FinancialAccount == null)
                request.AddLog("FinancialAccount GetHandler ", "No data found on database", TypeLog.Processing);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}

