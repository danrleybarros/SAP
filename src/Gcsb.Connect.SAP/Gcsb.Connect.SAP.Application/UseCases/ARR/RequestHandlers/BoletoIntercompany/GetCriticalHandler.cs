using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Application.UseCases.Critical;
using Gcsb.Connect.SAP.Domain.ARR.ARRBoletoIntercompany;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.BoletoIntercompany
{
    class GetCriticalHandler : Handler<ARRBoletoInter>, IGetCriticalHandler<ARRBoletoInter>
    {
        public override void ProcessRequest(IARRRequest<ARRBoletoInter> request)
        {
            sucessor?.ProcessRequest(request);
        }
    }
}
