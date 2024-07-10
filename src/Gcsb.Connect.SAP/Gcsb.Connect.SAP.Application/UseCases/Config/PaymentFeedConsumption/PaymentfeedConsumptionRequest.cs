using Gcsb.Connect.SAP.Application.Boundaries.PaymentFeedConsumption;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.PaymentFeedConsumption
{
    public class PaymentfeedConsumptionRequest
    {
        public string CustomerCode { get; private set; }
        public List<Customer> Customers { get; set; }
        public List<string> InvoicesNumber { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<PaymentBoleto> PaymentsBoleto { get; set; }
        public List<PaymentCreditCard> PaymentsCredit { get; set; }
        public List<PaymentFeedOutput> PaymentFeedsOutput { get; set; }

        public PaymentfeedConsumptionRequest(string customerCode)
        {
            CustomerCode = customerCode;
            Customers = new List<Customer>();
            InvoicesNumber = new List<string>();
            Invoices = new List<Invoice>();
            PaymentsBoleto = new List<PaymentBoleto>();
            PaymentsCredit = new List<PaymentCreditCard>();
            PaymentFeedsOutput = new List<PaymentFeedOutput>();
        }
    }
}
