using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Remove.Handler
{
    public class RemoveHandler : Handler
    {
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;

        public RemoveHandler(IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository)
        {
            this.managementFinancialAccountWriteOnlyRepository = managementFinancialAccountWriteOnlyRepository;
        }

        public override void ProcessRequest(ManagementFinancialAccountRequest request)
        {
            request.AddLog("ManagementFinancialAccountRemoveUseCase", "Removing managementFinancialAccount on database", TypeLog.Processing);

            var output = managementFinancialAccountWriteOnlyRepository.Remove(request.ManagementFinancialAccount);

            if (output == 0)
                throw new ArgumentException($"Error on tryed remove data of managementFinancialAccount on database to id {request.Id}");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
