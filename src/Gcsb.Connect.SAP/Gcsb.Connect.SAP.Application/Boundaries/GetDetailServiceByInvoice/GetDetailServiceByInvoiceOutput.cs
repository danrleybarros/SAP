using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.Boundaries.GetDetailServiceByInvoice
{
    public class GetDetailServiceByInvoiceOutput
    {
        public List<InvoiceOutput> Invoices { get; private set; }

        public GetDetailServiceByInvoiceOutput(List<InvoiceOutput> invoices)
        {
            Invoices = invoices;
        }
    }

    public class InvoiceOutput
    {
        public string CustomerCode { get; private set; }
        public string InvoiceNumber { get; private set; }
        public DateTime DueDate { get; private set; }
        public string BillingCycle { get; private set; }
        public decimal InvoiceAmount { get; private set; }
        public Guid CustomerId { get; private set; }
        public CustomerOutput Customer { get; private set; }
        public List<ServiceOutput> Services { get; private set; }

        public InvoiceOutput(string customerCode, string invoiceNumber, DateTime dueDate,
            string billingCycle, decimal invoiceAmount, Guid customerId, CustomerOutput customer,
            List<ServiceOutput> services)
        {
            CustomerCode = customerCode;
            InvoiceNumber = invoiceNumber;
            DueDate = dueDate;
            BillingCycle = billingCycle;
            InvoiceAmount = invoiceAmount;
            CustomerId = customerId;
            Customer = customer;
            Services = services;
        }
    }

    public class CustomerOutput
    {
        public string CustomerCode { get; private set; }
        public string CompanyName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Cpf { get; private set; }
        public string Cnpj { get; private set; }
        public string Segment { get; private set; }
        public string UF { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string Email { get; private set; }

        public CustomerOutput(string customerCode, string companyName, string firstName,
            string lastName, string cpf, string cnpj, string segment, string uF,
            string city, string zipCode, string email)
        {
            CustomerCode = customerCode;
            CompanyName = companyName;
            FirstName = firstName;
            LastName = lastName;
            Cpf = cpf;
            Cnpj = cnpj;
            Segment = segment;
            UF = uF;
            City = city;
            ZipCode = zipCode;
            Email = email;
        }
    }

    public class ServiceOutput
    {
        public string InvoiceNumber { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string ServiceType { get; private set; }
        public double Quantity { get; private set; }

        public ServiceOutput(string invoiceNumber, string name, decimal price,
            string serviceType, double quantity)
        {
            InvoiceNumber = invoiceNumber;
            Name = name;
            Price = price;
            ServiceType = serviceType;
            Quantity = quantity;
        }
    }
}
