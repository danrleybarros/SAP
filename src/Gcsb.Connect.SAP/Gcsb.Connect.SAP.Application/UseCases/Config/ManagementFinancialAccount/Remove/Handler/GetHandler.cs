using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Remove.Handler
{
    public class GetHandler : Handler
    {
        private readonly IManagementFinancialAccountReadOnlyRepository managementFinancialAccountReadOnlyRepository;

        public GetHandler(IManagementFinancialAccountReadOnlyRepository managementFinancialAccountReadOnlyRepository)
        {
            this.managementFinancialAccountReadOnlyRepository = managementFinancialAccountReadOnlyRepository;
        }

        public override void ProcessRequest(ManagementFinancialAccountRequest request)
        {
            request.AddLog("GetHandler", "Getting managementFinancialAccount on database", TypeLog.Processing);

            request.AddManagementFinancialAccount(managementFinancialAccountReadOnlyRepository.GetById(request.Id));

            if (request.ManagementFinancialAccount == null)
            {
                request.AddLog("ManagementFinancialAccountRemoveUseCase", $"No data found on database to id: {request.Id}", TypeLog.Processing);
                return;
            }

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
