using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.BillFeed.RequestHandlers
{
    public class SplitBillFeedDocHandler : Handler<BillFeedChainRequest>
    {
        public override void ProcessRequest(BillFeedChainRequest request)
        {
            request.AddProcessingLog("BillFeed Ingest", "Splitting BillFeed - BillFeed", request.File.Id);

            var ret = request.SplitBillFeedDocs();

            if (ret < 1)
            {
                request.ReturnValue = 0;
                return;
            }

            sucessor?.ProcessRequest(request);
        }

    }

}
