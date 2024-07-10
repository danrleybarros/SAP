using Gcsb.Connect.SAP.Application.Boundaries.AllCustomers;
using Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers.SearchExpressions;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers
{
    public class AllCustomersRequest
    {
        public List<Customer> Customers { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<JsdnStore> Stores { get; set; }
        public SearchExpression SearchExpression { get; set; }
        public List<AllCustomersOutput> AllCustomersOutputs { get; set; }

        public AllCustomersRequest(TypeSearch typeSearch, string value)
        {
            SearchExpression = new SearchExpression(typeSearch, value);
            Customers = new List<Customer>();
            Invoices = new List<Invoice>();
            Stores = new List<JsdnStore>();
            AllCustomersOutputs = new List<AllCustomersOutput>();
        }
    }
}
