using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Tests.Builders.Util
{
    class JsdnRequest
    {
        private readonly string BaseUrl;

        readonly IRestClient _client;

        public JsdnRequest(string urlApi)
        {
            BaseUrl = urlApi;

            _client = new RestClient(BaseUrl)
            {
                Timeout = 1200000
            };
        }

        public T Execute<T>(IRestRequest request) where T : new()
        {
            _client.AddDefaultHeader("Accept", "application/json");
            _client.AddDefaultHeader("Content-Type", "application/json");

            var response = _client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }

            return response.Data;
        }

        public string authJsdn => JsonConvert.SerializeObject(new JsdnRequestToken()
        {
            auth = new Auth()
            {
                passwordCredentials = new PasswordCredentials()
                {
                    username = Environment.GetEnvironmentVariable("MARKETPLACE_USER"),
                    password = Environment.GetEnvironmentVariable("MARKETPLACE_PASS")
                },
                tenantId = Environment.GetEnvironmentVariable("MARKETPLACE")

            }
        });
    }
}
