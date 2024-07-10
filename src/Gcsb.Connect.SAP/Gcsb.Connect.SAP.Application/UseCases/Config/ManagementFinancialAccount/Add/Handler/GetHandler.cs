

using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Add.Handler
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

            var existManagement = managementFinancialAccountReadOnlyRepository.GetbyFilter(w=> w.StoreType.Equals(request.ManagementFinancialAccount.StoreType)) != null;

              if(existManagement)
                throw new ArgumentException($"duplicate key, there is already a saved configuration on database ");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
