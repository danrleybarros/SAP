using Gcsb.Connect.Messaging.Messages.Log.Enum;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Master.RequestHandlers
{
    public class MountMasterHandler : Handler<MasterRequest>, IMountMasterHandler
    {
        public override void ProcessRequest(MasterRequest request)
        {
            request.AddLog("After get invoices, the process will a grouping by service code", TypeLog.Processing);

            request.Invoices.ForEach(invoice =>
            {
                var servicesWithCredits = GroupingServices(invoice, true);
                var servicesWithoutCredits = GroupingServices(invoice, false);
                var cadgCod = invoice.StoreCode.Equals(invoice.Customer.CustomerCode) ? invoice.StoreCode : invoice.Customer.CustomerCode;
                var nf = request.ReturnNFs.First(w => w.InvoiceID.Equals(invoice.InvoiceNumber));

                request.Masters.AddRange(MountObjectMaster(invoice, servicesWithCredits, servicesWithoutCredits, cadgCod, nf));
            });

            if (request.Masters.Count == 0)
                throw new ArgumentNullException("Don't have any value for Master");

            sucessor?.ProcessRequest(request);
        }

        public List<ServiceFilter> GroupingServices(Invoice invoice, bool credits)
        {
            var serviceInvoice = new List<ServiceInvoice>();

            if (credits)
                serviceInvoice = invoice.Services.Where(w => w.Activity.ToUpper().Equals("CREDITS")).ToList();
            else
            {
                var activitiesToAvoid = new List<string> { "credits", "fines", "interest", "payment credit", "contractual fine" };
                serviceInvoice = invoice.Services.Where(w => !activitiesToAvoid.Contains(w.Activity.ToLower())).ToList();
            }

            var services = serviceInvoice.GroupBy(g => g.InvoiceNumber)
                    .Select(s => new ServiceFilter
                    {
                        Invoice = invoice,
                        GrandTotalRetailPrice = s.Sum(sum => sum.GrandTotalRetailPrice),
                        RetailUnitPrice = s.Sum(sum => sum.RetailUnitPrice),
                        TotalRetailPriceDiscountAmount = s.Sum(sum => sum.TotalRetailPriceDiscountAmount),
                        TaxRateISS = s.Select(sel => sel.TaxRateISS.Value).First(),
                    }).ToList();

            return services;
        }

        public List<Domain.GF.Master> MountObjectMaster(Invoice invoice, List<ServiceFilter> servicesWithCredits, List<ServiceFilter> servicesWithoutCredits, string cadgCod, Domain.GF.Nfe.ReturnNF nf)
        {
            var masters = new List<Domain.GF.Master>();

            servicesWithoutCredits.ForEach(f =>
            {
                var credit = servicesWithCredits.Where(w => w.Invoice.InvoiceNumber.Equals(f.Invoice.InvoiceNumber)).FirstOrDefault();

                masters.Add(IsValid(new Domain.GF.Master(invoice.CompanyCode,
                    int.Parse(nf.NumeroNF),
                    nf.DataEmissaoNF,
                    cadgCod,
                    Convert.ToDecimal(f.GrandTotalRetailPrice.Value + (credit?.GrandTotalRetailPrice.Value ?? 0)),
                    nf.NFCancelada,
                    f.GrandTotalRetailPrice.Value,
                    invoice.BillTo.Value)));
            });

            return masters;
        }

        private Domain.GF.Master IsValid(Domain.GF.Master master)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(master, null, null);
            Validator.TryValidateObject(master, ctx, validationResults, true);
            if (validationResults.Count > 0)
                throw new Exception("Domain is invalid: " + string.Join(" | ", validationResults.Select(p => p.ErrorMessage).ToArray()));
            else
                return master;
        }
    }
}
