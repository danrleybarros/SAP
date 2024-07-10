using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Get
{
    public class AccountGetUseCase : IUseCase<AccountGetRequest>
    {
        private readonly IOutputPort outputPort;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IInterestAndFineFinancialAccountReadOnlyRepository interestAndFineFinancialAccountReadOnlyRepository;

        public AccountGetUseCase(IOutputPort outputPort, 
            ILogWriteOnlyRepository logWriteOnlyRepository,
            IInterestAndFineFinancialAccountReadOnlyRepository interestAndFineFinancialAccountReadOnlyRepository)
        {
            this.outputPort = outputPort;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.interestAndFineFinancialAccountReadOnlyRepository = interestAndFineFinancialAccountReadOnlyRepository;
        }

        public void Execute(AccountGetRequest request)
        {
            try
            {
                request.AddLog("InterestAndFineFinancialAccountGetUseCase", "Processing request");

                request.AddManagementFinancialAccount(interestAndFineFinancialAccountReadOnlyRepository.GetByStore(request.Store));

                if (request.InterestAndFineFinancialAccount != null)
                    outputPort.Standard(request.InterestAndFineFinancialAccount);
                else
                {
                    request.AddLog("InterestAndFineFinancialAccountGetUseCase", "No data found on database");
                    outputPort.NotFound("No data found on database");
                } 
            }
            catch (Exception ex)
            {
                request.AddLogException("InterestAndFineFinancialAccountGetUseCase", $"Error on AccountGetUseCase : {ex.Message}", ex.StackTrace, TypeLog.Error);
                outputPort.Error($"Error on get :{ex.Message}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
