using System;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.Deferral.RequestHandlers;

namespace Gcsb.Connect.SAP.Application.UseCases.Deferral
{
    public class DeferralUseCase : IDeferralUseCase
    {
        private readonly GetDataHandler getDataHandler;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public DeferralUseCase(GetDataHandler getDataHandler, 
            ValidateRulesHandler validateRulesHandler,           
            SaveDeferralOffersHandler saveDeferralOffersHandler, 
            ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            getDataHandler.SetSucessor(validateRulesHandler)
                          .SetSucessor(saveDeferralOffersHandler);               

            this.getDataHandler = getDataHandler;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public void Execute(DeferralRequest request)
        {
            try
            {
                request.AddProcessingLog("Started Deferral Process");

                getDataHandler.ProcessRequest(request);

            }
            catch (Exception e)
            {
                request.AddExceptionLog(e.Message, e.StackTrace);
            }
            finally
            {
                logWriteOnlyRepository.Add(request.Logs);
            }
        }
    }
}
