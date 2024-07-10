using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Config.CreditGrantedFinancialAccount;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.Save
{
    public class SaveUseCase : ISaveUseCase
    {
        private readonly ICreditGrantedFinancialAccountWriteOnlyRepository writeOnlyRepository;
        private readonly ICreditGrantedFinancialAccountReadOnlyRepository readOnlyRepository;
        private readonly IOutputPort<Guid> outputPort;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public SaveUseCase(ICreditGrantedFinancialAccountWriteOnlyRepository writeOnlyRepository,
            ICreditGrantedFinancialAccountReadOnlyRepository readOnlyRepository,
            IOutputPort<Guid> outputPort,
            ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            this.writeOnlyRepository = writeOnlyRepository;
            this.readOnlyRepository = readOnlyRepository;
            this.outputPort = outputPort;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public void Execute(SaveRequest request)
        {
            try
            {
                request.AddLog("CreditGrantedFinancialAccount Save", "Saving Credit Granted Financial Account.", Messaging.Messages.Log.Enum.TypeLog.Processing);
                SaveAccount(request.CreditGrantedFinancialAccount);
                outputPort.Standard(request.CreditGrantedFinancialAccount.Id.Value);
            }
            catch (Exception ex)
            {
                request.AddLogException("CreditGrantedFinancialAccount", $"Error on SaveUseCase: {ex.Message} ", ex.StackTrace);
                outputPort.Error($"Error on CreditGrantedFinancialAccount SaveUseCase: {ex.Message}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }

        private void SaveAccount(Domain.Config.CreditGrantedFinancialAccount.CreditGrantedFinancialAccount creditGrantedFinancialAccount)
        {
            var account = readOnlyRepository.GetByStore(creditGrantedFinancialAccount.StoreAcronym);
            if (account == null)
            {
                creditGrantedFinancialAccount.Id = Guid.NewGuid();
                writeOnlyRepository.Add(creditGrantedFinancialAccount);
                return;
            }

            if (creditGrantedFinancialAccount.Id == null)
                creditGrantedFinancialAccount.Id = account.Id;
            writeOnlyRepository.Update(creditGrantedFinancialAccount);
        }
    }
}
