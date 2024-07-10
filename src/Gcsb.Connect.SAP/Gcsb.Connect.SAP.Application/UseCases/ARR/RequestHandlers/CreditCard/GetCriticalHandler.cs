using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR.CreditCard;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.CreditCard
{
    class GetCriticalHandler : Handler<ARRCreditCard>, IGetCriticalHandler<ARRCreditCard>
    {
        public override void ProcessRequest(IARRRequest<ARRCreditCard> request)
        {
            sucessor?.ProcessRequest(request);
        }
    }
}
