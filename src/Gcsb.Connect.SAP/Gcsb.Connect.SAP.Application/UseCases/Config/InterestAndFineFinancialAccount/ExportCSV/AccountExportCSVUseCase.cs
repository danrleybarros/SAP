using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.ExportCSV.Handler;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount.ExportCSV
{
    public class AccountExportCSVUseCase : IUseCase<AccountExportCSVRequest>
    {
        private readonly GetAccountsHandler getAllHandler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public AccountExportCSVUseCase(GetAccountsHandler getAllHandler, 
            GetContentCSVHandler getContentCSVHandler,
            ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            getAllHandler.SetSucessor(getContentCSVHandler);

            this.getAllHandler = getAllHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public void Execute(AccountExportCSVRequest request)
        {
            try
            {
                request.AddLog("InterestAndFineFinancialAccount", "ExportCSV - Get All Financial Account of Interest And Fine");

                getAllHandler.ProcessRequest(request);
            }
            catch (Exception ex)
            {
                request.AddLogException("InterestAndFineFinancialAccount", $"Error on AccountExportCSVUseCase : {ex.Message}", ex.StackTrace, TypeLog.Error);
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
