using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries.InterestAndFineFinancialAccount;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.InterestAndFineFinancialAccount;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.Update
{
    public class AccountUpdateUseCase : IUseCase<AccountUpdateRequest>
    {
        private readonly IInterestAndFineFinancialAccountWriteOnlyRepository interestAndFineFinancialAccountWriteOnlyRepository;
        private readonly IOutputPort outputPort;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public AccountUpdateUseCase(IInterestAndFineFinancialAccountWriteOnlyRepository interestAndFineFinancialAccountWriteOnlyRepository, 
            IOutputPort outputPort, 
            ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            this.interestAndFineFinancialAccountWriteOnlyRepository = interestAndFineFinancialAccountWriteOnlyRepository;
            this.outputPort = outputPort;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public void Execute(AccountUpdateRequest request)
        {
            try
            {
                request.AddLog("AccountUpdateUseCase", "Processing request");

                var output = interestAndFineFinancialAccountWriteOnlyRepository.Update(request.InterestAndFineFinancialAccount);

                if (output == 0)
                    throw new ArgumentException($"Error on tryed update data of Financial Account on database to id :{request.InterestAndFineFinancialAccount.Id}");

                outputPort.Standard(request.InterestAndFineFinancialAccount.Id);
            }
            catch (Exception ex)
            {
                request.AddLogException("InterestAndFineFinancialAccount", $"Error on AccountUpdateUseCase : {ex.Message}", ex.StackTrace, TypeLog.Error);
                outputPort.Error($"Error on remove :{ex.Message}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
