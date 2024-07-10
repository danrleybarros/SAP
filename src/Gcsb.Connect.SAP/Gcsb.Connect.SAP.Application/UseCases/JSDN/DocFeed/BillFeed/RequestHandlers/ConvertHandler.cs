using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.BillFeed.RequestHandlers
{
    public class ConvertHandler : Handler<BillFeedChainRequest>
    {
        private readonly IBillFeedConvertRepository billFeedConvertRepository;

        public ConvertHandler(IBillFeedConvertRepository billFeedConvertRepository)
        {
            this.billFeedConvertRepository = billFeedConvertRepository;
        }

        public override void ProcessRequest(BillFeedChainRequest request)
        {
            request.AddProcessingLog("BillFeed Ingest", "Converting csv file - BillFeed");

            if (string.IsNullOrEmpty(request.Base64String))
            {
                request.AddExceptionLog("BillFeed Ingest", "DocFeed file required", "");
                request.ReturnValue = 0;
            }

            request.BillFeedDocs = billFeedConvertRepository.FromCsv(request.Base64String, request.File.Id).ToList();

            sucessor?.ProcessRequest(request);
        }
    }
}
