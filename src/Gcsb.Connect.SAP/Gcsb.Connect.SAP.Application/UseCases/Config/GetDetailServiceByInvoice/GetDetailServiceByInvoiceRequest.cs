using Gcsb.Connect.SAP.Application.Boundaries.GetDetailServiceByInvoice;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetDetailServiceByInvoice
{
    public class GetDetailServiceByInvoiceRequest
    {
        public List<string> InvoicesNumber { get; private set; }
        public List<Invoice> Invoices { get; set; }
        public List<Customer> Customers { get; set; }
        public List<ServiceInvoice> ServiceInvoices { get; set; }
        public GetDetailServiceByInvoiceOutput Consumptions { get; set; }

        public GetDetailServiceByInvoiceRequest(List<string> invoicesNumber)
        {
            InvoicesNumber = invoicesNumber;
            Invoices = new List<Invoice>();
            Customers = new List<Customer>();
            ServiceInvoices = new List<ServiceInvoice>();
        }
    }
}
