using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCard
{
    public class ManualPaymentLaunchHandler : Handler<ARRCreditCard>, IManualPaymentLaunchHandler<ARRCreditCard>
    {
        public override void ProcessRequest(IARRRequest<ARRCreditCard> request)
        {

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
