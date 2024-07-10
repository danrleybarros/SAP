using Gcsb.Connect.SAP.Domain.GF;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.IndividualNFReport.RequestHandlers
{
    public class MountIndividualReportHandler : Handler
    {
        private List<string> activitiesToAvoid => new List<string> { "credits", "fines", "interest", "payment credit", "contractual fine" };
        public override void ProcessRequest(IndividualReportRequestNF request)
        {
            var invoices = request.Invoices.Where(w => w.BillFrom != null && w.BillTo != null).ToList();

            invoices.ForEach(invoice =>
            {
                var services = GroupingServices(invoice);
                var uf = request.UfOutputs.Where(w => w.Cep.Equals(invoice.Customer.MailingZIPcode)).FirstOrDefault();
                var logradouroMailing = request.Logradouros.Where(w => w.Cep.Equals(invoice.Customer.MailingZIPcode)).FirstOrDefault();
                var logradouroBilling = request.Logradouros.Where(w => w.Cep.Equals(invoice.Customer.BillingZIPcode)).FirstOrDefault();
                var addressMailing = $"{logradouroMailing?.TipoLogradouro ?? ""} {logradouroMailing?.NomeLogradouro ?? invoice.Customer.MailingStreet}";
                var addressBilling = $"{logradouroBilling?.TipoLogradouro ?? ""} {logradouroBilling?.NomeLogradouro ?? invoice.Customer.MailingStreet}";

                request.IndividualReports.AddRange(MountIndividualReport(services, request.Stores, uf?.Uf, addressMailing, addressBilling));
            });

            sucessor?.ProcessRequest(request);
        }

        private List<ServiceFilter> GroupingServices(Invoice invoice)
        {
            var services = invoice.Services
                .Where(f => !activitiesToAvoid.Contains(f.Activity.ToLower()))
                .GroupBy(g => new { g.ServiceCode, g.StoreAcronymServiceProvider })
                .Select(s => new ServiceFilter
                {
                    ServiceCode = s.Key.ServiceCode,
                    Invoice = invoice,
                    DueDate = s.Select(sel => sel.DueDate).FirstOrDefault(),
                    ServiceName = s.Select(sel => sel.ServiceName).FirstOrDefault(),
                    Qty = s.Select(sel => sel.Qty).FirstOrDefault(),
                    TaxRateISS = s.Select(sel => GetValue(sel.TaxRateISS)).FirstOrDefault(),
                    TotalTaxISS = s.Sum(sum => GetValue(sum.TotalTaxISS)),
                    TotalTaxPIS = s.Sum(sum => GetValue(sum.TotalTaxPIS)),
                    TotalTaxCOFINS = s.Sum(sum => GetValue(sum.TotalTaxCOFINS)),
                    RetailUnitPrice = s.Sum(sum => sum.RetailUnitPrice),
                    GrandTotalRetailPrice = s.Sum(sum => sum.GrandTotalRetailPrice),
                    ServiceType = s.Select(sel => sel.ServiceType).FirstOrDefault(),                    
                    ProviderCompanyAcronym = s.Key.StoreAcronymServiceProvider
                }).ToList();

            return services;
        }

        private List<IndividualReportNF> MountIndividualReport(List<ServiceFilter> services, List<JsdnStore> stores, string uf, string addressMailing, string addressBilling)
            => services
                .GroupJoin(stores, a => a.ProviderCompanyAcronym, b => b.StoreAcronym, (a, b) => new { a, b })
                .GroupBy(g => new { g.a.Invoice, g.a.ProviderCompanyAcronym })
                .Select(s => new IndividualReportNF(
                    s.FirstOrDefault()?.b.FirstOrDefault()?.CCMMunicipalTaxpayerRegister,
                    s.Key.Invoice.BillFrom.Value,
                    s.Key.Invoice.BillTo.Value,
                    s.Key.Invoice.InvoiceNumber,
                    DateTime.UtcNow,
                    s.Key.Invoice.Services.Where(f => !activitiesToAvoid.Contains(f.Activity.ToLower())).Sum(s => s.GrandTotalRetailPrice.Value),
                    s.First().b.FirstOrDefault().CityHallServiceCode,
                    services.Select(s => GetValue(s.TaxRateISS.Value)).First(),
                    s.Key.Invoice.Customer.CustomerCPF,
                    s.Key.Invoice.Customer.CustomerCNPJ,
                    services.Select(s => s.DueDate.Value).FirstOrDefault(),
                    services.Sum(s => s.GrandTotalRetailPrice.Value),
                    s.Key.Invoice.Customer.CompanyName,
                    s.Key.Invoice.Customer.CustomerStateRegistration,
                    addressMailing,
                    s.Key.Invoice.Customer.MailingNumber,
                    s.Key.Invoice.Customer.MailingCity,
                    uf,
                    s.Key.Invoice.Customer.MailingZIPcode,
                    s.Key.Invoice.Customer.CustomerEmailAddress,
                    addressBilling,
                    s.Key.Invoice.Customer.BillingNumber,
                    s.Key.Invoice.BillFrom.Value,
                    s.Key.ProviderCompanyAcronym))
                .Distinct()
                .Where(f => Math.Round(f.TotalNFValue, 2) != 0)
                .ToList();

        private decimal GetValue(decimal? value)
            => value == null ? 0 : value.Value;
    }
}
