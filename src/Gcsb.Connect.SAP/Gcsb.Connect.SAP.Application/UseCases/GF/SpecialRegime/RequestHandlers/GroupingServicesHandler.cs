using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.SpecialRegime.RequestHandlers
{
    public class GroupingServicesHandler : Handler
    {
        private List<string> activitiesToAvoid => new List<string> { "credits", "fines", "interest", "payment credit", "contractual fine" };
        public override void ProcessRequest(SpecialRegimeRequest request)
        {
            var servicesWithCredit = request.Services.Where(w => w.Activity.ToUpper().Equals("CREDITS")).ToList();
            var servicesWithoutCredit = request.Services.Where(w => !activitiesToAvoid.Contains(w.Activity.ToLower())).ToList();

            request.SpecialRegimes = servicesWithoutCredit.GroupJoin(request.Stores, a => a.Invoice.StoreAcronym, b => b.StoreAcronym, (a, b) => new { a, b })
                  .GroupBy(g => new { g.a.InvoiceNumber, g.a.ServiceCode, g.b.First().StoreAcronym })
                  .Select(s => new Domain.GF.SpecialRegime(
                      s.Key.InvoiceNumber,
                      s.Key.ServiceCode,
                      s.FirstOrDefault().a.ServiceName,
                      (DateTime)s.FirstOrDefault()?.a.Invoice.InvoiceCreationDate,
                      s.FirstOrDefault()?.a.Invoice.Customer.CompanyName,
                      (decimal)s.Sum(z => z.a.GrandTotalRetailPrice),
                      s.Sum(z => z.a.TotalRetailPriceDiscountAmount) ?? 0M,
                      GetCreditValue(s.Key.InvoiceNumber, s.Key.ServiceCode, s.Key.StoreAcronym, servicesWithCredit),
                      (decimal)s.Sum(z => z.a.GrossRetailPrice),
                      s.Sum(z => z.a.TaxRateISS) ?? 0M,
                      s.Sum(z => z.a.TotalTaxISS) ?? 0M,
                      s.FirstOrDefault().a.Invoice.Customer.CustomerCNPJ,
                      s.FirstOrDefault().a.InvoiceNumber,
                      s.FirstOrDefault().a.Invoice.Customer.BillingCity,
                      s.FirstOrDefault().a.Invoice.Customer.BillingZIPcode,
                      s.FirstOrDefault().a.Invoice.Customer.BillingStreet,
                      s.FirstOrDefault().a.Invoice.Customer.CustomerCPF,
                      s.FirstOrDefault().b.First().StoreCnpj,
                      s.FirstOrDefault().b.First().StoreName,
                      s.FirstOrDefault().b.First().CCMMunicipalTaxpayerRegister,
                      s.FirstOrDefault().b.First().SpecialRegimeProcessNumber,
                      s.FirstOrDefault().b.First().CityHallServiceCode,
                      GetTenant(s.FirstOrDefault().a.Invoice),
                      (DateTime)s.FirstOrDefault().a.DueDate,
                      s.FirstOrDefault().a.Invoice.BillFrom.Value,
                      s.Key.StoreAcronym))
                  .ToList();

            sucessor?.ProcessRequest(request);
        }

        private decimal GetCreditValue(string invoiceNumber, string serviceCode, string storeAcronym, List<ServiceInvoice> services)
            => services.Where(w => w.InvoiceNumber.Equals(invoiceNumber) &&
                   w.ServiceCode.Equals(serviceCode) &&
                   w.Invoice.StoreAcronym.Equals(storeAcronym) &&
                   w.Activity.ToUpper().Equals("CREDITS"))
              .Sum(s => (decimal)s.GrandTotalRetailPrice);

        private string GetTenant(Invoice invoice)
            => invoice.StoreCode.Equals(invoice.Customer.CustomerCode) ? invoice.StoreCode : invoice.Customer.CustomerCode;
    }
}
