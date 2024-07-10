using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Get.Handler
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

            request.AddManagementFinancialAccount(managementFinancialAccountReadOnlyRepository.GetbyFilter(w=> w.StoreType.Equals(request.StoreType)));

            if (request.ManagementFinancialAccount == null)
                request.AddLog("ManagementFinancialAccountGetUseCase", "No data found on database", TypeLog.Processing);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}

