using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.Services.ServiceResponse
{
    public class ServiceOutput
    {
        public string InvoiceNumber { get; set; }

        public List<Service> Services { get; set; }
    }

    public class Service
    {
        public string ServiceType { get; set; }
        public double Value { get; set; }
    }
}
