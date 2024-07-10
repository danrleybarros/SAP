using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Domain.Config.HistoryConsumption;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.HistoryConsumption.RequestHandler
{
    public class MountConsumptionHistoryHandler : Handler
    {
        public override void ProcessRequest(HistoryRequest request)
        {
            request.AddLog($"Mount consumption for types SAAS and IAAS", TypeLog.Processing);

            var consumptionSAAS = request.BillFeedDocs.Where(s => s.ServiceType.Equals("SAAS") && s.BillTo.HasValue).ToList();
            var consumptionIAAS = request.BillFeedDocs.Where(s => s.ServiceType.Equals("IAAS") && s.BillTo.HasValue).ToList();

            request.HistoryConsumptions.AddRange(GetConsumptionValue(consumptionSAAS));
            request.HistoryConsumptions.AddRange(GetConsumptionValue(consumptionIAAS));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }

        private List<HistoryConsumptionValue> GetConsumptionValue(List<BillFeedDoc> billFeedDocs)
        {
            var history = new List<HistoryConsumptionValue>();

            if (billFeedDocs.Count > 0)
            {
                var serviceType = billFeedDocs.Select(s => s.ServiceType).First();

                for (var cont = 1; cont <= 6; cont++)
                {
                    var month = DateTime.UtcNow.AddMonths(-cont).Month;

                    var invoices = billFeedDocs.Where(s => s.BillTo.Value.Month.Equals(month)).ToList();

                    var date = invoices.FirstOrDefault()?.BillTo?.ToString("MM/yyyy");

                    if (!string.IsNullOrEmpty(date))
                        history.Add(new HistoryConsumptionValue(serviceType, date, Convert.ToDecimal(invoices.Sum(s => s.GrandTotalRetailPrice ?? 0))));
                }
            }

            history = history.OrderBy(o => o.MonthYear).ToList();

            return history;
        }
    }
}
