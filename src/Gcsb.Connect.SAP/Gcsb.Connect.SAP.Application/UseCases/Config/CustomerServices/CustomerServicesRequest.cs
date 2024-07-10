using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Domain.Config.CustomerService;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomerServices
{
    public class CustomerServicesRequest
    {
        public List<Log> Logs { get; set; }
        public List<string> InvoiceNumbers { get; private set; }
        public List<ServiceInvoice> ServicesInvoices { get; set; }
        public List<CustomerService> CustomerServices { get; set; }

        public CustomerServicesRequest(List<string> invoiceNumbers)
        {
            InvoiceNumbers = invoiceNumbers;
            Logs = new List<Log>();
            ServicesInvoices = new List<ServiceInvoice>();
            CustomerServices = new List<CustomerService>();
        }
    }
}
