using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.ARRCreditCardIntercompany;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCardIntercompany
{
    internal class ManualPaymentLaunchHandler : Handler<ARRCreditCardInter>, IManualPaymentLaunchHandler<ARRCreditCardInter>
    {
        public override void ProcessRequest(IARRRequest<ARRCreditCardInter> request)
        {

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
