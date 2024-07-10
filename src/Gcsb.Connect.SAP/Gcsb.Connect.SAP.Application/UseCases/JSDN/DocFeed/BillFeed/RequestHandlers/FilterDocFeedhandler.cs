using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.DocFeed.BillFeed.RequestHandlers
{
    public class FilterDocFeedhandler : Handler<BillFeedChainRequest>
    {
        private string[] removedTypes = new string[] { "Cancellation" };

        public override void ProcessRequest(BillFeedChainRequest request)
        {
            request.BillFeedDocs = request.BillFeedDocs.Where(w => !removedTypes.Contains(w.Activity)).ToList();
            request.BillFeedDocs.Where(w => w.Activity.ToUpper().Equals("REDUCTION")).ToList().ForEach(f => f.SetGrandTotalRetailPrice((f.GrandTotalRetailPrice ?? 0) * -1));

            var dateFromMax = request.BillFeedDocs.Where(f => !string.IsNullOrEmpty(f.ServiceType)).Max(m => m.BillFrom).Value;
            var dateToMax = request.BillFeedDocs.Where(f => !string.IsNullOrEmpty(f.ServiceType)).Max(m => m.BillTo).Value;
            var listFinesInterest = new string[] { "FINES", "INTEREST" };

            request.BillFeedDocs.Where(w => listFinesInterest.Contains(w.Activity.ToUpper()))
                .ToList()
                .ForEach(f =>
                {
                    f.SetBillFrom(dateFromMax);
                    f.SetBillTo(dateToMax);
                });

            request.DocFeed.AddRange(request.BillFeedDocs);

            sucessor?.ProcessRequest(request);
        }
    }
}
