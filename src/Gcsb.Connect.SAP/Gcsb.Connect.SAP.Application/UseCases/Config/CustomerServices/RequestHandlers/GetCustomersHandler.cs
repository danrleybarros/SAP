using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices.RequestHandlers
{
    public class GetCustomersHandler : Handler
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;

        public GetCustomersHandler(ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public override void ProcessRequest(CustomerServicesRequest request)
        {
            request.Logs.Add(new Log("CustomerServicesUseCase - GetCustomersHandler", "Getting Customers", Messaging.Messages.Log.Enum.TypeLog.Processing));
            var customers = customerReadOnlyRepository.GetCustomers(request.InvoiceNumbers);
            request.ServicesInvoices.ForEach(service => {
                service.Invoice.Customer = customers.Find(c => c.InvoiceNumber.Equals(service.InvoiceNumber));
            });

            successor?.ProcessRequest(request);
        }
    }
}
