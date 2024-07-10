using Gcsb.Connect.SAP.Application.Boundaries.GetDetailServiceByInvoice;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.GetDetailServiceByInvoice.RequestHandlers
{
    public class OutputHandler : Handler
    {
        public override void ProcessRequest(GetDetailServiceByInvoiceRequest request)
        {
            var invoices = new List<InvoiceOutput>();

            request.Invoices
                .ForEach(inv =>
                {
                    var customer = request.Customers.Where(cust => cust.InvoiceNumber == inv.InvoiceNumber).FirstOrDefault();
                    var serviceCode = request.ServiceInvoices.Where(serv => serv.InvoiceNumber == inv.InvoiceNumber).ToList();
                    var customerCode = "7" + customer.CustomerCode.PadLeft(9, '0');

                    var invoice = new InvoiceOutput(
                        customerCode, 
                        inv.InvoiceNumber,
                        serviceCode.FirstOrDefault().DueDate.Value,
                        inv.CycleCode.ToString(),
                        inv.TotalInvoicePrice.Value,
                        customer.Id,
                        new CustomerOutput(
                            customerCode,
                            customer.CompanyName,
                            customer.FirstName,
                            customer.LastName,
                            customer.CustomerCPF,
                            customer.CustomerCNPJ,
                            customer.Segment,
                            Util.GetUFByState(customer.BillingStateOrProvince, Domain.Util.ToEnum<StoreType>(inv.StoreAcronym)),
                            customer.BillingStateOrProvince,
                            customer.BillingZIPcode,
                            customer.CustomerEmailAddress
                            ),
                        serviceCode.Select(serv => new ServiceOutput(
                            serv.InvoiceNumber,
                            serv.ServiceName,
                            Convert.ToDecimal(serv.TotalRetailPrice.Value),
                            serv.ServiceType,
                            serv.Qty.Value
                            )).ToList()
                        );

                    invoices.Add(invoice);
                });

            request.Consumptions = new GetDetailServiceByInvoiceOutput(invoices);
            
            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
