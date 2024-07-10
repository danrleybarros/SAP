using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomerConsumption.RequestHandlers
{
    public class FillInvoiceObjectHandler : Handler
    {
        public override void ProcessRequest(CustomerConsumptionRequest request)
        {
            request.Invoices.ForEach(invoice =>
            {
                invoice.Customer = request.Customers.First();
                invoice.Services = request.Services.Where(w => w.InvoiceNumber.Equals(invoice.InvoiceNumber)).ToList();
            });
            
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
