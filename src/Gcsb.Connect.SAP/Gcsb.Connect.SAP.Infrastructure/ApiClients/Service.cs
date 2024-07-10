using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Domain.FinancialAccountsClient.CreditGrantedFinancialAccount;
using Gcsb.Connect.SAP.Infrastructure.ApiClients.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Gcsb.Connect.SAP.Infrastructure.ApiClients
{
    public class Services : IService
    {
        private readonly IJsdnService tokenJsdn;

        public Services(IJsdnService tokenJsdn)
        {
            this.tokenJsdn = tokenJsdn;
        }

        public T Execute<T>(string apiUrl, IRestRequest request) where T : new()
        {
            var client = new RestClient(apiUrl)
            {
                Timeout = 1200000
            };

            client.AddDefaultHeader("Accept", "application/json");
            client.AddDefaultHeader("Content-Type", "application/json");

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException); ;
            }

            return response.Data;
        }

        public T ExecuteAndGetContent<T>(string apiUrl, IRestRequest request) where T : new()
        {
            var client = new RestClient(apiUrl)
            {
                Timeout = 1200000
            };

            client.AddDefaultHeader("Accept", "application/json");
            client.AddDefaultHeader("Content-Type", "application/json");

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException); ;
            }

            if (!string.IsNullOrEmpty(response.Content))
                return JsonConvert.DeserializeObject<T>(response.Content);

            return response.Data;
        }

        public string GetToken()
        {
            var jsdnToken = tokenJsdn.GetToken();
            var request = new RestRequest(Method.POST);
            var url = Environment.GetEnvironmentVariable("TOKEN_GW_URL");

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n\t\"token\":\"" + jsdnToken + "\"\n}", ParameterType.RequestBody);

            var token = Execute<TokenFSW>(url,request);

            return $"Bearer {token.User.Token}";
        }
    }
}
