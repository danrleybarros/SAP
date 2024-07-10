using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.Critical;
using Gcsb.Connect.SAP.Domain.ARR.Boleto;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.Boleto
{
    class GetCriticalHandler : Handler<ARRBoleto>, IGetCriticalHandler<ARRBoleto>
    {
        private ICriticaUseCase criticaUseCase;

        public GetCriticalHandler(ICriticaUseCase criticaUseCase)
        {
            this.criticaUseCase = criticaUseCase;
        }

        public override void ProcessRequest(IARRRequest<ARRBoleto> request)
        {
            request.AddProcessingLog("Get data of the critical pay");

            var registerDate = request.paymentBoletos[0].DateProcessing.AddDays(-1);

            var criticaRequest = new CriticaRequest(request.IDPaymentFeed);

            // TO DO Verificar mapeamento storeType estourando exceção
            criticaUseCase.Execute(criticaRequest);

            if (criticaRequest.Logs.Any(f => f.TypeLog == TypeLog.Error))
            {
                request.Logs.AddRange(criticaRequest.Logs);
                throw new Exception("Error: Failed to consume data on critical payments");
            }

            request.Criticals = criticaRequest.LaunchItems;

            sucessor?.ProcessRequest(request);
        }
    }
}
