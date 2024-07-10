using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed
{
    public interface IInvoiceReadOnlyRepository
    {
        List<Invoice> GetAllInvoices();

        Invoice GetInvoice(string invoiceNumber);

        List<Invoice> GetInvoicesFromIdFile(Guid idFile);

        List<Invoice> GetInvoicesFromIdFileReturnNF(Guid idFileNF);

        List<Invoice> GetInvoices(Expression<Func<Invoice, bool>> func);
    }
}