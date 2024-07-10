using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.GetUnPaidInvoicesByCustomers;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetUnPaidInvoicesByCustomers
{
    public class GetUnPaidInvoicesByCustomersPresenter : PresenterBase, IOutputPort<List<InvoicesByDocumentOutput>>
    {
        public void NotFound(string message) =>
            ViewModel = new NotFoundObjectResult(message);

        public void Standard(List<InvoicesByDocumentOutput> output) =>
            ViewModel = new OkObjectResult(output);
    }
}
