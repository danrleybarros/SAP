using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Add.Handler;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Add
{
    public class AccountAddUseCase : IUseCase<AccountAddRequest>
    {
        private readonly GetHandler getHandler;
        private readonly IOutputPort outputPort;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public AccountAddUseCase(GetHandler getHandler, 
            SaveHandler saveHandler,
            IOutputPort outputPort, 
            ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            getHandler.SetSucessor(saveHandler);

            this.getHandler = getHandler;
            this.outputPort = outputPort;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public void Execute(AccountAddRequest request)
        {
            try
            {
                request.AddLog("InterestAndFineFinancialAccount", "Processing request");
                
                getHandler.ProcessRequest(request);

                outputPort.Standard(request.InterestAndFineFinancialAccount.Id);
            }
            catch (Exception ex)
            {
                request.AddLogException("InterestAndFineFinancialAccount", $"Error on AccountAddUseCase : {ex.Message}", ex.StackTrace, TypeLog.Error);
                outputPort.Error($"Error on add :{ex.Message}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
