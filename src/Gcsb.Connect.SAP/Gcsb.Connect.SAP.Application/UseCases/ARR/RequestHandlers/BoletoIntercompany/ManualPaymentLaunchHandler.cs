using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.Pay;
using Gcsb.Connect.SAP.Application.UseCases.ARR.IRequestHandlers;
using Gcsb.Connect.SAP.Domain.ARR;
using Gcsb.Connect.SAP.Domain.ARR.ARRBoletoIntercompany;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.ARR.RequestHandlers.BoletoIntercompany
{
    public class ManualPaymentLaunchHandler : Handler<ARRBoletoInter>, IManualPaymentLaunchHandler<ARRBoletoInter>
    {
        public override void ProcessRequest(IARRRequest<ARRBoletoInter> request)
        {
            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
