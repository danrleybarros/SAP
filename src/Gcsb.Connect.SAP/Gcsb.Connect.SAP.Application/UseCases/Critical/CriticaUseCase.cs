using Gcsb.Connect.SAP.Application.UseCases.Critical.RequestHandlers;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Critical
{
    public class CriticaUseCase : ICriticaUseCase
    {
        private readonly AccountsHandler accountsHandler;

        public CriticaUseCase(AccountsHandler accountsHandler,
            CriticaHandler criticaHandler,
            GetAccountingEntryHandler getAccountingEntryHandler,
            LaunchHandler launchHandler)
        {
            accountsHandler.SetSucessor(getAccountingEntryHandler);
            getAccountingEntryHandler.SetSucessor(criticaHandler);
            criticaHandler.SetSucessor(launchHandler);

            this.accountsHandler = accountsHandler;
        }

        public int Execute(CriticaRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Critica - Requets object is null");

            try
            {
                accountsHandler.ProcessRequest(request);
                return 1;
            }
            catch(Exception e)
            {
                request.AddExceptionLog(e.Message, e.StackTrace);
                return 0;
            }
        }
    }
}
