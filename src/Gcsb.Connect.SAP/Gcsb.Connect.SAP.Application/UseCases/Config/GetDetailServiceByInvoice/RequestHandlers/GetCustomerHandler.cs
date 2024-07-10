using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetDetailServiceByInvoice.RequestHandlers
{
    public class GetCustomerHandler : Handler
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;

        public GetCustomerHandler(ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public override void ProcessRequest(GetDetailServiceByInvoiceRequest request)
        {
            request.Customers = customerReadOnlyRepository
                .GetCustomers(i => request.InvoicesNumber.Contains(i.InvoiceNumber));

            if (!request.Customers.Any())
            {
                return;
            }

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
