using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetUnPaidInvoicesByCustomers.RequestHandlers
{
    public class GetCustomerHandler : Handler<GetUnPaidInvoicesByCustomersRequest>
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;

        public GetCustomerHandler(ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public override void ProcessRequest(GetUnPaidInvoicesByCustomersRequest request)
        {
            request.DataDocuments
                .Select(s => s.GetExpression())
                .ToList()
                .ForEach(expression =>
                {
                    request.Customers.AddRange(customerReadOnlyRepository.GetCustomers(expression));
                });

            if (!request.Customers.Any())
                return;
            
            sucessor?.ProcessRequest(request);
        }
    }
}
