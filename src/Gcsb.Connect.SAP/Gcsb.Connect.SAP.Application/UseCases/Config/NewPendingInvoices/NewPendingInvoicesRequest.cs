using Gcsb.Connect.SAP.Application.Boundaries.NewPendingInvoices;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.NewPendingInvoices
{
    public class NewPendingInvoicesRequest
    {
        public List<string> InvoicesNumbers { get; private set; }
        public Dictionary<string, string> CustomerInvoiceCyber { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Customer> UnPaidInvoicesCustomer { get; set; }
        public List<PaymentCreditCard> PaymentsCredit { get; set; }
        public List<PaymentBoleto> PaymentsBoleto { get; set; }
        public List<NewPendingInvoicesOutput> Consumptions { get; set; }

        public NewPendingInvoicesRequest(List<string> invoicesNumbers)
        {
            InvoicesNumbers = invoicesNumbers;
            CustomerInvoiceCyber = new Dictionary<string, string>();
            Customers = new List<Customer>();
            UnPaidInvoicesCustomer = new List<Customer>();
            PaymentsCredit = new List<PaymentCreditCard>();
            PaymentsBoleto = new List<PaymentBoleto>();
            Consumptions = new List<NewPendingInvoicesOutput>();
        }
    }
}
