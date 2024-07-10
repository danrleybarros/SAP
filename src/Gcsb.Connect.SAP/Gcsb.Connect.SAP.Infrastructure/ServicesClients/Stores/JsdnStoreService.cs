using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.Repositories.JSDN;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace Gcsb.Connect.SAP.Infrastructure.ServicesClients.Stores
{
    public class JsdnStoreService : IJsdnStoreService
    {
        private readonly IJsdnService jsdnService;
        private readonly string urlBase;
        private readonly string marketplace;

        public JsdnStoreService(IJsdnService jsdnService)
        {
            this.jsdnService = jsdnService;

            urlBase = Environment.GetEnvironmentVariable("MARKETPLACE_URL");
            marketplace = Environment.GetEnvironmentVariable("MARKETPLACE");
        }

        public JsdnStore GetStores(string storeAcronym)
        {
            var url = $"{urlBase}/api/mpresource/{marketplace}/storedata/{storeAcronym}";
            var request = new RestRequest(Method.GET);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("X-Auth-Token", jsdnService.GetToken());

            var client = new RestClient(url);
            var response = client.Execute(request);

            return DeserializeObject(response);
        }

        private JsdnStore DeserializeObject(IRestResponse restResponse)
        {
            if (restResponse.IsSuccessful)
            {
                var response = JsonConvert.DeserializeObject<Entities.Stores>(restResponse.Content);
                return new JsdnStore(response.Store.StoreAcronym,
                    response.Store.StoreName,
                    response.Store.StoreOrganization.Custominfo2,
                    response.Store.StoreOrganization.StoreAcronym,
                    "",
                    response.Store.StoreIDPEntityId,
                    response.Store.StoreOrganization.Custominfo3,
                    response.Store.StoreOrganization.StoreUrl,
                    response.Store.StoreOrganization.Address.Address1,
                    response.Store.StoreOrganization.Address.Address2,
                    response.Store.StoreOrganization.Address.Address3,
                    "",
                    response.Store.StoreOrganization.Address.City,
                    response.Store.StoreOrganization.Address.State,
                    response.Store.StoreOrganization.Address.Country,
                    response.Store.StoreOrganization.Address.Zip,
                    response.Store.StoreOrganization.MunicipalTaxpayerReg,
                    response.Store.StoreOrganization.CompanyCode,
                    response.Store.StoreOrganization.BranchCode,
                    response.Store.StoreOrganization.CityHallServiceCode,
                    response.Store.StoreOrganization.CityHallServiceDescription,
                    response.Store.StoreOrganization.ProcessNumSpeReg);
            }
            else
                return null;
        }

    }
}
