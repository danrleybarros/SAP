using System.Linq;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.BillFeed.RequestHandlers
{
    public class InsertQueueHandler : Handler<BillFeedChainRequest>
    {
        private readonly IPublisher<BillFeedFile> publisher;

        public InsertQueueHandler(IPublisher<BillFeedFile> publisher)
        {
            this.publisher = publisher;
        }

        public override void ProcessRequest(BillFeedChainRequest request)
        {
            if (request.File.Status.Equals(Status.Success))
            {
                var billFile = new BillFeedFile(request.File.Id, TypeRegister.BILLCSV, request.File.FileName, TypeProcess.Original, request.Invoices.Where(w => w.BillTo != null)
                    .Max(x => x.BillTo.Value));

                publisher.PublishAsync(billFile);
            }
    
            sucessor?.ProcessRequest(request);
        }
    }
}