using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries.ManangementFinancialAccount;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Get.Handler;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Get
{
    public class ManagementFinancialAccountGetUseCase : IManagementFinancialAccountGetUseCase
    {
        private readonly GetHandler getHandler;
        private readonly IOutputPort outputPort;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public ManagementFinancialAccountGetUseCase(GetHandler getHandler, IOutputPort outputPort, ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            this.getHandler = getHandler;
            this.outputPort = outputPort;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public void Execute(ManagementFinancialAccountRequest request)
        {
            try
            {
                request.AddLog("ManagementFinancialAccountGetUseCase", "Processing managementFinancialAccount on database", TypeLog.Processing);

                getHandler.ProcessRequest(request);

                if (request.ManagementFinancialAccount != null)
                    outputPort.Standard(request.ManagementFinancialAccount);
                else
                    outputPort.NotFound("No data found on database");

            }
            catch (Exception ex)
            {
                request.AddLogException("ManagementFinancialAccountGetUseCase", $"Error on ManagementFinancialAccountGetUseCase : {ex.Message}", ex.StackTrace, TypeLog.Error);
                outputPort.Error($"Error on get ManagementFinancialAccount :{ex.Message}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
