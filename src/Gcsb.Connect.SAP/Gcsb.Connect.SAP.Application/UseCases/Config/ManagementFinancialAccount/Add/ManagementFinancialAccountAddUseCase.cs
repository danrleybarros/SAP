using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries.ManangementFinancialAccount;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Add.Handler;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Add
{
    public class ManagementFinancialAccountAddUseCase : IManagementFinancialAccountAddUseCase
    {
        private readonly GetHandler getHandler;
        private readonly IOutputPort outputPort;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;


        public ManagementFinancialAccountAddUseCase(GetHandler getHandler, SaveHandler saveHandler, IOutputPort outputPort, ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            getHandler.SetSucessor(saveHandler);          
            this.getHandler = getHandler;           
            this.outputPort = outputPort;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public void Execute(ManagementFinancialAccountRequest request)
        {
            try
            {
                request.AddLog("ManagementFinancialAccountAddUseCase", "Processing managementFinancialAccount on database", TypeLog.Processing);

                getHandler.ProcessRequest(request);

                outputPort.Standard(request.ManagementFinancialAccount.Id);
            }
            catch (Exception ex)
            {
                request.AddLogException("ManagementFinancialAccountAddUseCase", $"Error on ManagementFinancialAccountAddUseCase : {ex.Message}", ex.StackTrace, TypeLog.Error);
                outputPort.Error($"Error on add ManagementFinancialAccount :{ex.Message}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
