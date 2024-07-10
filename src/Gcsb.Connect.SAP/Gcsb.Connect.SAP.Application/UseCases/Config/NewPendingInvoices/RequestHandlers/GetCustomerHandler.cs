using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.NewPendingInvoices.RequestHandlers
{
    public class GetCustomerHandler : Handler
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;

        public GetCustomerHandler(ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public override void ProcessRequest(NewPendingInvoicesRequest request)
        {
            var result = customerReadOnlyRepository.GetCustomers(request.InvoicesNumbers);

            request.Customers.AddRange(result);

            if (!request.Customers.Any())
            {
                return;
            }

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
