using Gcsb.Connect.SAP.Application.Boundaries.AllCustomerInvoices;
using Gcsb.Connect.SAP.Domain.Config.Enum;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomerInvoices
{
    public class AllCustomerInvoicesRequest
    {
        public DocumentType DocumentType { get; private set; }
        public string Document { get; private set; }
        public List<Invoice> Invoices { get; set; }
        public List<Customer> Customers { get; set; }
        public List<ServiceInvoice> Services { get; set; }
        public List<AllCustomerInvoicesOutput> Consumptions { get; set; }
        public List<PaymentCreditCard> PaymentsCredit { get; set; }
        public List<PaymentBoleto> PaymentsBoleto { get; set; }

        public AllCustomerInvoicesRequest(DocumentType documentType, string document)
        {
            this.DocumentType = documentType;
            this.Document = document;
            this.Invoices = new List<Invoice>();
            this.Customers = new List<Customer>();
            this.Services = new List<ServiceInvoice>();
            this.Consumptions = new List<AllCustomerInvoicesOutput>();
            this.PaymentsCredit = new List<PaymentCreditCard>();
            this.PaymentsBoleto = new List<PaymentBoleto>();
        }

        public Expression<Func<Customer, bool>> GetExpression()
        {
            Expression<Func<Customer, bool>> getExpression = DocumentType switch
            {
                DocumentType.CPF => getExpression = w => w.CustomerCPF.Equals(Document),
                DocumentType.CNPJ => getExpression = w => w.CustomerCNPJ.Equals(Document),
                _ => throw new NotSupportedException()
            };

            return getExpression;
        }
    }
}
