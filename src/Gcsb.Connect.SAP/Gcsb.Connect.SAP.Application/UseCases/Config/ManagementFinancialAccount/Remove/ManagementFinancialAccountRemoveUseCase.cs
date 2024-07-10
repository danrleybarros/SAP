using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries.ManangementFinancialAccount;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Remove.Handler;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.ManagementFinancialAccount.Remove
{
    public class ManagementFinancialAccountRemoveUseCase : IManagementFinancialAccountRemoveUseCase
    {
        private readonly GetHandler getHandler;        
        private readonly IOutputPort outputPort;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;       

        public ManagementFinancialAccountRemoveUseCase(GetHandler getHandler, RemoveHandler removeHandler, IOutputPort outputPort, ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            getHandler.SetSucessor(removeHandler);
            this.getHandler = getHandler;            
            this.outputPort = outputPort;
            this.logWriteOnlyRepository = logWriteOnlyRepository;          
        }

        public void Execute(ManagementFinancialAccountRequest request)
        {
            try
            {
                request.AddLog("ManagementFinancialAccountRemoveUseCase", "Processing request managementFinancialAccountRequest" , TypeLog.Processing);

                getHandler.ProcessRequest(request);
                
                if (request.ManagementFinancialAccount != null)
                    outputPort.Standard(request.Id);
                else
                    outputPort.NotFound($"No data found on database to id: {request.Id}");
            }
            catch (Exception ex)
            {
                request.AddLogException("ManagementFinancialAccountRemoveUseCase", $"Error on ManagementFinancialAccountRemoveUseCase : {ex.Message}",ex.StackTrace, TypeLog.Error);
                outputPort.NotFound($"Error on remove ManagementFinancialAccount :{ex.Message}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
