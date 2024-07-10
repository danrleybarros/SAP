using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.Config.CreditGrantedFinancialAccount;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CreditGrantedFinancialAccount.GetByStore
{
    public class GetByStoreUseCase : IGetByStoreUseCase
    {
        private readonly ICreditGrantedFinancialAccountReadOnlyRepository readOnlyRepository;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;
        private readonly IOutputPort<GetByStoreOutput> outputPort;

        public GetByStoreUseCase(ICreditGrantedFinancialAccountReadOnlyRepository readOnlyRepository,
            IOutputPort<GetByStoreOutput> outputPort,
            ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            this.readOnlyRepository = readOnlyRepository;
            this.outputPort = outputPort;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public void Execute(GetByStoreRequest request)
        {
            try
            {
                request.AddLog("CreditGrantedFinancialAccount GetByStore", "Getting Credit Granted Financial Accounts.", TypeLog.Processing);
                var account = readOnlyRepository.GetByStore(request.StoreAcronym);

                if (account == null)
                {
                    request.AddLog("CreditGrantedFinancialAccount GetByStore", $"No data found on dabatase for store {request.StoreAcronym}", TypeLog.Processing);
                    outputPort.NotFound($"No data found on dabatase for store {request.StoreAcronym}");
                    return;
                }

                request.Output = new GetByStoreOutput() { CreditGrantedFinancialAccount = account };
                outputPort.Standard(request.Output);
            }
            catch (Exception ex)
            {
                request.AddLogException("CreditGrantedFinancialAccount", $"Error on GetByStoreUseCase: {ex.Message} ", ex.StackTrace);
                outputPort.Error($"Error on CreditGrantedFinancialAccount GetByStoreUseCase: {ex.Message}");
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
