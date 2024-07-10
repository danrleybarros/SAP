using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InvoiceDetails.RequestHandlers
{
    public class FillInvoiceObjectHandler : Handler
    {
        public override void ProcessRequest(InvoiceDetailsRequest request)
        {
            request.Invoices.ForEach(invoice =>
            {
                invoice.Customer = request.Customers.First();
                invoice.Services = request.Services.Where(w => w.InvoiceNumber.Equals(invoice.InvoiceNumber)).ToList();
            });
            
            sucessor?.ProcessRequest(request);
        }
    }
}
