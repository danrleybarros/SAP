using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Domain.GF;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Infrastructure.ApiClients.GF
{
    public class DNEClient : IDne
    {
        public string UrlBase { get => Environment.GetEnvironmentVariable("DNE_URLV1"); }
        public RestClient RestClient { get; private set; }

        public DNEClient()
        {
            RestClient = new RestClient(UrlBase);
        }

        public async Task<int> GetIbge(string cep)
            => await DneGetIbge(cep);

        public async Task<CepOutput> GetLogradouro(string cep)
            => await DneGetLogradouro(cep);

        public async Task<string> GetUf(string cep)
            => await DneGetUf(cep);

        public async Task<List<UfOutput>> GetListUf(List<string> ceps)
            => await DneGetListUf(ceps);

        public async Task<List<CodIbgeOutput>> GetListIbge(List<string> ceps)
            => await DneGetListIbge(ceps);

        public async Task<List<CepOutput>> GetListLogradouro(List<string> ceps)
            => await DneGetListLogradouro(ceps);

        protected async Task<int> DneGetIbge(string cep)
        {
            try
            {
                var getIbgeUrl = "/GetIbge";
                var response = await GetResponse<string>(cep, getIbgeUrl);

                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<int>(response.Content);
                else
                    throw new Exception(response.ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected async Task<CepOutput> DneGetLogradouro(string cep)
        {
            try
            {
                var getLogradouroUrl = "/GetLogradouro";
                var response = await GetResponse<string>(cep, getLogradouroUrl);

                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<CepOutput>(response.Content);
                else
                    throw new Exception(response.ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected async Task<string> DneGetUf(string cep)
        {
            try
            {
                var getUfUrl = "/GetUf";
                var response = await GetResponse<string>(cep, getUfUrl);

                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<string>(response.Content);
                else
                    throw new Exception(response.ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected async Task<List<UfOutput>> DneGetListUf(List<string> ceps)
        {
            try
            {
                var getUfUrl = "/GetListUf";
                var response = await GetResponse<List<string>>(ceps, getUfUrl);

                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<List<UfOutput>>(response.Content);
                else
                    throw new Exception(response.ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected async Task<List<CodIbgeOutput>> DneGetListIbge(List<string> ceps)
        {
            try
            {
                var getUfUrl = "/GetListIbge";
                var response = await GetResponse<List<string>>(ceps, getUfUrl);

                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<List<CodIbgeOutput>>(response.Content);
                else
                    throw new Exception(response.ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<List<CepOutput>> DneGetListLogradouro(List<string> ceps)
        {
            try
            {
                var getLogUrl = "/GetListLogradouro";
                var response = await GetResponse<List<string>>(ceps, getLogUrl);

                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<List<CepOutput>>(response.Content);
                else
                    throw new Exception(response.ErrorMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<IRestResponse> GetResponse<T>(T parameter, string resource)
        {
            var request = new RestRequest(resource, Method.POST);

            request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(parameter), ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            return await RestClient.ExecuteTaskAsync(request);
        }
    }
}
