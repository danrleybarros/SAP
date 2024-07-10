using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.Config.AllCustomers
{
    public interface IAllCustomersUseCase
    {
        void Execute(AllCustomersRequest request);
    }
}
