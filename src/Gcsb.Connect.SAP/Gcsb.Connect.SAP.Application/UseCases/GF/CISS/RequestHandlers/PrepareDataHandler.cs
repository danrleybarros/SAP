using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.Messaging.Messages.Log;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.CISS.RequestHandlers
{
    public class PrepareDataHandler : Handler
    {
        private readonly IInvoiceReadOnlyRepository invoiceReadOnlyRepository;
        private readonly IReturnNFReadOnlyRepository returnNFReadOnlyRepository;

        public PrepareDataHandler(IInvoiceReadOnlyRepository invoiceReadOnlyRepository, IReturnNFReadOnlyRepository returnNFReadOnlyRepository)
        {
            this.invoiceReadOnlyRepository = invoiceReadOnlyRepository;
            this.returnNFReadOnlyRepository = returnNFReadOnlyRepository;
        }

        public override void ProcessRequest(CISSRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Consulting Invoices - CISS"));
            request.LaunchItems = new List<Domain.GF.CISS>();

            try
            {
                request.Invoices = invoiceReadOnlyRepository.GetInvoicesFromIdFileReturnNF(request.IdFileReturnNF);
                request.ReturnNFs = returnNFReadOnlyRepository.GetReturnNF(request.IdFileReturnNF);

                var invoices = request.Invoices.OrderBy(o => o.InvoiceNumber).GroupBy(g => g.InvoiceNumber).Select(s => s).ToList();

                invoices.ForEach(f =>
                {
                    var lintCont = 1;
                    var invoice = f.FirstOrDefault();
                    var cadgCod = invoice.StoreCode.Equals(invoice.Customer.CustomerCode) ? invoice.StoreCode : invoice.Customer.CustomerCode;
                    var nf = request.ReturnNFs.First(w => w.InvoiceID.Equals(f.Key));
                    var services = f.SelectMany(sel => sel.Services).ToList();

                    request.LaunchItems.Add(new Domain.GF.CISS(invoice.CompanyCode,
                                                               invoice.AffiliateCode,
                                                               int.Parse(nf.NumeroNF),
                                                               nf.DataEmissaoNF,
                                                               lintCont,
                                                               Convert.ToDecimal(services.Where(w => !w.Activity.Equals("CREDITS")).Sum(s => s.GrandTotalRetailPrice ?? 0)),
                                                               services.Select(s => s.TaxRatePIS ?? 0).FirstOrDefault(),
                                                               Math.Round(((invoice.TotalInvoicePrice ?? 0) * (services.Select(serv => serv.TaxRatePIS ?? 0).FirstOrDefault() / 100)), 2),
                                                               services.Select(s => s.TaxRateCOFINS ?? 0).FirstOrDefault(),
                                                               Math.Round(((invoice.TotalInvoicePrice ?? 0) * (services.Select(serv => serv.TaxRateCOFINS ?? 0).FirstOrDefault() / 100)), 2),
                                                               services.Select(s => s.CycleReference.Value).FirstOrDefault()));

                    lintCont += 1;
                });
            }
            catch (Exception ex)
            {
                request.Logs.Add(Log.CreateExceptionLog(request.Service, $"Occurred an error in PrepareDataHandler: {ex.Message ?? ex.InnerException.Message}", ex.StackTrace));
            }

            if (base.sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
