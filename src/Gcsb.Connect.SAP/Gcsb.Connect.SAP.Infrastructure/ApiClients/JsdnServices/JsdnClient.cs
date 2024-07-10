using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Gcsb.Connect.SAP.Domain.JSDN;
using Gcsb.Connect.SAP.Infrastructure.ApiClients.Entities;
using RestSharp;

namespace Gcsb.Connect.SAP.Infrastructure.ApiClients.JsdnServices
{
    public class JsdnClient : Application.Repositories.IJsdnService
    {
        private readonly string getSericesUrl;

        public JsdnClient(HttpClient httpClient)
        {
            this.getSericesUrl = $"{Environment.GetEnvironmentVariable("JSDN_URLV1")}";
        }

        public async Task<List<Service>> GetServices(string token)
        {
            return await GetServices(token, default(CancellationToken));
        }

        public async Task<List<Service>> GetServices(string token, CancellationToken cancellationToken)
        {
            var client = new RestClient(getSericesUrl)
            {
                Timeout = 600000
            };

            client.AddDefaultHeader("X-Auth-Token", token);
            client.AddDefaultHeader("Accept", "application/json");
            client.AddDefaultHeader("Content-Type", "application/json");

            var response = client.Execute(new RestRequest("/catalog/getServices", Method.GET));

            if (response.ErrorException != null)
            {
                const string message = "Error on Get Service";
                throw new ApplicationException(message, response.ErrorException);
            }

            return Model.JsdnListServicesResponse.FromJson(((RestSharp.RestResponseBase)response).Content).ConvertToDomain();
        }

        public string GetToken()
        {
            var url = Environment.GetEnvironmentVariable("MARKETPLACE_URL");
            var user = Environment.GetEnvironmentVariable("MARKETPLACE_USER");
            var pass = Environment.GetEnvironmentVariable("MARKETPLACE_PASS");
            var marketplace = Environment.GetEnvironmentVariable("MARKETPLACE");
            var request = new RestRequest("/api/v2.0/tokens", Method.POST);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            request.AddParameter("undefined", "{\n \"auth\": {\n\"passwordCredentials\": {\n\"username\": \"" + user + "\",\n\"password\": \"" + pass + "\"\n},\n\"tenantId\": \"" + marketplace + "\"\n}\n}",
                ParameterType.RequestBody);

            var token = GetResponse<TokenJSDN>(request, url);

            return token.Access.Token.Id;
        }

        public TResponse GetResponse<TResponse>(RestRequest request, string url) where TResponse : new()
        {
            var client = new RestClient(url);
            var response = client.Execute<TResponse>(request);

            if (response.ErrorException != null || response.StatusCode.Equals(HttpStatusCode.InternalServerError))
                throw new ApplicationException(response.ErrorException?.Message ?? response.Content, response.ErrorException);

            return response.Data;
        }
    }
}
