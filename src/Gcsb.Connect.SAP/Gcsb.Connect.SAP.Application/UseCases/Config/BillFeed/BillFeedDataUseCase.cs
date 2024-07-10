using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.Messaging.Messages.Log;
using System;
using System.Collections.Generic;
using Gcsb.Connect.SAP.Application.Boundaries;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.BillFeed
{
    public class BillFeedDataUseCase : IBillFeedDataUseCase
    {
        private readonly IOutputPort<List<BillFeedDoc>> output;
        private readonly IBillFeedReadOnlyRepository billFeedReadOnlyRepository;
        private readonly ILogWriteOnlyRepository logWriteOnlyRepository;

        public BillFeedDataUseCase(IOutputPort<List<BillFeedDoc>> output, IBillFeedReadOnlyRepository billFeedReadOnlyRepository, ILogWriteOnlyRepository logWriteOnlyRepository)
        {
            this.output = output;
            this.billFeedReadOnlyRepository = billFeedReadOnlyRepository;
            this.logWriteOnlyRepository = logWriteOnlyRepository;
        }

        public void Execute(BillFeedRequest request)
        {
            var logs = new List<Log>();

            try
            {
                logs.Add(new Log("BillFeedData", "Getting billfeeddata with the cycle parameter", Messaging.Messages.Log.Enum.TypeLog.Processing));

                var billFeedDocs = billFeedReadOnlyRepository.GetBillFeed(w => w.BillFrom.Value.Date >= request.BillFromDate.Date && w.BillTo.Value.Date <= request.BillToDate.Date);
                output.Standard(billFeedDocs);
            }
            catch (Exception ex)
            {
                logs.Add(new Log("BillFeedData", $"Error on billfeeddata with the cycle parameter: {ex.Message} {ex.StackTrace}", Messaging.Messages.Log.Enum.TypeLog.Processing));
                output.Error($"Error on get data: {ex.Message} {ex.StackTrace}");

                throw ex;
            }
            finally
            {
                logWriteOnlyRepository.Add(logs);
            }
        }
    }
}
