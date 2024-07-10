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
    public class CustomerRepository : ICustomerWriteOnlyRepository, ICustomerReadOnlyRepository
    {
        private readonly IMapper mapper;

        public CustomerRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(Customer customer)
        {
            var model = mapper.Map<Entities.BillFeedSplit.Customer>(customer);
            var retorno = 0;

            using (var context = new Context())
            {
                context.Customer.Add(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Add(IEnumerable<Customer> customers)
        {
            var model = mapper.Map<List<Entities.BillFeedSplit.Customer>>(customers);
            var retorno = 0;

            using (var context = new Context())
            {
                context.Customer.AddRange(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Delete(Customer customer)
        {
            var retorno = 0;

            using (var context = new Context())
            {
                context.Customer.Remove(mapper.Map<Entities.BillFeedSplit.Customer>(customer));
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int Delete(Expression<Func<Customer, bool>> func)
        {
            using (var context = new Context())
            {
                var customers = context.Customer.Where(mapper.Map<Expression<Func<Entities.BillFeedSplit.Customer, bool>>>(func)).ToList();
                context.Customer.RemoveRange(customers);
                return context.SaveChanges();
            }
        }

        public int DeleteAll()
        {
            var retorno = 0;

            using (var context = new Context())
            {
                var model = context.Customer;
                context.Customer.RemoveRange(model);
                context.SaveChanges();
            }

            return retorno;
        }

        public Customer GetCustomer(string invoiceNumber)
        {
            using (var context = new Context())
            {
                return mapper.Map<Customer>(context.Customer
                                           .Where(w => w.InvoiceNumber.Equals(invoiceNumber))
                                           .FirstOrDefault());
            }
        }

        public List<Customer> GetCustomers(Dictionary<string, string> customerInvoiceCyber)
        {
            using (var context = new Context())
            {
                var customers = new List<Entities.BillFeedSplit.Customer>();

                foreach(var infoCustomer in customerInvoiceCyber)
                {
                    var customer = context.Customer
                        .Include(i => i.Invoice)
                        .Where(w => w.CustomerCode == infoCustomer.Value && w.InvoiceNumber != infoCustomer.Key)
                        .ToList();
                    customer.ForEach(f => f.Invoice.Customer = null);

                    customers.AddRange(customer);
                }

                return mapper.Map<List<Customer>>(customers).ToList();
            }
        }

        public List<Customer> GetCustomers(List<string> invoiceNumbers)
        {
            using (var context = new Context())
            {
                var customers = context.Customer
                    .Include(i => i.Invoice)
                    .Where(w => invoiceNumbers.Contains(w.InvoiceNumber)).ToList();

                customers.ForEach(f => f.Invoice.Customer = null);

                return mapper.Map<List<Customer>>(customers).ToList();
            }
        }

        public List<Customer> GetCustomers(string status)
        {
            var costumers = new List<Customer>();

            using (var context = new Context())
            {
                costumers = mapper.Map<List<Customer>>(context.Customer
                    .AsNoTracking()
                    .Where(w => w.IndividualInvoice.Equals(status)).ToList());
            }

            return costumers;
        }

        public List<Customer> GetCustomers(Guid idfile, string individualInvoice)
        {
            using (var context = new Context())
            {
                var customers = context.Customer
                    .Include(i => i.Invoice.Services)
                    .AsNoTracking()
                    .Where(w => w.Invoice.IdFile.Equals(idfile)
                             && w.Invoice.TotalInvoicePrice != 0
                             && w.Invoice.TotalInvoicePrice != 0
                             && w.IndividualInvoice.Equals(individualInvoice) 
                             && w.Invoice.InvoiceStatus.Trim().ToLower() != "disregarded").ToList();

                customers.ForEach(f =>
                {
                    f.Invoice.Customer = null;
                    f.Invoice.Services.ForEach(service => service.Invoice = null);
                });

                return mapper.Map<List<Customer>>(customers).ToList();
            }
        }

        public List<Customer> GetCustomers(Expression<Func<Customer, bool>> expression)
        {
            using var context = new Context();
            var customers = context.Customer.Where(mapper.Map<Expression<Func<Entities.BillFeedSplit.Customer, bool>>>(expression)).ToList();
            
            return mapper.Map<List<Customer>>(customers);
        }
    }
}
