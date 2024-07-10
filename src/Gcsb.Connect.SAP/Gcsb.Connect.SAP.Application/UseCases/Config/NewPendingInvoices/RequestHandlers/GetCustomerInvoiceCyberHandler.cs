using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.NewPendingInvoices.RequestHandlers
{
    public class GetCustomerInvoiceCyberHandler : Handler
    {
        public override void ProcessRequest(NewPendingInvoicesRequest request)
        {
            request.Customers                
                .Select(s => new KeyValuePair<string, string>( s.InvoiceNumber, s.CustomerCode))
                .ToList()
                .ForEach(e =>
                {
                    request.CustomerInvoiceCyber.Add(e.Key, e.Value);
                });

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
