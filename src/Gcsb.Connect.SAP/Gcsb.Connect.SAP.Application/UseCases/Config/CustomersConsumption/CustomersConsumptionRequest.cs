using Gcsb.Connect.SAP.Application.Boundaries.CustomersConsumption;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.CustomersConsumption
{
    public class CustomersConsumptionRequest
    {
        public List<string> InvoicesNumbers { get; private set; }
        public List<Invoice> Invoices { get; set; }
        public List<Customer> Customers { get; set; }
        public List<CustomersOutput> Consumptions { get; set; }
        public List<PaymentCreditCard> PaymentsCredit { get; set; }
        public List<PaymentBoleto> PaymentsBoleto { get; set; }
        public Dictionary<string, decimal> InvoicesCredit { get; set; }

        public CustomersConsumptionRequest(List<string> invoicesNumbers)
        {
            InvoicesNumbers = invoicesNumbers;
            Invoices = new List<Invoice>();
            Customers = new List<Customer>();
            Consumptions = new List<CustomersOutput>();
            PaymentsCredit = new List<PaymentCreditCard>();
            PaymentsBoleto = new List<PaymentBoleto>();
            InvoicesCredit = new Dictionary<string, decimal>();
        }
    }
}
