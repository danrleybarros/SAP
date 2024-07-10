using Gcsb.Connect.SAP.Application.UseCases.GF;

namespace Gcsb.Connect.SAP.Application.UseCases.GF
{
    public interface IReturnNFUseCase
    {
        int Execute(ReturnNFRequest request);
    }
}
