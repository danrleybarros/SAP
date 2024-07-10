using Gcsb.Connect.Messaging.Messages.Log;
using System;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Items.RequestHandlers
{
    public class MountItemsHandler : Handler
    {
        public override void ProcessRequest(ItemsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Object request is null");
            
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "After get invoices, the process will a grouping by service code"));

            var invoices = request.Invoices.OrderBy(o => o.InvoiceNumber).GroupBy(g => g.InvoiceNumber).Select(s => s).ToList();

            invoices.ForEach(f =>
            {
                var lintCont = 1;
                var invoice = f.FirstOrDefault();
                var cadgCod = invoice.StoreCode.Equals(invoice.Customer.CustomerCode) ? invoice.StoreCode : invoice.Customer.CustomerCode;
                var nf = request.ReturnNFs.First(w => w.InvoiceID.Equals(f.Key));
                var ibgeCod = request.CodIbgeOutputs.Where(w => w.Cep.Equals(invoice.Customer.MailingZIPcode)).FirstOrDefault();
                var services = f.SelectMany(sel => sel.Services).ToList();

                request.Items.Add(new Domain.GF.Items(invoice.CompanyCode,
                                                        invoice.AffiliateCode,
                                                        int.Parse(nf.NumeroNF),
                                                        nf.DataEmissaoNF,
                                                        cadgCod,
                                                        "",
                                                        services.Sum(sum => sum.GrandTotalRetailPrice ?? 0),
                                                        services.Select(serv => serv.TaxRateISS ?? 0).FirstOrDefault(),
                                                        services.Where(w => !w.Activity.ToUpper().Equals("CREDITS")).Sum(sum => sum.GrandTotalRetailPrice ?? 0),
                                                        Math.Round(((invoice.TotalInvoicePrice ?? 0) * (services.Select(serv => serv.TaxRateISS ?? 0).FirstOrDefault() / 100)), 2),
                                                        Convert.ToDecimal(services.Sum(sum => sum.GrandTotalRetailPrice ?? 0)),
                                                        lintCont,
                                                        ibgeCod?.CodIbge?.ToString(),
                                                        invoice.InvoiceCreationDate.Value.AddMonths(-1)));

                lintCont += 1;
            });
           
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
