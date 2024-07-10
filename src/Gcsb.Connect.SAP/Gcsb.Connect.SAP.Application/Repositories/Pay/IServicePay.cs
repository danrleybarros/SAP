using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Application.Repositories.Pay
{
    public interface IServicePay
    {
        List<Domain.PAY.Critical> Execute(DateTime dateStart, DateTime dateEnd);
        List<Domain.PAY.InvoicePayment> GetInvoicePayment(List<string> invoices);
    }
}
