using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.InterestAndFineFinancialAccount
{
    public interface IUseCase<TRequest> where TRequest : class
    {
        void Execute(TRequest request);
    }
}
