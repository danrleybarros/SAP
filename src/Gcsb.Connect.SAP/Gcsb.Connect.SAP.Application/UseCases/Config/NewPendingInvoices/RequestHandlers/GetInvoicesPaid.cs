using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.NewPendingInvoices.RequestHandlers
{
    public class GetInvoicesPaid : Handler
    {
        public override void ProcessRequest(NewPendingInvoicesRequest request)
        {
            var invoicesNumber = request.UnPaidInvoicesCustomer.Select(s => s.InvoiceNumber);

            var IsCreditcardPaid = request.PaymentsCredit
                .Where(w => invoicesNumber.Contains(w.InvoiceNumberJsdn) && (w.ResultCode >= 0 && w.ResultCode <= 99))
                .Select(s => s.InvoiceNumberJsdn)
                .ToList();

            if (IsCreditcardPaid.Count > 0)
                request.UnPaidInvoicesCustomer = request.UnPaidInvoicesCustomer.Where(f => !IsCreditcardPaid.Contains(f.InvoiceNumber)).ToList();

            var IsBoletoPaid = request.PaymentsBoleto
                .Where(w => invoicesNumber.Contains(w.InvoiceNumberJsdn))
                .GroupBy(g => new { g.InvoiceNumberJsdn, g.TransactionAmount })
                .Select(s => new { s.Key.InvoiceNumberJsdn, s.Key.TransactionAmount, ValorRecebido = s.Sum(s => s.ValorRecebido) })
                .Where(a => a.ValorRecebido >= a.TransactionAmount)
                .Select(s => s.InvoiceNumberJsdn)
                .ToList();

            if (IsBoletoPaid.Count > 0)
                request.UnPaidInvoicesCustomer = request.UnPaidInvoicesCustomer.Where(f => !IsBoletoPaid.Contains(f.InvoiceNumber)).ToList();

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
