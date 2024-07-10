using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.BillFeed.RequestHandlers
{
    public class SaveDocsHandler : Handler<BillFeedChainRequest>
    {
        private readonly IBillFeedWriteOnlyRepository billFeedWriteOnlyRepository;

        public SaveDocsHandler(IBillFeedWriteOnlyRepository billFeedWriteOnlyRepository)
        {
            this.billFeedWriteOnlyRepository = billFeedWriteOnlyRepository;
        }

        public override void ProcessRequest(BillFeedChainRequest request)
        {
            request.AddProcessingLog("BillFeed Ingest", "Saving BillFeedDoc - BillFeed", request.File.Id);
            request.TotalDocs = billFeedWriteOnlyRepository.Add(request.BillFeedDocs);

            if (request.TotalDocs < 1)
            {
                request.AddExceptionLog("Saving BillFeedDoc - BillFeed", "Error to save billfeed doc", "");
                request.ReturnValue = 0;
                return;
            }

            sucessor?.ProcessRequest(request);
        }
    }
}