using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.AxiliaryBook.RequestHandlers
{
    public class LaunchHandler : Handler
    {
        public override void ProcessRequest(AxiliaryBookRequest request)
        {
            request.AddProcessingLog("Mounting the launchs of file - Axiliary Book");

            var InvoicesWithAccountAccounting = request.Services.Where(f => f.CycleReference != null)
                .Join(request.FinancialAccounts, service => service.ServiceCode, financial => financial.ServiceCode, (service, financial) => new { service, financial })
                .Select(s => new { s.service.InvoiceNumber, s.financial.ContaContabilFATDeb, s.service.CycleReference })
                .Distinct()
                .ToList();

            var cycleDate = request.Invoices.Where(w=> w.BillTo != null).Max(m => m.BillTo);

            var launchers = request.ReturnNFs.Join(request.Invoices, nf => nf.InvoiceID, invoice  => invoice.InvoiceNumber, (nf, invoice) => new { nf, invoice })
                                             .Join(InvoicesWithAccountAccounting, i=> i.invoice.InvoiceNumber , accounting => accounting.InvoiceNumber, (i, accounting) => new { i, accounting })                                           
                                             .Select(s => new Domain.GF.AxiliaryBook
                                                                        (s.i.invoice.CompanyCode,
                                                                         s.i.invoice.AffiliateCode,
                                                                         s.i.invoice.StoreCode.Equals(s.i.invoice.Customer.CustomerCode) ? s.i.invoice.StoreCode : s.i.invoice.Customer.CustomerCode,
                                                                         cycleDate.Value,
                                                                         s.accounting.ContaContabilFATDeb,
                                                                         s.i.invoice.InvoiceNumber,                                                                        
                                                                         s.i.nf.DataEmissaoNF,
                                                                         s.i.nf.DataEmissaoNF,
                                                                         s.i.invoice.TotalInvoicePrice.Value,
                                                                         s.i.nf.NumeroNF,
                                                                         s.i.nf.ValorTotalNF - s.i.nf.ValorTotalDescontoNF,
                                                                         s.accounting.CycleReference.Value)).ToList();

            request.LaunchItems.AddRange(launchers);

            if (sucessor != null)
                sucessor.ProcessRequest(request);

        }
    }
}
