using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.AvgOfferConsumption
{
    public class AvgOfferConsumptionInput
    {
        public DateTime StartConsumptioPeriod { get; set; }
        public DateTime EndConsumptionPeriod { get; set; }
        public string OfferCode { get; set; }
    }
}