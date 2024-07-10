using Gcsb.Connect.SAP.Application.Boundaries.GetOpenInvoices;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetOpenInvoices
{
    public class GetOpenInvoicesRequest
    {
        public List<Customer> Customers { get; set; }

        public SearchType SearchType { get; set; }

        private string document;
        public string Document 
        { 
            get => SearchType == SearchType.CustomerCode && document.Length == 10 ? document[3..] : document ; 
            set => document = value; 
        }

        public List<PaymentFeedDoc> Payments { get; set; }

        public List<InvoiceOutput> OpenInvoicesOutput { get; set; }

        public List<ServiceInvoice> Services { get; set; }

        public List<Invoice> Invoices { get; set; }

        public GetOpenInvoicesRequest(SearchType searchType, string document)
        {
            SearchType = searchType;
            Document = document;
            Payments = new List<PaymentFeedDoc>();
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