using AutoMapper;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Domain.JSDN.BillFeedSplit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class InvoiceRepository : IInvoiceWriteOnlyRepository, IInvoiceReadOnlyRepository
    {
        private readonly IMapper mapper;

        public InvoiceRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(Invoice invoice)
        {
            var model = mapper.Map<Entities.BillFeedSplit.Invoice>(invoice);
            var retorno = 0;

            using (var context = new Context())
            {
                context.Invoice.Add(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Add(IEnumerable<Invoice> invoices)
        {
            try
            {
                var model = mapper.Map<IEnumerable<Entities.BillFeedSplit.Invoice>>(invoices);
                var retorno = 0;

                using (var context = new Context())
                {
                    context.Invoice.AddRange(model);
                    retorno = context.SaveChanges();
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteAll()
        {
            try
            {
                var retorno = 0;

                using (var context = new Context())
                {
                    var model = context.Invoice;
                    context.Invoice.RemoveRange(model);
                    retorno = context.SaveChanges();
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(Invoice invoice)
        {
            try
            {
                var model = mapper.Map<Entities.BillFeedSplit.Invoice>(invoice);
                var retorno = 0;

                using (var context = new Context())
                {
                    context.Invoice.Remove(model);
                    retorno = context.SaveChanges();
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Invoice> GetAllInvoices()
        {
            try
            {
                var listaInvoices = new List<Invoice>();

                using (var context = new Context())
                {
                    listaInvoices = mapper.Map<List<Invoice>>(context.Invoice.ToList());
                }

                return listaInvoices;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Invoice GetInvoice(string invoiceNumber)
        {
            try
            {
                Invoice invoice;

                using (var context = new Context())
                {
                    invoice = mapper.Map<Invoice>(context.Invoice.Where(w => w.InvoiceNumber.Equals(invoiceNumber)).FirstOrDefault());
                }

                return invoice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Invoice> GetInvoicesFromIdFile(Guid idFile)
        {
            try
            {
                var listInvoices = new List<Invoice>();

                using (var context = new Context())
                {

                    var invoices = context.Invoice.Where(w => w.IdFile.Equals(idFile) && w.InvoiceStatus.Trim().ToLower() != "disregarded")
                            .Include(i => i.Customer)
                            .Join(context.Customer,
                                    c => c.InvoiceNumber,
                                    i => i.InvoiceNumber,
                                    (i, c) => new { i })
                             .Select(s => s.i).ToList();


                    invoices.ForEach(f =>
                    {
                        f.Customer.Invoice = null;
                    });

                    listInvoices = mapper.Map<List<Invoice>>(invoices);
                }

                return listInvoices;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Invoice> GetInvoicesFromIdFileReturnNF(Guid idFileNF)
        {
            try
            {
                var listInvoices = new List<Invoice>();

                using (var context = new Context())
                {
                    var invoices = context.ReturnNF.Where(w => w.FileId == idFileNF)
                             .Join(context.Invoice
                                 .Include(i => i.Customer)
                                 .Include(i => i.Services),
                                    r => r.InvoiceID,
                                    i => i.InvoiceNumber,
                                    (r, i) => new { i })
                             .Select(s => s.i).ToList();

                    invoices.ForEach(f =>
                    {
                        f.Customer.Invoice = null;
                        f.Services.ForEach(service => service.Invoice = null);
                    });

                    listInvoices = mapper.Map<List<Invoice>>(invoices);
                }

                return listInvoices;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Invoice> GetInvoices(Expression<Func<Invoice, bool>> func)
        {
            using var context = new Context();

            var expr = mapper.Map<Expression<Func<Entities.BillFeedSplit.Invoice, bool>>>(func);
            var invoices = new List<Entities.BillFeedSplit.Invoice>();

            invoices = context.Invoice
                .Where(expr)
                .Include(i => i.Customer)
                .Include(i => i.Services)
                .ToList();

            invoices.ForEach(f =>
            {
                if (f.Customer != null)
                    f.Customer.Invoice = null;

                if (f.Services != null)
                    f.Services.ForEach(service => service.Invoice = null);
            });

            return mapper.Map<List<Invoice>>(invoices);
        }

    public List<Invoice> GetInvoicesFromIdFile(Guid idFile, string resellerName)
    {
        var listInvoices = new List<Invoice>();

        using var context = new Context();

        var invoices = context.Invoice
            .Where(w => w.IdFile.Equals(idFile)
                && w.ResellerName.Trim().ToLower() == resellerName
                && w.InvoiceStatus.Trim().ToLower() != "disregarded")
            .Include(i => i.Customer)
            .Join(context.Customer,
                    c => c.InvoiceNumber,
                    i => i.InvoiceNumber,
                    (i, c) => new { i })
                .Select(s => s.i).ToList();

        invoices.ForEach(f =>
        {
            f.Customer.Invoice = null;
        });

        listInvoices = mapper.Map<List<Invoice>>(invoices);

        return listInvoices;
    }

    public int DeleteCascade(Expression<Func<Invoice, bool>> func)
    {
        using (var context = new Context())
        {
            var invoices = context.Invoice.Where(mapper.Map<Expression<Func<Entities.BillFeedSplit.Invoice, bool>>>(func)).Include(s => s.Customer).Include(s => s.Services).ToList();
            context.ServiceInvoice.RemoveRange(invoices.SelectMany(s => s.Services).ToList());
            context.Customer.RemoveRange(invoices.Select(s => s.Customer).ToList());
            context.Invoice.RemoveRange(invoices);
            return context.SaveChanges();
        }
    }
}
}
