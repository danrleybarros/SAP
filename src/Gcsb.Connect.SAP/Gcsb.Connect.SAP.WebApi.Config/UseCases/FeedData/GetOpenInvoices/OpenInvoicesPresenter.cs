using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.GetOpenInvoices;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.GetOpenInvoices
{
    public class OpenInvoicesPresenter : PresenterBase,  IOutputPort<List<InvoiceOutput>>
    {
        public void NotFound(string message) =>
            ViewModel = new NotFoundObjectResult(message);

        public void Standard(List<InvoiceOutput> output) =>
            ViewModel = new OkObjectResult(output);
    }
}