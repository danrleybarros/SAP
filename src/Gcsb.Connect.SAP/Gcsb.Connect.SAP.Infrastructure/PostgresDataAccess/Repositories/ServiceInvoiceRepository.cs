using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class ServiceInvoiceRepository : IServiceInvoiceWriteOnlyRepository, IServiceInvoiceReadOnlyRepository
    {
        private readonly IMapper mapper;

        public ServiceInvoiceRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(ServiceInvoice service)
        {
            var model = mapper.Map<Entities.BillFeedSplit.ServiceInvoice>(service);
            var retorno = 0;

            using (var context = new Context())
            {
                context.ServiceInvoice.Add(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Add(IEnumerable<ServiceInvoice> services)
        {
            var model = mapper.Map<IEnumerable<Entities.BillFeedSplit.ServiceInvoice>>(services);
            var retorno = 0;

            using (var context = new Context())
            {
                context.ServiceInvoice.AddRange(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Delete(ServiceInvoice service)
        {
            var model = mapper.Map<Entities.BillFeedSplit.ServiceInvoice>(service);
            var retorno = 0;

            using (var context = new Context())
            {
                context.ServiceInvoice.Remove(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public List<ServiceInvoice> GetServices(string invoiceNumber)
        {
            var listaServices = new List<ServiceInvoice>();

            using (var context = new Context())
            {

                listaServices = mapper.Map<List<ServiceInvoice>>(context.ServiceInvoice
                    //TODO Fix Mappings 2 refences
                    //.Include(i => i.Invoice)
                    //.Include(i=> i.Invoice.PaymentFeeds)
                    .Where(w => w.InvoiceNumber.Equals(invoiceNumber)).ToList());
            }

            return listaServices;
        }

        public List<ServiceFilter> GetServices(List<string> invoiceNumber)
        {
            var listaServices = new List<ServiceFilter>();

            using (var context = new Context())
            {
                listaServices = context.ServiceInvoice.Where(w => invoiceNumber.Contains(w.InvoiceNumber))
                    .GroupBy(g => g.ServiceCode)
                    .Select(s => new ServiceFilter
                    {
                        GrossRetailPrice = s.Sum(sum => sum.GrossRetailPrice),
                        TotalRetailPriceDiscountAmount = s.Sum(sum => sum.TotalRetailPriceDiscountAmount),
                        TaxRatePIS = s.Select(sel => sel.TaxRatePIS).First(),
                        TotalRetailTaxPIS = s.Sum(sum => sum.TotalTaxPIS),
                        TaxRateCOFINS = s.Select(sel => sel.TaxRateCOFINS).First(),
                        TotalRetailTaxCOFINS = s.Sum(sum => sum.TotalTaxCOFINS),
                        ServiceCode = s.Select(sel => sel.ServiceCode).First(),
                        GrandTotalRetailPrice = s.Sum(sum => sum.GrandTotalRetailPrice),
                        Invoice = mapper.Map<Invoice>(s.Select(sel => sel.Invoice).First()),
                        TotalRetailPriceWithTaxesWithoutDiscount = Convert.ToDecimal(s.Sum(sum => sum.TotalRetailPriceWithTaxesWithoutDiscount ?? 0)),
                    }).ToList();
            }

            return listaServices;
        }

        public List<ServiceFilter> GetServicesWithoutActivity(List<string> invoiceNumber, 
            List<string> activities, 
            string subscriptionType)
        {
            var listaServices = new List<ServiceFilter>();

            using (var context = new Context())
            {
                var serviceInvoices = context.ServiceInvoice
                    .Where(w => invoiceNumber.Contains(w.InvoiceNumber) && !activities.Contains(w.Activity.ToLower()));

                if (!string.IsNullOrEmpty(subscriptionType))
                    serviceInvoices = serviceInvoices.Where(w => w.SubscriptionType.ToLower() != subscriptionType.ToLower());

                listaServices = serviceInvoices
                   .GroupBy(g => new { g.ServiceCode, g.InvoiceNumber, g.ServiceType })
                   .Select(s => new ServiceFilter
                   {
                       GrossRetailPrice = s.Sum(sum => sum.GrossRetailPrice),
                       TotalRetailPriceDiscountAmount = s.Sum(sum => sum.TotalRetailPriceDiscountAmount),
                       TaxRatePIS = s.Select(sel => sel.TaxRatePIS).First(),
                       TotalRetailTaxPIS = s.Sum(sum => sum.TotalTaxPIS),
                       TaxRateCOFINS = s.Select(sel => sel.TaxRateCOFINS).First(),
                       TotalRetailTaxCOFINS = s.Sum(sum => sum.TotalTaxCOFINS),
                       ServiceCode = s.Key.ServiceCode,
                       StoreAcronym = s.Select(sel => sel.Invoice.StoreAcronym).First(),
                       ProviderCompanyAcronym = s.Select(sel => sel.StoreAcronymServiceProvider).First(),
                       GrandTotalRetailPrice = Math.Round(s.Sum(sum => sum.GrandTotalRetailPrice ?? 0), 2),
                       ServiceType = s.Key.ServiceType,
                       TotalRetailPriceWithTaxesWithoutDiscount = Convert.ToDecimal(s.Sum(sum => sum.TotalRetailPriceWithTaxesWithoutDiscount ?? 0)),
                       InvoiceNumber = s.Key.InvoiceNumber
                   }).ToList();
            }

            return listaServices;
        }

        public List<ServiceFilter> GetServicesWithoutActivity(List<string> invoiceNumber,
            List<string> activities,
            List<string> usageAtrributes,
            string subscriptionType)
        {
            var listaServices = new List<ServiceFilter>();

            using (var context = new Context())
            {
                var serviceInvoices = context.ServiceInvoice
                    .Where(w => invoiceNumber.Contains(w.InvoiceNumber) 
                    && !activities.Contains(w.Activity.ToLower())
                    && !usageAtrributes.Contains(w.UsageAttributes.ToLower()));

                if (!string.IsNullOrEmpty(subscriptionType))
                    serviceInvoices = serviceInvoices.Where(w => w.SubscriptionType.ToLower() != subscriptionType.ToLower());

                listaServices = serviceInvoices
                   .GroupBy(g => new { g.ServiceCode, g.Invoice.InvoiceNumber })
                   .Select(s => new ServiceFilter
                   {
                       GrossRetailPrice = s.Sum(sum => sum.GrossRetailPrice),
                       TotalRetailPriceDiscountAmount = s.Sum(sum => sum.TotalRetailPriceDiscountAmount),
                       TaxRatePIS = s.Select(sel => sel.TaxRatePIS).First(),
                       TotalRetailTaxPIS = s.Sum(sum => sum.TotalTaxPIS),
                       TaxRateCOFINS = s.Select(sel => sel.TaxRateCOFINS).First(),
                       TotalRetailTaxCOFINS = s.Sum(sum => sum.TotalTaxCOFINS),
                       ServiceCode = s.Select(sel => sel.ServiceCode).First(),
                       GrandTotalRetailPrice = Math.Round(s.Sum(sum => sum.GrandTotalRetailPrice ?? 0), 2),
                       Invoice = mapper.Map<Invoice>(s.Select(sel => sel.Invoice).First()),
                       ServiceType = s.Select(sel => sel.ServiceType).FirstOrDefault(),
                       TotalRetailPriceWithTaxesWithoutDiscount = Convert.ToDecimal(s.Sum(sum => sum.TotalRetailPriceWithTaxesWithoutDiscount ?? 0)),
                   }).ToList();
            }

            return listaServices;
        }

        public List<ServiceFilter> GetServicesByActivityAndUsageAttributes(List<string> invoiceNumber, List<string> activities, List<string> usageAtrribute, string subscriptionType)
        {
            var listaServices = new List<ServiceFilter>();

            using (var context = new Context())
            {
                var serviceInvoices = context.ServiceInvoice
                    .Where(w => invoiceNumber.Contains(w.InvoiceNumber) && activities.Contains(w.Activity.ToLower()) && usageAtrribute.Contains(w.UsageAttributes.ToLower()));

                if (!string.IsNullOrEmpty(subscriptionType))
                    serviceInvoices = serviceInvoices.Where(w => w.SubscriptionType.ToLower() != subscriptionType.ToLower());

                listaServices = serviceInvoices
                   .GroupBy(g => new { g.ServiceCode, g.InvoiceNumber, g.Receivable })
                   .Select(s => new ServiceFilter
                   {
                       GrossRetailPrice = s.Sum(sum => sum.GrossRetailPrice),
                       TotalRetailPriceDiscountAmount = s.Sum(sum => sum.TotalRetailPriceDiscountAmount),
                       TaxRatePIS = s.Select(sel => sel.TaxRatePIS).First(),
                       TotalRetailTaxPIS = s.Sum(sum => sum.TotalTaxPIS),
                       TaxRateCOFINS = s.Select(sel => sel.TaxRateCOFINS).First(),
                       TotalRetailTaxCOFINS = s.Sum(sum => sum.TotalTaxCOFINS),
                       ServiceCode = s.Key.ServiceCode,
                       StoreAcronym = s.Select(sel => sel.Invoice.StoreAcronym).First(),
                       ProviderCompanyAcronym = s.Select(sel => sel.StoreAcronymServiceProvider).First(),
                       GrandTotalRetailPrice = Math.Round(s.Sum(sum => sum.GrandTotalRetailPrice ?? 0), 2),
                       ServiceType = s.Select(sel => sel.ServiceType).FirstOrDefault(),
                       TotalRetailPriceWithTaxesWithoutDiscount = Convert.ToDecimal(s.Sum(sum => sum.TotalRetailPriceWithTaxesWithoutDiscount ?? 0)),
                       Receivable = s.Key.Receivable,
                       InvoiceNumber = s.Key.InvoiceNumber
                   }).ToList();
            }

            return listaServices;
        }

        public List<ServiceFilter> GetServicesWithActivity(List<string> invoiceNumber, string activity)
        {
            var listaServices = new List<ServiceFilter>();

            using (var context = new Context())
            {
                listaServices = context.ServiceInvoice.Where(w => invoiceNumber.Contains(w.InvoiceNumber) && w.Activity.ToUpper().Equals(activity.ToUpper()))
                    .GroupBy(g => new { g.ServiceCode, g.Invoice.PaymentMethod, g.ServiceType })
                    .Select(s => new ServiceFilter
                    {
                        GrossRetailPrice = s.Sum(sum => sum.GrossRetailPrice),
                        TotalRetailPriceDiscountAmount = s.Sum(sum => sum.TotalRetailPriceDiscountAmount),
                        TaxRatePIS = s.Select(sel => sel.TaxRatePIS).First(),
                        TotalRetailTaxPIS = s.Sum(sum => sum.TotalTaxPIS),
                        TaxRateCOFINS = s.Select(sel => sel.TaxRateCOFINS).First(),
                        TotalRetailTaxCOFINS = s.Sum(sum => sum.TotalTaxCOFINS),
                        ServiceCode = s.Select(sel => sel.ServiceCode).First(),
                        GrandTotalRetailPrice = s.Sum(sum => sum.GrandTotalRetailPrice),                       
                        Invoice = mapper.Map<Invoice>(s.Select(sel => sel.Invoice).First()),
                        ServiceType = s.Key.ServiceType,
                        TotalRetailPriceWithTaxesWithoutDiscount = Convert.ToDecimal(s.Sum(sum => sum.TotalRetailPriceWithTaxesWithoutDiscount ?? 0)),
                    }).ToList();
            }

            return listaServices;
        }

        public List<ServiceFilter> GetServices(Guid idFilePayment)
        {
            var listaServices = new List<ServiceFilter>();

            using (var context = new Context())
            {
                listaServices = context.ServiceInvoice.Where(w => w.Invoice.PaymentFeedsCredit.Select(s => s.IdFile).Contains(idFilePayment) &&
                    w.Invoice.PaymentFeedsCredit.Where(s => s.ResultCode >= 0 && s.ResultCode <= 99).Any())
                    .GroupBy(g => g.ServiceCode)
                    .Select(s => new ServiceFilter
                    {
                        GrandTotalRetailPrice = s.Sum(sum => sum.GrandTotalRetailPrice),
                        GrossRetailPrice = s.Sum(sum => sum.GrossRetailPrice),
                        TotalRetailPriceDiscountAmount = s.Sum(sum => sum.TotalRetailPriceDiscountAmount),
                        TaxRatePIS = s.Select(sel => sel.TaxRatePIS).First(),
                        TotalRetailTaxPIS = s.Sum(sum => sum.TotalTaxPIS),
                        TaxRateCOFINS = s.Select(sel => sel.TaxRateCOFINS).First(),
                        TotalRetailTaxCOFINS = s.Sum(sum => sum.TotalTaxCOFINS),
                        ServiceCode = s.Select(sel => sel.ServiceCode).First(),
                        Invoice = mapper.Map<Invoice>(s.Select(sel => sel.Invoice).First()),
                        TotalRetailPriceWithTaxesWithoutDiscount = Convert.ToDecimal(s.Sum(sum => sum.TotalRetailPriceWithTaxesWithoutDiscount ?? 0)),
                    }).ToList();
            }

            return listaServices;
        }

        public List<ServiceInvoice> GetServices(Guid idFileBillFeed, string individualInvoice)
        {
            using (var context = new Context())
            {
                var services = context.Invoice
                    .Where(s => s.IdFile == idFileBillFeed && s.Customer.IndividualInvoice.ToLower() == individualInvoice.ToLower() && s.InvoiceStatus.Trim().ToLower() != "disregarded")
                    .SelectMany(s => s.Services)
                    .Include(i => i.Invoice)
                    .Include(i => i.Invoice.Customer)
                    .ToList();

                services.ForEach(f =>
                {
                    f.Invoice.Services = null;
                    f.Invoice.Customer.Invoice = null;
                });

                return mapper.Map<List<ServiceInvoice>>(services).ToList();
            }
        }

        public List<ServiceFilter> GetServicesBillFeed(Guid idFileBillFeed, string activity)
        {
            var listaServices = new List<ServiceFilter>();

            using (var context = new Context())
            {
                listaServices = context.ServiceInvoice
                                       .Where(w => w.Activity.ToUpper().Equals(activity.ToUpper()) && w.Invoice.IdFile.Equals(idFileBillFeed) && w.Invoice.InvoiceStatus.Trim().ToLower() != "disregarded")
                                       .GroupBy(g => g.ServiceCode)
                                       .Select(s => new ServiceFilter
                                       {
                                           GrandTotalRetailPrice = s.Sum(sum => sum.GrandTotalRetailPrice),
                                           Invoice = mapper.Map<Invoice>(s.Select(sel => sel.Invoice).FirstOrDefault()),
                                           ServiceCode = s.Select(sel => sel.ServiceCode).FirstOrDefault(),
                                           TotalRetailPriceWithTaxesWithoutDiscount = Convert.ToDecimal(s.Sum(sum => sum.TotalRetailPriceWithTaxesWithoutDiscount ?? 0)),
                                       }).ToList();
            }

            return listaServices;
        }

        public List<ServiceFilter> GetPaidServices(Guid idFilePayment)
        {
            var listaServices = new List<ServiceFilter>();

            using (var context = new Context())
            {
                var invoices = context.PaymentFeedCreditCard
                    .Where(f => f.IdFile == idFilePayment && (f.ResultCode >= 0 && f.ResultCode <= 99))
                    .Select(s => s.InvoiceNumberJsdn)
                    .ToList();

                var servicesInvoice = context.ServiceInvoice
                      .Include(s => s.Invoice)
                      .ThenInclude(i => i.PaymentFeedsCredit);
                    
                listaServices = servicesInvoice
                    .Where(w => w.Invoice.PaymentFeedsCredit.Select(s => s.IdFile).Contains(idFilePayment)
                            && w.Invoice.PaymentFeedsCredit.Where(s => s.ResultCode >= 0 && s.ResultCode <= 99).Any())
                    .GroupBy(g => new { g.InvoiceNumber, g.ServiceCode })
                    .Select(s => new ServiceFilter
                    {
                        GrandTotalRetailPrice = s.Sum(sum => sum.GrandTotalRetailPrice),
                        Invoice = mapper.Map<Invoice>(s.Select(sel => sel.Invoice).FirstOrDefault()),                        
                        ServiceCode = s.Key.ServiceCode,
                        TotalRetailPriceWithTaxesWithoutDiscount = Convert.ToDecimal(s.Sum(sum => sum.TotalRetailPriceWithTaxesWithoutDiscount ?? 0)),
                        StoreAcronym = s.FirstOrDefault().Invoice.StoreAcronym,
                        ProviderCompanyAcronym = s.FirstOrDefault().StoreAcronymServiceProvider                        
                    }).ToList();
            }

            return listaServices;
        }

        public List<ServiceFilter> GetPaidServices(Guid idFilePayment, List<string> activities)
        {
            var listaServices = new List<ServiceFilter>();

            using (var context = new Context())
            {
                listaServices = context.ServiceInvoice
                    .Where(w => w.Invoice.PaymentFeedsCredit.Select(s => s.IdFile).Contains(idFilePayment)
                            && w.Invoice.PaymentFeedsCredit.Where(s => s.ResultCode >= 0 && s.ResultCode <= 99).Any()
                            && !activities.Contains(w.Activity.ToLower()))
                    .GroupBy(g => new { g.InvoiceNumber, g.ServiceCode })
                    .Select(s => new ServiceFilter
                    {
                        GrandTotalRetailPrice = s.Sum(sum => sum.GrandTotalRetailPrice),
                        Invoice = mapper.Map<Invoice>(s.Select(sel => sel.Invoice).FirstOrDefault()),
                        ServiceCode = s.Key.ServiceCode,
                        TotalRetailPriceWithTaxesWithoutDiscount = Convert.ToDecimal(s.Sum(sum => sum.TotalRetailPriceWithTaxesWithoutDiscount ?? 0)),
                    }).ToList();
            }

            return listaServices;
        }

        public List<ServiceFilter> GetPaidServicesBankSlip(Guid idFilePayment)
        {
            var listaServices = new List<ServiceFilter>();

            using (var context = new Context())
            {
                var paymentFeed = context.PaymentBoleto
                    .Include(a => a.Invoice)
                    .Where(f => f.IdFile == idFilePayment);

                listaServices = context.ServiceInvoice
                    .Join(paymentFeed, s => s.InvoiceNumber, p => p.InvoiceNumberJsdn, (serviceInvoice, paymentFeed) 
                        => new { serviceInvoice, paymentFeed })
                    .Where(w => w.paymentFeed.IdFile.Equals(idFilePayment))
                    .GroupBy(g => new { g.serviceInvoice.InvoiceNumber, g.serviceInvoice.ServiceCode })
                    .Select(s => new ServiceFilter
                    {
                        GrandTotalRetailPrice = s.Sum(sum => sum.serviceInvoice.GrandTotalRetailPrice),
                        Invoice = mapper.Map<Invoice>(s.Select(sel => sel.paymentFeed.Invoice).FirstOrDefault()),                        
                        ServiceCode = s.Key.ServiceCode,
                        StoreAcronym = s.FirstOrDefault().serviceInvoice.Invoice.StoreAcronym,
                        ProviderCompanyAcronym = s.FirstOrDefault().serviceInvoice.StoreAcronymServiceProvider                        
                    }).ToList();
            }

            return listaServices;
        }

        public List<ServiceInvoice> GetServices(Expression<Func<ServiceInvoice, bool>> func)
        {
            var listaServices = new List<ServiceInvoice>();

            using (var context = new Context())
            {
                listaServices = mapper.Map<List<ServiceInvoice>>(context.ServiceInvoice.Where(mapper.Map<Expression<Func<Entities.BillFeedSplit.ServiceInvoice, bool>>>(func)).ToList());
            }

            return listaServices;
        }

        public int DeleteAll()
        {
            try
            {
                var retorno = 0;

                using (var context = new Context())
                {
                    var model = context.ServiceInvoice;
                    context.ServiceInvoice.RemoveRange(model);
                    retorno = context.SaveChanges();
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(Expression<Func<ServiceInvoice, bool>> func)
        {            
            using (var context = new Context())
            {
                var services = context.ServiceInvoice.Where(mapper.Map<Expression<Func<Entities.BillFeedSplit.ServiceInvoice, bool>>>(func)).ToList();
                context.ServiceInvoice.RemoveRange(services);
                return context.SaveChanges();
            }         
        }
    }
}
