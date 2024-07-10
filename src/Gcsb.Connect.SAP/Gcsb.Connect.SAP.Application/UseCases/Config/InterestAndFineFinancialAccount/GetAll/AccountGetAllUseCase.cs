using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.GetAll
{
    public class AccountGetAllUseCase : IUseCase<AccountGetAllRequest>
    {
        private readonly IOutputPort outputPort;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IInterestAndFineFinancialAccountReadOnlyRepository interestAndFineFinancialAccountReadOnlyRepository;

        public AccountGetAllUseCase(IOutputPort outputPort, 
            ILogWriteOnlyRepository logWriteOnlyRepository, 
            IInterestAndFineFinancialAccountReadOnlyRepository interestAndFineFinancialAccountReadOnlyRepository)
        {
            this.outputPort = outputPort;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
            this.interestAndFineFinancialAccountReadOnlyRepository = interestAndFineFinancialAccountReadOnlyRepository;
        }

        public void Execute(AccountGetAllRequest request)
        {
            try
            {
                request.AddLog("InterestAndFineFinancialAccountGetUseCase", "Processing request");

                request.AddManagementFinancialAccount(interestAndFineFinancialAccountReadOnlyRepository.GetAll());

                outputPort.Standard(request.InterestAndFineFinancialAccounts);
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
