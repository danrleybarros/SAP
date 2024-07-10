using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.InterestAndFine;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace Gcsb.Connect.SAP.Infrastructure.ApiClients.InterestAndFine
{
    public class InterestAndFineClient : IInterestAndFineRepository
    {
        private readonly IService service;

        public InterestAndFineClient(IService service)
        {
            this.service = service;
        }

        public bool SendBillFeedProcessed(string FileName, string cycle)
        {
            var url = Environment.GetEnvironmentVariable("FINES_API");
            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", service.GetToken());
            request.AddParameter("application/json", JsonConvert.SerializeObject(new { fileName = FileName, cycle = cycle }), ParameterType.RequestBody);

            var client = new RestClient(url);
            var response = client.Execute(request);

            return response.IsSuccessful;
        }
    }
}
