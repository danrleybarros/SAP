using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomersConsumption.RequestHandlers
{
    public class FillInvoiceObjectHandler : Handler
    {
        public override void ProcessRequest(CustomersConsumptionRequest request)
        {
            request.Invoices.ForEach(invoice =>
            {
                invoice.Customer = request.Customers.First();
            });
            
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
