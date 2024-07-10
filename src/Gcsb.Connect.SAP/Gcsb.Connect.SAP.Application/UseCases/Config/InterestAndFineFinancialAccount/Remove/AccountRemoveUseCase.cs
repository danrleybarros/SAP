using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Remove.Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Remove
{
    public class AccountRemoveUseCase : IUseCase<AccountRemoveRequest>
    {
        private readonly GetHandler getHandler;
        private readonly IOutputPort outputPort;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public AccountRemoveUseCase(GetHandler getHandler, 
            RemoveHandler removeHandler,
            IOutputPort outputPort, 
            ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            getHandler.SetSucessor(removeHandler);

            this.getHandler = getHandler;
            this.outputPort = outputPort;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public void Execute(AccountRemoveRequest request)
        {
            try
            {
                request.AddLog("AccountRemoveUseCase", "Processing request");

                getHandler.ProcessRequest(request);

                if (request.InterestAndFineFinancialAccount != null)
                    outputPort.Standard(request.Id);
                else
                    outputPort.NotFound($"No data found on database to id: {request.Id}");
            }
            catch (Exception ex)
            {
                request.AddLogException("ManagementFinancialAccountRemoveUseCase", $"Error on AccountRemoveUseCase : {ex.Message}", ex.StackTrace, TypeLog.Error);
                outputPort.NotFound($"Error on remove :{ex.Message}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
