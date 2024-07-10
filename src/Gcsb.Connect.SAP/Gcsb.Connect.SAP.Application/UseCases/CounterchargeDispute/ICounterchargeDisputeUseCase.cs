using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Application.UseCases.CounterchargeDispute
{
    public interface ICounterchargeDisputeUseCase
    {
        Task<CounterChargeDisputeOutput> Execute(CounterchargeDisputeRequest request);
    }
}
