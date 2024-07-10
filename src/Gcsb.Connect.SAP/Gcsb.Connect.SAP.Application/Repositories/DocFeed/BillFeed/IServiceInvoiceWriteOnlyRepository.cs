using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed
{
    public interface IServiceInvoiceWriteOnlyRepository
    {
        int Add(ServiceInvoice service);
        int Add(IEnumerable<ServiceInvoice> service);
        int Delete(ServiceInvoice service);
        int DeleteAll();
        int Delete(Expression<Func<ServiceInvoice, bool>> func);
    }
}
