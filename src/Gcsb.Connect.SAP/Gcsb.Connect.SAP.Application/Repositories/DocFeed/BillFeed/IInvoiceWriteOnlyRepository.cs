using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed
{
    public interface IInvoiceWriteOnlyRepository
    {
        int Add(Invoice invoice);
        int Add(IEnumerable<Invoice> invoices);
        int Delete(Invoice invoice);
        int DeleteAll();
        int DeleteCascade(Expression<Func<Invoice, bool>> func);
    }
}
