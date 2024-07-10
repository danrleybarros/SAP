using RestSharp;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IService
    {
        T Execute<T>(string apiUrl, IRestRequest request) where T : new();
        T ExecuteAndGetContent<T>(string apiUrl, IRestRequest request) where T : new();
        string GetToken();
    }
}
