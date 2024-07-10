using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeedConsumption.RequestHandler
{
    public class GetCustomerHandler : Handler
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;

        public GetCustomerHandler(ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public override void ProcessRequest(PaymentfeedConsumptionRequest request)
        {
            request.Customers.AddRange(customerReadOnlyRepository.GetCustomers(s => request.CustomerCode.Contains(s.CustomerCode))); 

            if (request.Customers.Count == 0)
                throw new ArgumentException("Not found customer");

            request.InvoicesNumber.AddRange(request.Customers.Select(s => s.InvoiceNumber).ToList());

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
