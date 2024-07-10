using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDispute
{
    public interface ICounterchargeDisputeUseCase
    {
        void Execute(CounterchargeDisputeRequest request);
    }
}
