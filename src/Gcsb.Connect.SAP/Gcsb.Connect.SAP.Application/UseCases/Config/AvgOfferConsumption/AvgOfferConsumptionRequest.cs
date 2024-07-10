using System;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AvgOfferConsumption
{
    public class AvgOfferConsumptionRequest
    {
        public DateTime StartConsumptioPeriod { get; private set; }
        public DateTime EndConsumptionPeriod { get; private set; }
        public string OfferCode { get; private set; }

        public AvgOfferConsumptionRequest(DateTime startConsumptioPeriod, DateTime endConsumptionPeriod, string offerCode)
        {
            StartConsumptioPeriod = startConsumptioPeriod;
            EndConsumptionPeriod = endConsumptionPeriod;
            OfferCode = offerCode;
        }
    }
}
