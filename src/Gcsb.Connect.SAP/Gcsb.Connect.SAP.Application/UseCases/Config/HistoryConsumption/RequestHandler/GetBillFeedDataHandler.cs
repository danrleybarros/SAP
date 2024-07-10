using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.HistoryConsumption.RequestHandler
{
    public class GetBillFeedDataHandler : Handler
    {
        private readonly IBillFeedReadOnlyRepository billFeedReadOnlyRepository;

        public GetBillFeedDataHandler(IBillFeedReadOnlyRepository billFeedReadOnlyRepository)
        {
            this.billFeedReadOnlyRepository = billFeedReadOnlyRepository;
        }

        public override void ProcessRequest(HistoryRequest request)
        {
            request.AddLog($"Getting last six months billfeed data from the user: {request.CustomerCode}", TypeLog.Processing);

            var initPeriod = DateTime.UtcNow.AddMonths(-6);
            var endPeriod = DateTime.UtcNow.AddMonths(-1);
            var endDay = DateTime.DaysInMonth(endPeriod.Year, endPeriod.Month);
            var customerCode = request.CustomerCode.ToString().StartsWith('7') ? request.CustomerCode.ToString().Remove(0, 3) : request.CustomerCode.ToString();            

            request.BillFeedDocs = billFeedReadOnlyRepository.GetBillFeed(w =>
                (w.BillFrom.HasValue && w.BillFrom.Value.Date >= new DateTime(initPeriod.Year, initPeriod.Month, 1)) &&
                (w.BillTo.HasValue && w.BillTo.Value.Date <= new DateTime(endPeriod.Year, endPeriod.Month, endDay)) &&
                (w.CustomerCode.Equals(customerCode)));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
