using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomerInvoices.RequestHandlers
{
    public class GetCustomerHandler : Handler
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;

        public GetCustomerHandler(ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public override void ProcessRequest(AllCustomerInvoicesRequest request)
        {
            request.Customers = customerReadOnlyRepository.GetCustomers(request.GetExpression());

            if(!request.Customers.Any())
            {
                return;
            }

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
