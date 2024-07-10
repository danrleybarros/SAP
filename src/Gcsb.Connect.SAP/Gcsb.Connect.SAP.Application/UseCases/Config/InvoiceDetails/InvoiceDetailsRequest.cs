using Gcsb.Connect.SAP.Application.Boundaries.CustomerConsumption;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InvoiceDetails
{
    public class InvoiceDetailsRequest
    {
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<ServiceInvoice> Services { get; set; } = new List<ServiceInvoice>();
        public List<ConsumptionOutput> Consumptions { get; set; } = new List<ConsumptionOutput>();
        public List<PaymentCreditCard> PaymentsCredit { get; set; } = new List<PaymentCreditCard>();
        public List<PaymentBoleto> PaymentsBoleto { get; set; } = new List<PaymentBoleto>();
        public List<string> InvoiceNumbers { get; }

        public InvoiceDetailsRequest(List<string> invoiceNumbers)
        {
            InvoiceNumbers = invoiceNumbers;
        }

        public InvoiceDetailsOutput Output => new(Consumptions);
    }
}
