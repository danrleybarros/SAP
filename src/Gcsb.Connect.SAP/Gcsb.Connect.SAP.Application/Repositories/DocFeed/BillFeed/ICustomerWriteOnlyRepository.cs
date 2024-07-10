using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed
{
    public interface ICustomerWriteOnlyRepository
    {
        int Add(Customer customer);
        int Add(IEnumerable<Customer> customers);
        int Delete(Customer customer);
        int DeleteAll();
        int Delete(Expression<Func<Customer, bool>> func);
    }
}
