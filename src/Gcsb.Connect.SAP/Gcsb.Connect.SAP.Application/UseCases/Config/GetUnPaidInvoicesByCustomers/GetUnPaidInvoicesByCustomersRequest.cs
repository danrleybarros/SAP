using Gcsb.Connect.SAP.Application.Boundaries.GetOpenInvoices;
using Gcsb.Connect.SAP.Application.Boundaries.GetUnPaidInvoicesByCustomers;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetUnPaidInvoicesByCustomers
{
    public class GetUnPaidInvoicesByCustomersRequest
    {
        public List<DataDocumentRequest> DataDocuments { get; private set; }
        public List<Customer> Customers { get; set; }
        public List<PaymentFeedDoc> Payments { get; set; }
        public List<InvoicesByDocumentOutput> OpenInvoicesOutput { get; set; }
        public List<ServiceInvoice> Services { get; set; }
        public List<Invoice> Invoices { get; set; }

        public GetUnPaidInvoicesByCustomersRequest(List<DataDocumentRequest> dataDocuments)
        {
            DataDocuments = dataDocuments;
            Customers = new List<Customer>();
            Payments = new List<PaymentFeedDoc>();
            OpenInvoicesOutput = new List<InvoicesByDocumentOutput>();
            Services = new List<ServiceInvoice>();
            Invoices = new List<Invoice>();
        }
    }

    public class DataDocumentRequest
    {
        private string document;
        public string Document {
            get => SearchType == SearchType.CustomerCode && document.Length == 10 ? document[3..] : document;
            set => document = value;
        }
        public SearchType SearchType { get; private set; }

        public DataDocumentRequest(string document, SearchType searchType)
        {
            Document = document;
            SearchType = searchType;
        }

        public Expression<Func<Customer, bool>> GetExpression()
        {
            Expression<Func<Customer, bool>> getExpression = SearchType switch
            {
                SearchType.CPF => getExpression = w => w.CustomerCPF.Equals(Document),
                SearchType.CNPJ => getExpression = w => w.CustomerCNPJ.Equals(Document),
                SearchType.CustomerCode => getExpression = w => w.CustomerCode.Equals(Document),
                _ => throw new NotSupportedException()
            };

            return getExpression;
        }
    }
}
