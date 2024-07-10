using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.NewPendingInvoices.RequestHandlers
{
    public class GetAllInvoicesHandler : Handler
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;

        public GetAllInvoicesHandler(ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public override void ProcessRequest(NewPendingInvoicesRequest request)
        {
            request.UnPaidInvoicesCustomer = customerReadOnlyRepository
                .GetCustomers(request.CustomerInvoiceCyber);

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
