using Gcsb.Connect.SAP.Application.Boundaries;
using Gcsb.Connect.SAP.Application.Boundaries.AvgOfferConsumption;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gcsb.Connect.SAP.WebApi.Config.UseCases.FeedData.AvgOfferConsumption
{
    public class AvgOfferConsumptionPresenter : IOutputPort<AvgOfferConsumptionOutput>
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void NotFound(string message)
        {
            throw new NotImplementedException();
        }

        public void Standard(AvgOfferConsumptionOutput output)
            => ViewModel = new OkObjectResult(new AvgOfferConsumptionResponse() { AvgOfferConsumption = output.AvgOfferConsumption});        
    }
}
