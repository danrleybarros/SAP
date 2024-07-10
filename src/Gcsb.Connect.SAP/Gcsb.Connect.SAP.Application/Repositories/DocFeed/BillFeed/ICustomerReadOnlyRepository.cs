using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed
{
    public interface ICustomerReadOnlyRepository
    {
        Customer GetCustomer(string invoiceNumber);
        List<Customer> GetCustomers(List<string> invoiceNumber);
        List<Customer> GetCustomers(string status);
        List<Customer> GetCustomers(Dictionary<string, string> customerInvoiceCyber);
        List<Customer> GetCustomers(Guid idfile, string individualInvoice);
        List<Customer> GetCustomers(Expression<Func<Customer, bool>> expression);
    }
}