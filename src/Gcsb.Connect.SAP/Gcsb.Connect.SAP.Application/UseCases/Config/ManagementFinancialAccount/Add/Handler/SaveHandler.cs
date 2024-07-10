using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Add.Handler
{
    public class SaveHandler : Handler
    {
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;

        public SaveHandler(IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository)
        {
            this.managementFinancialAccountWriteOnlyRepository = managementFinancialAccountWriteOnlyRepository;
        }

        public override void ProcessRequest(ManagementFinancialAccountRequest request)
        {                         
            request.AddLog("SaveHandler", "Saving nanagement financial account on database", Messaging.Messages.Log.Enum.TypeLog.Processing);

            managementFinancialAccountWriteOnlyRepository.Add(request.ManagementFinancialAccount);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
