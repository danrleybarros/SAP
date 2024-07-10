using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries.FinancialAccount;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.FinancialAccount.GetById.Handler;
using System;


namespace Gcsb.Connect.SAP.Application.UseCases.Config.FinancialAccount.GetById
{
    public class FinancialAccountGetByIdUseCase : IFinancialAccountGetByIdUseCase
    {
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IOutputPort outputPort;
        private readonly GetHandler getHandler;

        public FinancialAccountGetByIdUseCase(GetHandler getHandler, ILogWriteOnlyRepository logWriteOnlyRepository, IOutputPort outputPort)
        {
            this.getHandler = getHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.outputPort = outputPort;
        }       

        public void Execute(FinancialAccountRequest request)
        {
            try
            {
                getHandler.ProcessRequest(request);

                if (request.FinancialAccount != null)
                    outputPort.Standard(request.FinancialAccount);
                else
                    outputPort.NotFound($"No data found on databasae to id: {request.Id}");
            }
            catch (Exception ex)
            {
                request.AddLogException("Api financial account", $"Error on FinancialAccountGetByIdUseCase  {ex.Message} ", ex.StackTrace, TypeLog.Error);
                outputPort.Error($"Error on FinancialAccountGetByIdUseCase: {ex.Message}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
