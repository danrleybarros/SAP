using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.WebApi.Config.Model;
using Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.PaymentFeedData.PaymentFeedResponse;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Response = Gcsb.Connect.SAP.Application.Boundaries.PaymentFeed.PaymentFeedResponse;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.PaymentFeedData
{
    public class PaymentFeedPresenter : PresenterBase, IOutputPort<List<PaymentBoleto>>, IOutputPort<List<PaymentCreditCard>>
    {
        public void NotFound(string message) => 
            ViewModel = new NotFoundObjectResult(message);

        public void Standard(List<PaymentBoleto> output) => 
            ViewModel = new OkObjectResult(output.Select(f => new OutputPaymentFeed(new Response(f))));

        public void Standard(List<PaymentCreditCard> output) =>
            ViewModel = new OkObjectResult(output.Select(f => new OutputPaymentFeed(new Response(f))));
    }
}
