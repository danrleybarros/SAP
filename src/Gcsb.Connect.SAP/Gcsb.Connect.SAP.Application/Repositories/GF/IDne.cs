using Gcsb.Connect.SAP.Domain.GF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Application.Repositories.GF
{
    public interface IDne
    {
        Task<CepOutput> GetLogradouro(string cep);

        Task<int> GetIbge(string cep);

        Task<string> GetUf(string cep);

        Task<List<UfOutput>> GetListUf(List<string> ceps);

        Task<List<CodIbgeOutput>> GetListIbge(List<string> ceps);

        Task<List<CepOutput>> GetListLogradouro(List<string> ceps);
    }
}