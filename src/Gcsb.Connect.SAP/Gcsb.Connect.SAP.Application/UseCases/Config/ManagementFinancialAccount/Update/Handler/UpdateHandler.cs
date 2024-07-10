
using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Update.Handler
{
    public class UpdateHandler : Handler
    {
        private readonly IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository;

        public UpdateHandler(IManagementFinancialAccountWriteOnlyRepository managementFinancialAccountWriteOnlyRepository)
        {
            this.managementFinancialAccountWriteOnlyRepository = managementFinancialAccountWriteOnlyRepository;
        }

        public override void ProcessRequest(ManagementFinancialAccountRequest request)
        {
            request.AddLog("ManagementFinancialAccountUpdateUseCase", "Updating managementFinancialAccount on database", TypeLog.Processing);
            
            var output = managementFinancialAccountWriteOnlyRepository.Update(request.ManagementFinancialAccount);

            if (output == 0)
                throw new ArgumentException($"Error on tryed update data of managementFinancialAccount on database to id :{request.ManagementFinancialAccount.Id}");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }

       
    }
}
