using System;
using System.Collections.Generic;
using System.Text;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCardIntercompany
{
    public class GetCriticalHandler : Handler<ARRCreditCardInter>, IGetCriticalHandler<ARRCreditCardInter>
    {
        public override void ProcessRequest(IARRRequest<ARRCreditCardInter> request)
        {
            sucessor?.ProcessRequest(request);
        }
    }
}
