using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices.RequestHandlers
{
    public class GetCustomerHandler : Handler<GetOpenInvoicesRequest>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;

        public GetCustomerHandler(ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public override void ProcessRequest(GetOpenInvoicesRequest request)
        {
            request.Customers = customerReadOnlyRepository.GetCustomers(request.GetExpression());

            if (!request.Customers.Any())
                return;
            
            sucessor?.ProcessRequest(request);
        }
    }
}
