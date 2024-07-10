using Gcsb.Connect.SAP.Application.Repositories.Pay.Critical;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Critical.RequestHandlers
{
    public class CriticaHandler : Handler
    {
        private readonly ICriticaReadRepository criticaReadRepository;

        public CriticaHandler(ICriticaReadRepository criticaReadRepository)
        {
            this.criticaReadRepository = criticaReadRepository;
        }

        public override void ProcessRequest(CriticaRequest request)
        {
            request.AddProcessingLog("Consulting Criticas");


            request.Criticas = criticaReadRepository.get(request.IdPayment);

            if (request.Criticas.Count == 0)
            {
                request.AddProcessingLog("Don't have any datas for Criticas");
                return;
            }

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
