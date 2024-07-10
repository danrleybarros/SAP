using Gcsb.Connect.SAP.Application.Boundaries.NewPendingInvoices;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Domain.JSDN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.NewPendingInvoices.RequestHandlers
{
    public class CreateOutputHandler : Handler
    {
        private readonly IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnly;

        public CreateOutputHandler(IServiceInvoiceReadOnlyRepository serviceInvoiceReadOnly)
        {
            this.serviceInvoiceReadOnly = serviceInvoiceReadOnly;
        }

        public override void ProcessRequest(NewPendingInvoicesRequest request)
        {
            request.UnPaidInvoicesCustomer
                .Select(s => new NewPendingInvoicesOutput
                (
                    s.CustomerCode,
                    s.CustomerCPF,
                    s.CustomerCNPJ,
                    s.InvoiceNumber,
                    s.Invoice.InvoiceCreationDate.Value,
                    s.Invoice.InvoiceStatus,
                    s.Invoice.InvoiceCreationDate.Value,
                    s.Invoice.CycleCode.Value,
                    s.Invoice.TotalInvoicePrice.Value,
                    GetDueDate(s.InvoiceNumber)
                    ));

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }

        private DateTime GetDueDate(string invoiceNumber)
        {
            var services = serviceInvoiceReadOnly.GetServices(invoiceNumber);
            return services.FirstOrDefault().DueDate.Value;
        }
    }
}
