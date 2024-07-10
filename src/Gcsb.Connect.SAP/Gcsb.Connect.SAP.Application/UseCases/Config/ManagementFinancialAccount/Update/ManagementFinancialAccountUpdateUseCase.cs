using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries.ManangementFinancialAccount;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Update.Handler;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Update
{
    public class ManagementFinancialAccountUpdateUseCase : IManagementFinancialAccountUpdateUseCase
    {
        private readonly UpdateHandler updateHandler;
        private readonly IOutputPort outputPort;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public ManagementFinancialAccountUpdateUseCase(UpdateHandler updateHandler, IOutputPort outputPort, ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            this.updateHandler = updateHandler;
            this.outputPort = outputPort;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public void Execute(ManagementFinancialAccountRequest request)
        {
            try
            {
                request.AddLog("ManagementFinancialAccountUpdateUseCase", "Processing request", TypeLog.Processing);

                updateHandler.ProcessRequest(request);

                outputPort.Standard(request.ManagementFinancialAccount.Id);

            }
            catch (Exception ex)
            {
                request.AddLogException("ManagementFinancialAccountUpdateUseCase", $"Error on ManagementFinancialAccountUpdateUseCase : {ex.Message}", ex.StackTrace, TypeLog.Error);
                outputPort.Error($"Error on remove ManagementFinancialAccount :{ex.Message}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
