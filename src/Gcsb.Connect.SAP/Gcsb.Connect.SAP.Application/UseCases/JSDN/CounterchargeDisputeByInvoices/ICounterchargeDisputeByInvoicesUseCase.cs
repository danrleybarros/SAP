using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.JSDN.CounterchargeDisputeByInvoices
{
    public interface ICounterchargeDisputeByInvoicesUseCase
    {
        void Execute(CounterchargeDisputeByInvoicesRequest request);
    }
}
