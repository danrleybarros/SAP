using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Boundaries.CustomerConsumption
{
    public class InvoiceDetailsOutput
    {
        public List<ConsumptionOutput> ConsumptionOutputs { get; set; }

        public InvoiceDetailsOutput(List<ConsumptionOutput> consumptionOutputs)
        {
            ConsumptionOutputs = consumptionOutputs;
        }
    }
}
